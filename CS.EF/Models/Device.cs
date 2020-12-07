// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="Device.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CS.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    /// <summary>
    /// Class Device.
    /// Implements the <see cref="BaseObjectExtended" />
    /// </summary>
    /// <seealso cref="BaseObjectExtended" />
    [Table("device", Schema = "public")]
    public class Device : BaseObjectExtended
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Column("name")]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [Column("code")]
        public string Code { get; set; }
        /// <summary>
        /// Gets or sets the ip.
        /// </summary>
        /// <value>The ip.</value>
        [Column("ip")]
        public string Ip { get; set; }
        /// <summary>
        /// Gets or sets the area code.
        /// </summary>
        /// <value>
        /// The area code.
        /// </value>
        [Column("area_code")]
        public string AreaCode { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        [Column("is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [Column("type")]
        public DeviceType Type { get; set; }
        /// <summary>
        /// Gets or sets the log time.
        /// </summary>
        /// <value>
        /// The log time.
        /// </value>
        /// <summary>
        /// Gets or sets the applications.
        /// </summary>
        /// <value>
        /// The applications.
        /// </value>
        public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    }
}
