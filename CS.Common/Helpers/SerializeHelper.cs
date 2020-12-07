// ***********************************************************************
// Assembly         : CS.Common
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="SerializeHelper.cs" company="CS.Common">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CS.Common.Helpers
{
    /// <summary>
    /// The serialize helper.
    /// </summary>
    public static class SerializeHelper
    {
        /// <summary>
        /// The serialize a Object into the xml string.
        /// </summary>
        /// <typeparam name="T">Template of object.</typeparam>
        /// <param name="obj">The value.</param>
        /// <returns>The <see cref="string" />.</returns>
        public static string Serialize<T>(this T obj) where T : class
        {
            if (null == obj)
            {
                return string.Empty;
            }
            try
            {
                var xmlserializer = new XmlSerializer(typeof(T));
                var stringWriter = new StringWriterUtf8();
                var xmlWriterSettings = new XmlWriterSettings { OmitXmlDeclaration = true };
                var xmlNamespaces = new XmlSerializerNamespaces();
                xmlNamespaces.Add(string.Empty, string.Empty);
                using (var writer = XmlWriter.Create(stringWriter, xmlWriterSettings))
                {
                    xmlserializer.Serialize(writer, obj, xmlNamespaces);
                    return stringWriter.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// The string writer UTF8.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
    public class StringWriterUtf8 : StringWriter
    {
        /// <summary>
        /// Gets the encoding.
        /// </summary>
        /// <value>The encoding.</value>
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}