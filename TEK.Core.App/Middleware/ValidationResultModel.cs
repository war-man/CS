// ***********************************************************************
// Assembly         : CS.Middleware
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ValidationResultModel.cs" company="CS.Middleware">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TEK.Core.App.Middleware
{
    /// <summary>
    /// Class ValidationResultModel.
    /// Implements the <see cref="CS.Middleware.ApiResponse" />
    /// </summary>
    /// <seealso cref="CS.Middleware.ApiResponse" />
    public class ValidationResultModel : ApiResponse
    {
        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <value>The errors.</value>
        public List<ValidationError> Errors { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResultModel"/> class.
        /// </summary>
        /// <param name="modelState">State of the model.</param>
        /// <exception cref="ArgumentException">ModelState must be invalid - modelState</exception>
        public ValidationResultModel(ModelStateDictionary modelState) : base(false, 400, "Validation Failed")
        {
            if (modelState.IsValid)
            {
                throw new ArgumentException("ModelState must be invalid", nameof(modelState));
            }

            Errors = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();
        }
    }
}
