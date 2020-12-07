// ***********************************************************************
// Assembly         : CS.Configuration
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="IEnvironmentService.cs" company="CS.Configuration">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace CS.Configuration.IConfigurations
{
    /// <summary>
    /// Interface IEnvironmentService
    /// </summary>
    public interface IEnvironmentService
    {
        /// <summary>
        /// Gets or sets the name of the environment.
        /// </summary>
        /// <value>The name of the environment.</value>
        string EnvironmentName { get; set; }
    }
}
