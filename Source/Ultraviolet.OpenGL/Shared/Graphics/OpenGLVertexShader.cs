﻿using System;
using Ultraviolet.Core;
using Ultraviolet.OpenGL.Bindings;

namespace Ultraviolet.OpenGL.Graphics
{
    /// <summary>
    /// Represents a vertex shader.
    /// </summary>
    public unsafe sealed class OpenGLVertexShader : UltravioletResource, IOpenGLResource
    {
        /// <summary>
        /// Initializes a new instance of the OpenGLVertexShader class.
        /// </summary>
        /// <param name="uv">The Ultraviolet context.</param>
        /// <param name="source">The shader source.</param>
        public OpenGLVertexShader(UltravioletContext uv, String[] source)
            : base(uv)
        {
            Contract.Require(source, nameof(source));

            var shader = 0u;

            uv.QueueWorkItemAndWait(() =>
            {
                shader = gl.CreateShader(gl.GL_VERTEX_SHADER);
                gl.ThrowIfError();

                var log = String.Empty;
                if (!ShaderCompiler.Compile(shader, source, out log))
                    throw new InvalidOperationException(log);
            });

            this.shader = shader;
        }

        /// <summary>
        /// Initializes a new instance of the OpenGLVertexShader class.
        /// </summary>
        /// <param name="uv">The Ultraviolet context.</param>
        /// <param name="source">The shader source.</param>
        public OpenGLVertexShader(UltravioletContext uv, String source)
            : this(uv, new[] { source })
        {

        }

        /// <summary>
        /// Gets the OpenGL shader handle.
        /// </summary>
        public UInt32 OpenGLName
        {
            get
            {
                Contract.EnsureNotDisposed(this, Disposed);
                
                return shader;
            }
        }

        /// <summary>
        /// Releases resources associated with this object.
        /// </summary>
        /// <param name="disposing">true if the object is being disposed; false if the object is being finalized.</param>
        protected override void Dispose(Boolean disposing)
        {
            if (Disposed)
                return;

            if (disposing)
            {
                if (!Ultraviolet.Disposed)
                {
                    Ultraviolet.QueueWorkItem((state) =>
                    {
                        gl.DeleteShader(((OpenGLVertexShader)state).shader);
                        gl.ThrowIfError();
                    }, this);
                }
            }

            base.Dispose(disposing);
        }

        // Property values.
        private readonly UInt32 shader;
    }
}
