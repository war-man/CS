// ***********************************************************************
// Assembly         : CS.Configuration
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="IConfigurationService.cs" company="CS.Configuration">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.Extensions.Configuration;

namespace CS.Configuration.IConfigurations
{
    /// <summary>
    /// Interface IConfigurationService
    /// </summary>
    public interface IConfigurationService
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <returns>IConfiguration.</returns>
        IConfiguration GetConfiguration();
    }
}
