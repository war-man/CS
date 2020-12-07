// ***********************************************************************
// Assembly         : CS.Common
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="QueryableCollectionExtensions.cs" company="CS.Common">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace CS.Common.Helpers
{
    /// <summary>
    /// The Query Collection Extensions.
    /// </summary>
    public static class QueryableCollectionExtensions
    {
        /// <summary>
        /// The apply paging.
        /// </summary>
        /// <typeparam name="TSource">The source collection type</typeparam>
        /// <param name="data">The data.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>The <see cref="IQueryable" />.</returns>
        public static IQueryable<TSource> ApplyPaging<TSource>(this IQueryable<TSource> data, int page, int pageSize)
        {
            if (pageSize > 0 && page > 0)
            {
                data = data.Skip((page - 1) * pageSize);
            }

            data = data.Take(pageSize);

            return data;
        }

        /// <summary>
        /// The add sort expression.
        /// </summary>
        /// <typeparam name="TSource">Type of object in collection</typeparam>
        /// <param name="data">The data.</param>
        /// <param name="sortDirection">The sort direction.</param>
        /// <param name="memberName">The member name.</param>
        /// <returns>The <see cref="IQueryable" />.</returns>
        private static IQueryable<TSource> AddSortExpression<TSource>(IQueryable<TSource> data, ListSortDirection sortDirection, string memberName)
        {
            var methodName = sortDirection == ListSortDirection.Ascending ? "OrderBy" : "OrderByDescending";
            var props = memberName.Split('.');
            Type[] type = { typeof(TSource) };
            var arg = Expression.Parameter(type[0], "x");
            Expression expr = arg;

            foreach (var pi in props.Select(prop => type[0].GetProperty(prop)))
            {
                expr = Expression.Property(expr, pi);
                type[0] = pi.PropertyType;
            }

            var delegateType = typeof(Func<,>).MakeGenericType(typeof(TSource), type[0]);
            var lambda = Expression.Lambda(delegateType, expr, arg);

            var result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(TSource), type[0])
                    .Invoke(null, new object[] { data, lambda });

            return (IOrderedQueryable<TSource>)result;
        }
    }
}