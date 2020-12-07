using System;
using System.Collections.Generic;
using System.Text;

namespace CS.VM.Models
{
    public class BundleViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        public string Link { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public BundelType Type { get; set; }
        /// <summary>
        /// Gets or sets the release note.
        /// </summary>
        /// <value>
        /// The release note.
        /// </value>
        public string ReleaseNote { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
