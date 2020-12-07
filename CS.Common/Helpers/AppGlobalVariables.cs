// ***********************************************************************
// Assembly         : CS.Common
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="AppGlobalVariables.cs" company="CS.Common">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Net.Http;

namespace CS.Common.Helpers
{
    /// <summary>
    /// Class AppGlobalVariables.
    /// </summary>
    public static class AppGlobalVariables
    {
        /// <summary>
        /// The API client
        /// </summary>
        public static HttpClient apiClient = new HttpClient();
        /// <summary>
        /// Initializes static members of the <see cref="AppGlobalVariables"/> class.
        /// </summary>
        static AppGlobalVariables()
        {
            apiClient.BaseAddress = new Uri("http://203.205.21.79/syscore/api/");
            apiClient.DefaultRequestHeaders.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
