// ***********************************************************************
// Assembly         : CS.Configuration
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ConfigurationService.cs" company="CS.Configuration">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.IO;
using CS.Configuration.IConfigurations;
using Microsoft.Extensions.Configuration;

namespace CS.Configuration.Configurations
{
    /// <summary>
    /// Class ConfigurationService.
    /// Implements the <see cref="IConfigurationService" />
    /// </summary>
    /// <seealso cref="IConfigurationService" />
    public class ConfigurationService : IConfigurationService
    {
        /// <summary>
        /// Gets the env service.
        /// </summary>
        /// <value>The env service.</value>
        public IEnvironmentService EnvService { get; }
        /// <summary>
        /// Gets or sets the current directory.
        /// </summary>
        /// <value>The current directory.</value>
        public string CurrentDirectory { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationService"/> class.
        /// </summary>
        /// <param name="envService">The env service.</param>
        public ConfigurationService(IEnvironmentService envService)
        {
            EnvService = envService;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <returns>IConfiguration.</returns>
        public IConfiguration GetConfiguration()
        {
            CurrentDirectory = CurrentDirectory ?? Directory.GetCurrentDirectory();
            return new ConfigurationBuilder()
                .SetBasePath(CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{EnvService.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
