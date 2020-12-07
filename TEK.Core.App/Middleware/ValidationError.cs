// ***********************************************************************
// Assembly         : CS.Middleware
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ValidationError.cs" company="CS.Middleware">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;

namespace TEK.Core.App.Middleware
{
    /// <summary>
    /// Class ValidationError.
    /// </summary>
    public class ValidationError
    {
        /// <summary>
        /// Gets the field.
        /// </summary>
        /// <value>The field.</value>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationError"/> class.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="message">The message.</param>
        public ValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }
    }
}
