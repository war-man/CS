using System;
using System.Collections.Generic;

namespace CS.VM.Models
{
    public class DeviceViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Ip { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the area code.
        /// </summary>
        /// <value>
        /// The area code.
        /// </value>
        public string AreaCode { get; set; }
        public DeviceType Type { get; set; }
        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        public DateTime UpdatedDate { get; set; }
        /// <summary>
        /// Gets or sets the applications.
        /// </summary>
        /// <value>
        /// The applications.
        /// </value>
        public IEnumerable<ApplicationViewModel> Applications { get; set; } = new List<ApplicationViewModel>();
    }

    public class ImportDeviceModel
    {
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public string Ip { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public string IsActive { get; set; }
        /// <summary>
        /// Gets or sets the area code.
        /// </summary>
        /// <value>
        /// The area code.
        /// </value>
        public string AreaCode { get; set; }
        public string Type { get; set; }
    }
}
