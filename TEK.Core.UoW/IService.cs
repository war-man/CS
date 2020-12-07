// ***********************************************************************
// Assembly         : CS.Base
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="IService.cs" company="CS.Base">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TEK.Core.UoW
{
    /// <summary>
    /// IService
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="R"></typeparam>
    public interface IService<T, R> where T : class where R : IRepository<T>
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>ICollection&lt;T&gt;.</returns>
        ICollection<T> GetAll();

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        Task<ICollection<T>> GetAllAsync();

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        T Get(Guid id);

        /// <summary>
        /// Gets the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> GetAsync(Guid id);

        /// <summary>
        /// Finds the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>T.</returns>
        T Find(Expression<Func<T, bool>> match);

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> FindAsync(Expression<Func<T, bool>> match);

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>ICollection&lt;T&gt;.</returns>
        ICollection<T> FindAll(Expression<Func<T, bool>> match);

        /// <summary>
        /// Finds all asynchronous.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns>Task&lt;ICollection&lt;T&gt;&gt;.</returns>
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);

        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        T Add(T entity);

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Updates the specified updated.
        /// </summary>
        /// <param name="updated">The updated.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        T Update(T updated, Guid id);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="updated">The updated.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> UpdateAsync(T updated, Guid id);

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);

        /// <summary>
        /// Deletes the specified t.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(Guid id);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> DeleteAsync(T entity);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> DeleteAsync(Guid id);

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        int Count();

        /// <summary>
        /// Counts the asynchronous.
        /// </summary>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> CountAsync();
    }
}
