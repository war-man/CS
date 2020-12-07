using CS.VM.Models;
using System.Collections.Generic;

namespace CS.VM.Response
{
    public class ImportDeviceResponse
    {
        public List<ImportDeviceData> Import { get; set; }
        public int Total { get; set; }
        public string FileErrorUrl { get; set; }
    }

    public class ImportDeviceData
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
        public bool IsVerify { get; set; }
        public List<string> Reasons { get; set; }
    }
}
