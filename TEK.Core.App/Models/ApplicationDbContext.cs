// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ApplicationDbContext.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using CS.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace TEK.Core.App.Models
{
    /// <summary>
    /// ApplicationDbContext
    /// </summary>
    /// <seealso cref="ApplicationDbContext" />
    public class ApplicationDbContext : DbContext
    {
        #region  Model 
        /// <summary>
        /// Gets or sets the devices.
        /// </summary>
        /// <value>
        /// The devices.
        /// </value>
        public virtual DbSet<Device> Devices { get; set; }
        /// <summary>
        /// Gets or sets the versions.
        /// </summary>
        /// <value>
        /// The versions.
        /// </value>
        public virtual DbSet<Version> Versions { get; set; }
        /// <summary>
        /// Gets or sets the applications.
        /// </summary>
        /// <value>
        /// The applications.
        /// </value>
        public virtual DbSet<Application> Applications { get; set; }
        /// <summary>
        /// Gets or sets the application logs.
        /// </summary>
        /// <value>
        /// The application logs.
        /// </value>
        public virtual DbSet<ApplicationLog> ApplicationLogs { get; set; }
        /// <summary>
        /// Gets or sets the bundles.
        /// </summary>
        /// <value>
        /// The bundles.
        /// </value>
        public virtual DbSet<Bundle> Bundles { get; set; }
        /// <summary>
        /// Gets or sets the commands.
        /// </summary>
        /// <value>
        /// The commands.
        /// </value>
        public virtual DbSet<Command> Commands { get; set; }
        /// <summary>
        /// Gets or sets the device configs.
        /// </summary>
        /// <value>
        /// The device configs.
        /// </value>
        public virtual DbSet<DeviceConfig> DeviceConfigs { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// <para>
        /// Override this method to configure the database (and other options) to be used for this context.
        /// This method is called for each instance of the context that is created.
        /// The base implementation does nothing.
        /// </para>
        /// <para>
        /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
        /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
        /// the options have already been set, and skip some or all of the logic in
        /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
        /// </para>
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
        /// typically define extension methods on this object that allow you to configure the context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<DeviceConfig>().HasKey(k => new { k.DeviceId, k.ApplicationId });
            builder.Entity<DeviceConfig>().UseXminAsConcurrencyToken();
            builder.Entity<Device>().UseXminAsConcurrencyToken();
        }
    }
}