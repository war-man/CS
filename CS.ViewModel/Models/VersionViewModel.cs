using System;
using System.Collections.Generic;

namespace CS.VM.Models
{
    public class VersionViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        public string ApplicationName { get; set; }
        public DateTime UpdatedDate { get; set; }
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public int Code { get; set; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the bundles.
        /// </summary>
        /// <value>
        /// The bundles.
        /// </value>
        public IEnumerable<BundleViewModel> Bundles { get; set; } = new List<BundleViewModel>();
    }
}
