using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    [Table("device_config", Schema = "public")]
    public class DeviceConfig
    {
        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        /// <value>
        /// The device identifier.
        /// </value>
        [Column("device_id")]
        public Guid DeviceId { get; set; }
        [Column("device_name")]
        public string DeviceName { get; set; }
        [Column("area_code")]
        public string AreaCode { get; set; }
        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        /// <value>
        /// The application identifier.
        /// </value>
        [Column("application_id")]
        public Guid ApplicationId { get; set; }
        /// <summary>
        /// Gets or sets the version identifier.
        /// </summary>
        /// <value>
        /// The version identifier.
        /// </value>
        [Column("version_id")]
        public Guid VersionId { get; set; }
        [Column("version_code")]
        public int VersionCode { get; set; }
        [Column("package_name")]
        public string PackageName { get; set; }
        [Column("application_name")]
        public string ApplicationName { get; set; }
        [Column("version_name")]
        public string VersionName { get; set; }
        /// <summary>
        /// Gets or sets the log time.
        /// </summary>
        /// <value>
        /// The log time.
        /// </value>
        [Column("log_time")]
        public DateTime? LogTime { get; set; }
        [Column("is_active")]
        public bool IsActive { get; set; }
        [Column("message")]
        public string Message { get; set; }
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
