// ***********************************************************************
// Assembly         : CS.Base
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="PagedResult.cs" company="CS.Base">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace CS.Base.ViewModels.Responses
{
    /// <summary>
    /// Class PagedResult.
    /// Implements the <see cref="PagedResultBase" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="PagedResultBase" />
    public class PagedResult<T> : PagedResultBase where T : class
    {
        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>The results.</value>
        public IList<T> Results { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedResult{T}"/> class.
        /// </summary>
        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}
