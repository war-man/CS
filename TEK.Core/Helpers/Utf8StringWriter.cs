// ***********************************************************************
// Assembly         : CS.Implements
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="Utf8StringWriter.cs" company="CS.Implements">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.IO;
using System.Text;

namespace TEK.Core.Helpers
{
    /// <summary>
    /// Class Utf8StringWriter.
    /// Implements the <see cref="StringWriter" />
    /// </summary>
    /// <seealso cref="StringWriter" />
    public class Utf8StringWriter : StringWriter
    {
        /// <summary>
        /// Gets the encoding.
        /// </summary>
        /// <value>The encoding.</value>
        public override Encoding Encoding => Encoding.UTF8;
    }
}
