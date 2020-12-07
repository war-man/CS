using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CS.VM.Request
{
    public class AddOrUpdateApplicationRequest
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonRequired]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the name of the package.
        /// </summary>
        /// <value>
        /// The name of the package.
        /// </value>
        [JsonRequired]
        public string PackageName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the device ids.
        /// </summary>
        /// <value>
        /// The device ids.
        /// </value>
        //[JsonRequired]
        //public Guid DeviceId { get; set; }
        public List<Guid> VersionIds { get; set; }
    }
}
