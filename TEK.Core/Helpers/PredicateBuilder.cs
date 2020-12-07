// ***********************************************************************
// Assembly         : CS.Implements
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="PredicateBuilder.cs" company="CS.Implements">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TEK.Core.Helpers
{
    /// <summary>
    /// Class PredicateBuilder.
    /// </summary>
    public static class PredicateBuilder
    {
        // Creates a predicate that evaluates to true.        
        /// <summary>
        /// Trues this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Expression&lt;Func&lt;T, System.Boolean&gt;&gt;.</returns>
        public static Expression<Func<T, bool>> True<T>() { return param => true; }

        // Creates a predicate that evaluates to false.        
        /// <summary>
        /// Falses this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Expression&lt;Func&lt;T, System.Boolean&gt;&gt;.</returns>
        public static Expression<Func<T, bool>> False<T>() { return param => false; }

        // Creates a predicate expression from the specified lambda expression.        
        /// <summary>
        /// Creates the specified predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Expression&lt;Func&lt;T, System.Boolean&gt;&gt;.</returns>
        public static Expression<Func<T, bool>> Create<T>(Expression<Func<T, bool>> predicate) { return predicate; }

        // Combines the first predicate with the second using the logical "and".        
        /// <summary>
        /// Ands the specified second.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>Expression&lt;Func&lt;T, System.Boolean&gt;&gt;.</returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.AndAlso);
        }

        // Combines the first predicate with the second using the logical "or".        
        /// <summary>
        /// Ors the specified second.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>Expression&lt;Func&lt;T, System.Boolean&gt;&gt;.</returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.OrElse);
        }

        // Negates the predicate.        
        /// <summary>
        /// Nots the specified expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>Expression&lt;Func&lt;T, System.Boolean&gt;&gt;.</returns>
        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression)
        {
            var negated = Expression.Not(expression.Body);
            return Expression.Lambda<Func<T, bool>>(negated, expression.Parameters);
        }

        // Combines the first expression with the second using the specified merge function.        
        /// <summary>
        /// Composes the specified second.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <param name="merge">The merge.</param>
        /// <returns>Expression&lt;T&gt;.</returns>
        static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // zip parameters (map from parameters of second to parameters of first)
            var map = first.Parameters
                .Select((f, i) => new { f, s = second.Parameters[i] })
                .ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with the parameters in the first
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // create a merged lambda expression with parameters from the first expression
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        /// <summary>
        /// Class ParameterRebinder.
        /// Implements the <see cref="ExpressionVisitor" />
        /// </summary>
        /// <seealso cref="ExpressionVisitor" />
        class ParameterRebinder : ExpressionVisitor
        {
            /// <summary>
            /// The map
            /// </summary>
            readonly Dictionary<ParameterExpression, ParameterExpression> map;

            /// <summary>
            /// Initializes a new instance of the <see cref="ParameterRebinder"/> class.
            /// </summary>
            /// <param name="map">The map.</param>
            ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
            {
                this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
            }

            /// <summary>
            /// Replaces the parameters.
            /// </summary>
            /// <param name="map">The map.</param>
            /// <param name="exp">The exp.</param>
            /// <returns>Expression.</returns>
            public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
            {
                return new ParameterRebinder(map).Visit(exp);
            }

            /// <summary>
            /// Visits the parameter.
            /// </summary>
            /// <param name="p">The p.</param>
            /// <returns>Expression.</returns>
            protected override Expression VisitParameter(ParameterExpression p)
            {
                ParameterExpression replacement;
                if (map.TryGetValue(p, out replacement))
                {
                    p = replacement;
                }
                return base.VisitParameter(p);
            }
        }
    }
}
