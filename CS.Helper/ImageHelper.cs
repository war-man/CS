// ***********************************************************************
// Assembly         : CS.Helper
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="ImageHelper.cs" company="CS.Helper">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Drawing;
using System.IO;

namespace CS.Helper
{
    /// <summary>
    /// Class ImageHelper.
    /// </summary>
    public static class ImageHelper
    {
        /// <summary>
        /// Base64s to image.
        /// </summary>
        /// <param name="base64String">The base64 string.</param>
        /// <param name="path">The path.</param>
        /// <returns>Image.</returns>
        public static Image Base64ToImage(string base64String, string path)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                image.Save(path);
                return image;
            }
        }
    }
}
