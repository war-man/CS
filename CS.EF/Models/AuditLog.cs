// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="AuditLog.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace CS.EF.Models
{
    /// <summary>
    /// Class AuditLog.
    /// </summary>
    [Table("audit_log")]
    public class AuditLog
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the inserted date.
        /// </summary>
        /// <value>The inserted date.</value>
        [Column("inserted_date")]
        public DateTime InsertedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        [Column("updated_date")]
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        [Column("data")]
        public JsonElement Data { get; set; }
    }
}
