using System;
using System.Collections.Generic;

namespace CS.VM.Models
{
    public class ApplicationViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the name of the package.
        /// </summary>
        /// <value>
        /// The name of the package.
        /// </value>
        public string PackageName { get; set; }
        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; } 
        /// <summary>
        /// Gets or sets the versions.
        /// </summary>
        /// <value>
        /// The versions.
        /// </value>
        //public DeviceViewModel Device { get; set; }
        public IEnumerable<VersionViewModel> Versions { get; set; } = new List<VersionViewModel>();
    }
}
