﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using TwistedLogik.Ultraviolet.UI.Presentation.Uvss.Syntax;
using TwistedLogik.Ultraviolet.VisualStudio.Uvss.Parsing;

namespace TwistedLogik.Ultraviolet.VisualStudio.Uvss.Tagging
{
    /// <summary>
    /// Represents a tagger which puts squigglies under parser errors.
    /// </summary>
    internal sealed class SyntaxErrorTagger : ITagger<IErrorTag>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SyntaxErrorTagger"/> class.
        /// </summary>
        /// <param name="parserService">The UVSS language parser service.</param>
        /// <param name="buffer">The text buffer that contains the text being tagged.</param>
        public SyntaxErrorTagger(IUvssParserService parserService, ITextBuffer buffer)
        {
            this.parserService = parserService;
            this.parserService.DocumentGenerated += (span, document) =>
                RaiseTagsChanged(span);

            this.buffer = UvssTextBuffer.ForBuffer(buffer);
        }
        
        /// <summary>
        /// Gets the tags for the specified spans of text.
        /// </summary>
        /// <param name="spans">The spans of text for which to retrieve tags.</param>
        /// <returns>A collection containing the tags for the specified spans of text.</returns>
        public IEnumerable<ITagSpan<IErrorTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            var result = new List<ITagSpan<IErrorTag>>();

            foreach (var span in spans)
            {
                var blockSpan = buffer.GetOutermostBlockSpan(span);

                var task = parserService.GetDocument(blockSpan);
                task.Wait(100);

                if (task.Status == TaskStatus.RanToCompletion)
                {
                    var tags = GetTags(span, task.Result);
                    result.AddRange(tags);
                }
                else
                {
                    task.ContinueWith(t =>
                    {
                        RaiseTagsChanged(blockSpan);
                    },
                    TaskContinuationOptions.OnlyOnRanToCompletion);
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the tags for the specified document.
        /// </summary>
        /// <param name="span">The snapshot span from which the document was generated.</param>
        /// <param name="document">The document for which to retrieve tags.</param>
        /// <returns>A collection containing the tags for the specified document.</returns>
        public IEnumerable<ITagSpan<IErrorTag>> GetTags(SnapshotSpan span, UvssDocumentSyntax document)
        {
            var result = new List<ITagSpan<IErrorTag>>();

            var visitor = new SyntaxErrorVisitor((start, width, message) =>
            {
                var absoluteStart = start + span.Start;

                if (width == 0)
                    width = 1;

                if (absoluteStart + width > span.Snapshot.Length)
                    start = span.Snapshot.Length - width;

                var tagSpan = new SnapshotSpan(span.Snapshot, absoluteStart, width);
                var tag = new ErrorTag(message, message);
                result.Add(new TagSpan<IErrorTag>(tagSpan, tag));
            });

            visitor.Visit(document);

            return result;
        }

        /// <inheritdoc/>
        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

        /// <summary>
        /// Raises the <see cref="TagsChanged"/> event.
        /// </summary>
        private void RaiseTagsChanged(SnapshotSpan span)
        {
            var handler = TagsChanged;
            if (handler != null)
            {
                handler(this, new SnapshotSpanEventArgs(span));
            }
        }
        
        // Tagging services.
        private readonly IUvssParserService parserService;
        private readonly UvssTextBuffer buffer; 
    }
}
