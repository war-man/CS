// ***********************************************************************
// Assembly         : CS.Base
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="Response.cs" company="CS.Base">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CS.Base.ViewModels.Responses
{
    /// <summary>
    /// The response.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T> where T : class
    {
        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        [JsonProperty("Total")]
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        [JsonProperty("Data")]
        public IEnumerable<T> Data { get; set; }
    }
}