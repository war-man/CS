// ***********************************************************************
// Assembly         : CS.Common
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="LeftJoinExtension.cs" company="CS.Common">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CS.Common.Common
{
    /// <summary>
    /// Class LeftJoinExtension.
    /// </summary>
    public static class LeftJoinExtension
    {
        /// <summary>
        /// Lefts the join.
        /// </summary>
        /// <typeparam name="TOuter">The type of the t outer.</typeparam>
        /// <typeparam name="TInner">The type of the t inner.</typeparam>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="outer">The outer.</param>
        /// <param name="inner">The inner.</param>
        /// <param name="outerKeySelector">The outer key selector.</param>
        /// <param name="innerKeySelector">The inner key selector.</param>
        /// <param name="resultSelector">The result selector.</param>
        /// <returns>IQueryable&lt;TResult&gt;.</returns>
        public static IQueryable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(
        this IQueryable<TOuter> outer,
        IQueryable<TInner> inner,
        Expression<Func<TOuter, TKey>> outerKeySelector,
        Expression<Func<TInner, TKey>> innerKeySelector,
        Expression<Func<TOuter, TInner, TResult>> resultSelector)
        {
            MethodInfo groupJoin = typeof(Queryable).GetMethods()
                                                     .Single(m => m.ToString() == "System.Linq.IQueryable`1[TResult] GroupJoin[TOuter,TInner,TKey,TResult](System.Linq.IQueryable`1[TOuter], System.Collections.Generic.IEnumerable`1[TInner], System.Linq.Expressions.Expression`1[System.Func`2[TOuter,TKey]], System.Linq.Expressions.Expression`1[System.Func`2[TInner,TKey]], System.Linq.Expressions.Expression`1[System.Func`3[TOuter,System.Collections.Generic.IEnumerable`1[TInner],TResult]])")
                                                     .MakeGenericMethod(typeof(TOuter), typeof(TInner), typeof(TKey), typeof(LeftJoinIntermediate<TOuter, TInner>));
            MethodInfo selectMany = typeof(Queryable).GetMethods()
                                                      .Single(m => m.ToString() == "System.Linq.IQueryable`1[TResult] SelectMany[TSource,TCollection,TResult](System.Linq.IQueryable`1[TSource], System.Linq.Expressions.Expression`1[System.Func`2[TSource,System.Collections.Generic.IEnumerable`1[TCollection]]], System.Linq.Expressions.Expression`1[System.Func`3[TSource,TCollection,TResult]])")
                                                      .MakeGenericMethod(typeof(LeftJoinIntermediate<TOuter, TInner>), typeof(TInner), typeof(TResult));

            var groupJoinResultSelector = (Expression<Func<TOuter, IEnumerable<TInner>, LeftJoinIntermediate<TOuter, TInner>>>)
                                          ((oneOuter, manyInners) => new LeftJoinIntermediate<TOuter, TInner> { OneOuter = oneOuter, ManyInners = manyInners });

            MethodCallExpression exprGroupJoin = Expression.Call(groupJoin, outer.Expression, inner.Expression, outerKeySelector, innerKeySelector, groupJoinResultSelector);

            var selectManyCollectionSelector = (Expression<Func<LeftJoinIntermediate<TOuter, TInner>, IEnumerable<TInner>>>)
                                               (t => t.ManyInners.DefaultIfEmpty());

            ParameterExpression paramUser = resultSelector.Parameters.First();

            ParameterExpression paramNew = Expression.Parameter(typeof(LeftJoinIntermediate<TOuter, TInner>), "t");
            MemberExpression propExpr = Expression.Property(paramNew, "OneOuter");

            LambdaExpression selectManyResultSelector = Expression.Lambda(new Replacer(paramUser, propExpr).Visit(resultSelector.Body), paramNew, resultSelector.Parameters.Skip(1).First());

            MethodCallExpression exprSelectMany = Expression.Call(selectMany, exprGroupJoin, selectManyCollectionSelector, selectManyResultSelector);

            return outer.Provider.CreateQuery<TResult>(exprSelectMany);
        }

        /// <summary>
        /// Class LeftJoinIntermediate.
        /// </summary>
        /// <typeparam name="TOuter">The type of the t outer.</typeparam>
        /// <typeparam name="TInner">The type of the t inner.</typeparam>
        private class LeftJoinIntermediate<TOuter, TInner>
        {
            /// <summary>
            /// Gets or sets the one outer.
            /// </summary>
            /// <value>The one outer.</value>
            public TOuter OneOuter { get; set; }
            /// <summary>
            /// Gets or sets the many inners.
            /// </summary>
            /// <value>The many inners.</value>
            public IEnumerable<TInner> ManyInners { get; set; }
        }

        /// <summary>
        /// Class Replacer.
        /// Implements the <see cref="ExpressionVisitor" />
        /// </summary>
        /// <seealso cref="ExpressionVisitor" />
        private class Replacer : ExpressionVisitor
        {
            /// <summary>
            /// The old parameter
            /// </summary>
            private readonly ParameterExpression _oldParam;
            /// <summary>
            /// The replacement
            /// </summary>
            private readonly Expression _replacement;

            /// <summary>
            /// Initializes a new instance of the <see cref="Replacer"/> class.
            /// </summary>
            /// <param name="oldParam">The old parameter.</param>
            /// <param name="replacement">The replacement.</param>
            public Replacer(ParameterExpression oldParam, Expression replacement)
            {
                _oldParam = oldParam;
                _replacement = replacement;
            }

            /// <summary>
            /// Visits the specified exp.
            /// </summary>
            /// <param name="exp">The exp.</param>
            /// <returns>Expression.</returns>
            public override Expression Visit(Expression exp)
            {
                if (exp == _oldParam)
                {
                    return _replacement;
                }

                return base.Visit(exp);
            }
        }
    }
}
