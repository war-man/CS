// ***********************************************************************
// Assembly         : CS.Common
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="LINQHelper.cs" company="CS.Common">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CS.Common.Helpers
{
    /// <summary>
    /// LINQHelper
    /// </summary>
    public class LINQHelper
    {
        /// <summary>
        /// Generates the sort selector.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <returns>LambdaExpression.</returns>
        public static LambdaExpression GenerateSortSelector<TEntity>(String propertyName, out Type resultType) where TEntity : class
        {
            // Create a parameter to pass into the Lambda expression (Entity => Entity.OrderByField).
            var parameter = Expression.Parameter(typeof(TEntity), "Entity");

            //  create the selector part, but support child properties
            PropertyInfo property;
            Expression propertyAccess;
            if (propertyName.Contains('.'))
            {
                // support to be sorted on child fields.
                String[] childProperties = propertyName.Split('.');
                property = typeof(TEntity).GetProperty(childProperties[0]);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
                for (int i = 1; i < childProperties.Length; i++)
                {
                    property = property.PropertyType.GetProperty(childProperties[i]);
                    propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
                }
            }
            else
            {
                property = typeof(TEntity).GetProperty(propertyName);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
            }
            resultType = property.PropertyType;

            // Create the order by expression.
            return Expression.Lambda(propertyAccess, parameter);
        }

        /// <summary>
        /// Generates the method call.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>MethodCallExpression.</returns>
        public static MethodCallExpression GenerateMethodCall<TEntity>(IQueryable<TEntity> source, string methodName, String fieldName) where TEntity : class
        {
            Type type = typeof(TEntity);
            Type selectorResultType;
            LambdaExpression selector = GenerateSortSelector<TEntity>(fieldName, out selectorResultType);
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), methodName,
                                            new Type[] { type, selectorResultType },
                                            source.Expression, Expression.Quote(selector));
            return resultExp;
        }
    }
}
