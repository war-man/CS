// ***********************************************************************
// Assembly         : CS.Middleware
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ValidationFailedResult.cs" company="CS.Middleware">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TEK.Core.App.Middleware
{
    /// <summary>
    /// Class ValidationFailedResult.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.ObjectResult" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ObjectResult" />
    public class ValidationFailedResult : ObjectResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationFailedResult"/> class.
        /// </summary>
        /// <param name="modelState">State of the model.</param>
        public ValidationFailedResult(ModelStateDictionary modelState)
            : base(new ValidationResultModel(modelState))
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }
    }
}
