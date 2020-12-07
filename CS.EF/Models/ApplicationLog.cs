using CS.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    [Table("application_log", Schema = "public")]
    public class ApplicationLog : BaseObjectExtended
    {
        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        /// <value>
        /// The device identifier.
        /// </value>
        [Column("application_id")]
        public Guid ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        /// <value>
        /// The device identifier.
        /// </value>
        [Column("device_id")]
        public Guid DeviceId { get; set; }
        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        [Column("link")]
        public string Link { get; set; }
    }
}
