using CS.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    [Table("application", Schema = "public")]
    public class Application : BaseObjectExtended
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Column("name")]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the name of the package.
        /// </summary>
        /// <value>
        /// The name of the package.
        /// </value>
        [Column("package_name")]
        public string PackageName { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        [Column("is_active")]
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the is deleted.
        /// </summary>
        /// <value>
        /// The is deleted.
        /// </value>
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        /// <value>
        /// The device identifier.
        /// </value>
        [Column("device_id")]
        public Guid? DeviceId { get; set; }
        /// <summary>
        /// Gets or sets the device.
        /// </summary>
        /// <value>
        /// The device.
        /// </value>
        public virtual Device Device { get; set; }

        /// <summary>
        /// Gets or sets the versions.
        /// </summary>
        /// <value>
        /// The versions.
        /// </value>
        public virtual ICollection<Version> Versions { get; set; } = new List<Version>();
    }
}
