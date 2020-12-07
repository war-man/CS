using CS.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    [Table("command", Schema = "public")]
    public class Command : BaseObjectExtended
    {
        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        /// <value>
        /// The device identifier.
        /// </value>
        [Column("device_id")]
        public Guid DeviceId { get; set; }
        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        /// <value>
        /// The application identifier.
        /// </value>
        [Column("application_id")]
        public Guid ApplicationId { get; set; }
        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        [Column("action_command")]
        public ActionCommand ActionCommand { get; set; }

        [Column("command_description")]
        public string CommandDescription { get; set; }
        [Column("package_name")]
        public string PackageName { get; set; }
    }
}
