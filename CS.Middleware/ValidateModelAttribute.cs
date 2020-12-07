// ***********************************************************************
// Assembly         : CS.Middleware
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ValidateModelAttribute.cs" company="CS.Middleware">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Mvc.Filters;

namespace CS.Middleware
{
    /// <summary>
    /// Class ValidateModelAttribute.
    /// Implements the <see cref="ActionFilterAttribute" />
    /// </summary>
    /// <seealso cref="ActionFilterAttribute" />
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Called when [action executing].
        /// </summary>
        /// <param name="context">The context.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ValidationFailedResult(context.ModelState);
            }

            base.OnActionExecuting(context);
        }
    }
}
