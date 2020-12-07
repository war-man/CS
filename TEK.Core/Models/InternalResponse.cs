using Newtonsoft.Json;

namespace TEK.Core.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class InternalResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BaseResponse"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("success")]
        public bool Success { get; set; }
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        [JsonProperty("code")]
        public int Code { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="TEK.Payment.Domain.Models.InternalResponse" />
    public class BaseInternalResponse<T> : InternalResponse
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        [JsonProperty("result")]
        public T Result { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ErrorResponse : InternalResponse
    {
    }
}
