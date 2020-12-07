// ***********************************************************************
// Assembly         : CS.Base
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="BaseViewModelExtended.cs" company="CS.Base">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;

namespace CS.Base.ViewModels
{
    /// <summary>
    /// Class BaseViewModelExtended.
    /// Implements the <see cref="BaseViewModel" />
    /// </summary>
    /// <seealso cref="BaseViewModel" />
    public class BaseViewModelExtended : BaseViewModel
    {
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        [JsonProperty("created_date")]
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>The updated by.</value>
        [JsonProperty("updated_by")]
        public string UpdatedBy { get; set; }
        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        [JsonProperty("updated_date")]
        public DateTime? UpdatedDate { get; set; }
    }
}
