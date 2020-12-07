// ***********************************************************************
// Assembly         : CS.EF
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="DbContextExtension.cs" company="CS.EF">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CS.EF.Helpers
{
    /// <summary>
    /// Class DbContextExtension.
    /// </summary>
    public static class DbContextExtension
    {
        /// <summary>
        /// Initializes the database asynchronous.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public static async Task InitializeDatabaseAsync(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var scopeServiceProvider = serviceScope.ServiceProvider;
                var db = scopeServiceProvider.GetService<ApplicationDbContext>();
                if (await db.Database.EnsureCreatedAsync())
                {
                    await InsertTestDataAsync(scopeServiceProvider);
                }
            }
        }

        // TODO [EF] This may be replaced by a first class mechanism in EF
        /// <summary>
        /// Adds the or update asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="propertyToMatch">The property to match.</param>
        /// <param name="item">The item.</param>
        private static async Task AddOrUpdateAsync<TEntity>(
            IServiceProvider serviceProvider,
            Func<TEntity, object> propertyToMatch, TEntity item)
            where TEntity : class
        {
            // Query in a separate context so that we can attach existing entities as modified
            List<TEntity> existingData;
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                existingData = db.Set<TEntity>().ToList();
            }

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                db.Entry(item).State = existingData.Any(g => propertyToMatch(g).Equals(propertyToMatch(item)))
                    ? EntityState.Modified
                    : EntityState.Added;

                await db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Inserts the test data asynchronous.
        /// </summary>
        /// <param name="scopeServiceProvider">The scope service provider.</param>
        private static async Task InsertTestDataAsync(IServiceProvider scopeServiceProvider)
        {
           
        }
    }
}