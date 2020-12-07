// ***********************************************************************
// Assembly         : CS.Base
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="BaseObjectExtended.cs" company="CS.Base">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.Base
{
    /// <summary>
    /// Class BaseObjectExtended.
    /// Implements the <see cref="BaseObject" />
    /// </summary>
    /// <seealso cref="BaseObject" />
    public class BaseObjectExtended : BaseObject
    {
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        [Column("created_by")]
        public string CreatedBy { get; set; } = "System";

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>The updated by.</value>
        [Column("updated_by")]
        public string UpdatedBy { get; set; } = "System";

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        [Column("updated_date")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
