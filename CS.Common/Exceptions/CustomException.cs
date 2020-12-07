// ***********************************************************************
// Assembly         : CS.Common
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="CustomException.cs" company="CS.Common">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace CS.Common.Exceptions
{
    /// <summary>
    /// Custom Exception
    /// </summary>
    /// <seealso cref="Exception" />
    public class CustomException : Exception
    {
        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>The errors.</value>
        public ErrorViewModel[] Errors { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException" /> class.
        /// </summary>
        /// <param name="errors">The errors.</param>
        public CustomException(params ErrorViewModel[] errors)
        {
            Errors = errors;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException" /> class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public CustomException(string errorMessage)
        {
            Errors = new ErrorViewModel[] { new ErrorViewModel { Error = ErrorCode.Unknown, Message = errorMessage } };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException" /> class.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="message">The message.</param>
        public CustomException(ErrorCode error, string message = null)
        {
            Errors = new ErrorViewModel[] { new ErrorViewModel { Error = error, Message = message } };
        }
    }
}