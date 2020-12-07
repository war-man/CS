// ***********************************************************************
// Assembly         : CS.Implements
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="XmlSerializerHelper.cs" company="CS.Implements">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.IO;
using System.Xml.Serialization;

namespace TEK.Core.Helpers
{
    /// <summary>
    /// Interface IXmlSerializerHelper
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IXmlSerializerHelper<T> where T : class
    {
        /// <summary>
        /// Invokes this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        string Invoke();
    }

    /// <summary>
    /// Class XmlSerializerHelper.
    /// Implements the <see cref="CS.Implements.Helpers.IXmlSerializerHelper{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="CS.Implements.Helpers.IXmlSerializerHelper{T}" />
    public class XmlSerializerHelper<T> : IXmlSerializerHelper<T> where T : class
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>The data.</value>
        public T Data { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlSerializerHelper{T}"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public XmlSerializerHelper(T data)
        {
            Data = data;
        }

        /// <summary>
        /// Invokes this instance.
        /// </summary>
        /// <returns>System.String.</returns>
        public string Invoke()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(Data.GetType());

            var xmlText = string.Empty;

            using (StringWriter textWriter = new Utf8StringWriter())
            {
                xmlSerializer.Serialize(textWriter, Data);
                xmlText = textWriter.ToString();
            }

            return xmlText;
        }
    }
}
