// ***********************************************************************
// Assembly         : CS.Base
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="BaseRequest.cs" company="CS.Base">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;

namespace CS.Base.ViewModels.Requests
{
    /// <summary>
    /// Class BaseRequest.
    /// </summary>
    public class BaseRequest
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonRequired]
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
