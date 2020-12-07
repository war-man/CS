using CS.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CS.EF.Models
{
    [Table("bundle", Schema = "public")]
    public class Bundle : BaseObjectExtended
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
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        [Column("link")]
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [Column("type")]
        public BundelType Type { get; set; }

        /// <summary>
        /// Gets or sets the release note.
        /// </summary>
        /// <value>
        /// The release note.
        /// </value>
        [Column("release_note")]
        public string ReleaseNote { get; set; }
        /// <summary>
        /// Gets or sets the version identifier.
        /// </summary>
        /// <value>
        /// The version identifier.
        /// </value>
        [Column("version_id")]
        public Guid VersionId { get; set; }
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
        /// Gets or sets the application.
        /// </summary>
        /// <value>
        /// The application.
        /// </value>
        public virtual Version Version { get; set; }
    }
}
