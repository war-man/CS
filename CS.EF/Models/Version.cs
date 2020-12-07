using CS.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS.EF.Models
{
    [Table("version", Schema = "public")]
    public class Version : BaseObjectExtended
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
        public int Code { get; set; }

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
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [Column("is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [application name].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [application name]; otherwise, <c>false</c>.
        /// </value>
        [Column("application_name")]
        public string ApplicationName { get; set; }

        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        /// <value>
        /// The application identifier.
        /// </value>
        [Column("application_id")]
        public Guid ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the application.
        /// </summary>
        /// <value>
        /// The application.
        /// </value>
        public virtual Application Application { get; set; }
        /// <summary>
        /// Gets or sets the applications.
        /// </summary>
        /// <value>
        /// The applications.
        /// </value>
        public virtual ICollection<Bundle> Bundles { get; set; } = new List<Bundle>();

    }
}