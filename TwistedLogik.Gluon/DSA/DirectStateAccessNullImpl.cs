﻿using System;

namespace TwistedLogik.Gluon
{
    partial class gl
    {
        /// <summary>
        /// Implements DSA functions for OpenGL contexts which do not support DSA. Unlike true DSA implementations,
        /// this class will modify the global binding state of the OpenGL context.
        /// </summary>
        internal sealed unsafe class DirectStateAccessNullImpl : DirectStateAccessImpl
        {
            public override void NamedBufferData(uint buffer, uint target, IntPtr size, void* data, uint usage)
            {
                glBufferData(target, size, (IntPtr)data, usage);
            }

            public override void NamedBufferSubData(uint buffer, uint target, IntPtr offset, IntPtr size, void* data)
            {
                glBufferSubData(target, offset, size, (IntPtr)data);
            }

            public override void NamedFramebufferTexture(uint framebuffer, uint target, uint attachment, uint texture, int level)
            {
                glFramebufferTexture(target, attachment, texture, level);
            }

            public override void NamedFramebufferRenderbuffer(uint framebuffer, uint target, uint attachment, uint renderbuffertarget, uint renderbuffer)
            {
                glFramebufferRenderbuffer(target, attachment, renderbuffertarget, renderbuffer);
            }

            public override void NamedFramebufferDrawBuffer(uint framebuffer, uint mode)
            {
                glDrawBuffer(mode);
            }

            public override unsafe void NamedFramebufferDrawBuffers(uint framebuffer, int n, uint* bufs)
            {
                glDrawBuffers(n, (IntPtr)bufs);
            }

            public override uint CheckNamedFramebufferStatus(uint framebuffer, uint target)
            {
                return glCheckFramebufferStatus(target);
            }

            public override void TextureParameteri(uint texture, uint target, uint pname, int param)
            {
                glTexParameteri(target, pname, param);
            }

            public override void TextureImage2D(uint texture, uint target, int level, int internalformat, int width, int height, int border, uint format, uint type, void* pixels)
            {
                glTexImage2D(target, level, internalformat, width, height, border, format, type, (IntPtr)pixels);
            }

            public override void TextureSubImage2D(uint texture, uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, void* pixels)
            {
                glTexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, (IntPtr)pixels);
            }

            public override void TextureStorage1D(uint texture, uint target, int levels, uint internalformat, int width)
            {
                glTexStorage1D(target, levels, internalformat, width);
            }

            public override void TextureStorage2D(uint texture, uint target, int levels, uint internalformat, int width, int height)
            {
                glTexStorage2D(target, levels, internalformat, width, height);
            }

            public override void TextureStorage3D(uint texture, uint target, int levels, uint internalformat, int width, int height, int depth)
            {
                glTexStorage3D(target, levels, internalformat, width, height, depth);
            }

            public override void* MapNamedBuffer(uint buffer, uint target, uint access)
            {
                return glMapBuffer(target, access).ToPointer();
            }

            public override void* MapNamedBufferRange(uint buffer, uint target, int* offset, uint* length, uint access)
            {
                return glMapBufferRange(target, (IntPtr)offset, (IntPtr)length, access).ToPointer();
            }

            public override bool UnmapNamedBuffer(uint buffer, uint target)
            {
                return glUnmapBuffer(target);
            }

            public override void FlushMappedNamedBufferRange(uint buffer, uint target, int* offset, uint* length)
            {
                glFlushMappedBufferRange(target, (IntPtr)offset, (IntPtr)length);
            }

            public override void GetNamedBufferParameteriv(uint buffer, uint target, uint pname, int* @params)
            {
                glGetBufferParameteriv(target, pname, (IntPtr)@params);
            }

            public override void GetNamedBufferPointerv(uint buffer, uint target, uint pname, void** @params)
            {
                glGetBufferPointerv(target, pname, (IntPtr)@params);
            }

            public override void GetNamedBufferSubData(uint buffer, uint target, int* offset, uint* size, void* data)
            {
                glGetBufferSubData(target, (IntPtr)offset, (IntPtr)size, (IntPtr)data);
            }
        }
    }
}
