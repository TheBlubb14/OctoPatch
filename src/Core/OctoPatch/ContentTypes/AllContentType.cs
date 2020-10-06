﻿using System;
using System.Runtime.Serialization;

namespace OctoPatch.ContentTypes
{
    /// <summary>
    /// Content type for all kind of types. This is only used as a no-matter-what input
    /// </summary>
    [DataContract]
    public sealed class AllContentType : ContentType
    {
        /// <inheritdoc />
        public override Type SupportedType => typeof(object);

        /// <inheritdoc />
        public override bool IsSupportedType(Type type)
        {
            // All types are supported
            return true;
        }
    }
}
