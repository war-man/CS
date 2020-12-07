// ***********************************************************************
// Assembly         : CS.Common
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="BoolToIntConverter.cs" company="CS.Common">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CS.Common.Helpers
{
    /// <summary>
    /// Class BoolToIntConverter.
    /// Implements the <see cref="ValueConverter{bool, int}" />
    /// </summary>
    /// <seealso cref="ValueConverter{bool, int}" />
    public class BoolToIntConverter : ValueConverter<bool, int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoolToIntConverter"/> class.
        /// </summary>
        /// <param name="mappingHints">The mapping hints.</param>
        public BoolToIntConverter(ConverterMappingHints mappingHints = null)
            : base(
                  v => Convert.ToInt32(v),
                  v => Convert.ToBoolean(v),
                  mappingHints)
        {
        }

        /// <summary>
        /// Gets the default information.
        /// </summary>
        /// <value>The default information.</value>
        public static ValueConverterInfo DefaultInfo { get; }
            = new ValueConverterInfo(typeof(bool), typeof(int), i => new BoolToIntConverter(i.MappingHints));
    }
}
