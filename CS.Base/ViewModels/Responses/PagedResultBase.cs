// ***********************************************************************
// Assembly         : CS.Base
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="PagedResultBase.cs" company="CS.Base">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace CS.Base.ViewModels.Responses
{
    /// <summary>
    /// Class PagedResultBase.
    /// </summary>
    public abstract class PagedResultBase
    {
        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        /// <value>The current page.</value>
        public int CurrentPage { get; set; }
        /// <summary>
        /// Gets or sets the page count.
        /// </summary>
        /// <value>The page count.</value>
        public int PageCount { get; set; }
        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        public int PageSize { get; set; }
        /// <summary>
        /// Gets or sets the row count.
        /// </summary>
        /// <value>The row count.</value>
        public int RowCount { get; set; }

        /// <summary>
        /// Gets the first row on page.
        /// </summary>
        /// <value>The first row on page.</value>
        public int FirstRowOnPage
        {

            get { return (CurrentPage - 1) * PageSize + 1; }
        }

        /// <summary>
        /// Gets the last row on page.
        /// </summary>
        /// <value>The last row on page.</value>
        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, RowCount); }
        }
    }
}
