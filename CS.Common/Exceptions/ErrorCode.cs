// ***********************************************************************
// Assembly         : CS.Common
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ErrorCode.cs" company="CS.Common">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CS.Common.Exceptions
{
    /// <summary>
    /// Enum ErrorCode
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// The unknown
        /// </summary>
        Unknown = 0,

        #region common errors
        /// <summary>
        /// This error occur when user try to access a resource require authorization
        /// </summary>
        Unauthorized = 401,

        /// <summary>
        /// This error occur when logged in user does not have role/permission to do action
        /// </summary>
        PermissionDenied = 403,

        /// <summary>
        /// The server is refusing to service the request because the entity of the request is in a format not supported by the requested resource for the requested method <br />
        /// For example: API only support for multipart/form-data content type, but request is in application/json content type
        /// </summary>
        UnsupportedMediaType = 415,

        /// <summary>
        /// Internal server error, please log and report system admin
        /// </summary>
        InternalServerError = 500,

        /// <summary>
        /// Bad Request
        /// </summary>
        BadRequest = 400,

        /// <summary>
        /// Missing required fields
        /// </summary>
        Missing_Required_Fields = 999,
        #endregion

        #region Configuration User errors 3000
        /// <summary>
        /// This error occurs when try to add permissions with duplicated code
        /// </summary>
        UserDuplicated = 3000,

        /// <summary>
        /// This error occurs when try to access not exist permission
        /// </summary>
        UserNotFound = 3001,

        /// <summary>
        /// The user identifier is null
        /// </summary>
        UserIdIsNull = 3002,

        /// <summary>
        /// The user in exist
        /// </summary>
        UserInExist = 3003,
        #endregion
    }
}