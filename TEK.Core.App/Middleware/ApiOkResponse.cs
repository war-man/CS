// ***********************************************************************
// Assembly         : CS.Middleware
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ApiOkResponse.cs" company="CS.Middleware">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace TEK.Core.App.Middleware
{
    /// <summary>
    /// Class ApiOkResponse.
    /// Implements the <see cref="CS.Middleware.ApiResponse" />
    /// </summary>
    /// <seealso cref="CS.Middleware.ApiResponse" />
    /// <seealso cref="ApiResponse" />
    public class ApiOkResponse : ApiResponse
    {
        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>The result.</value>
        public object Result { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiOkResponse" /> class.
        /// </summary>
        /// <param name="result">The result.</param>
        public ApiOkResponse(object result)
            : base(true, 200)
        {
            Result = result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiOkResponse"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="success">if set to <c>true</c> [success].</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="message">The message.</param>
        public ApiOkResponse(object result, bool success, int statusCode, string message = null)
            : base(success, statusCode, message)
        {
            Result = result;
        }
    }
}
