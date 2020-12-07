// ***********************************************************************
// Assembly         : CS.Configuration
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="EnvironmentService.cs" company="CS.Configuration">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using CS.Common.Common;
using CS.Configuration.IConfigurations;

namespace CS.Configuration.Configurations
{
    /// <summary>
    /// Class EnvironmentService.
    /// Implements the <see cref="IEnvironmentService" />
    /// </summary>
    /// <seealso cref="IEnvironmentService" />
    public class EnvironmentService : IEnvironmentService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnvironmentService"/> class.
        /// </summary>
        public EnvironmentService()
        {
            EnvironmentName = Environment.GetEnvironmentVariable(Constants.EnvironmentVariables.AspnetCoreEnvironment)
                ?? Constants.Environments.Production;
        }

        /// <summary>
        /// Gets or sets the name of the environment.
        /// </summary>
        /// <value>The name of the environment.</value>
        public string EnvironmentName { get; set; }
    }
}
