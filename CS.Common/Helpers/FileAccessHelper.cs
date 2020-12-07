// ***********************************************************************
// Assembly         : CS.Common
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="FileAccessHelper.cs" company="CS.Common">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CS.Common.Helpers
{
    /// <summary>
    /// FileAccessHelper
    /// </summary>
    public class FileAccessHelper
    {
        /// <summary>
        /// The image extensions common
        /// </summary>
        public static readonly string[] IMAGE_EXTENSIONS_COMMON = { "jpg", "jpeg", "png" };
        /// <summary>
        /// The image extensions transparent
        /// </summary>
        public static readonly string[] IMAGE_EXTENSIONS_TRANSPARENT = { "png" };
        /// <summary>
        /// The image extensions non transparent
        /// </summary>
        public static readonly string[] IMAGE_EXTENSIONS_NON_TRANSPARENT = { "jpg", "jpeg" };
        /// <summary>
        /// The image extensions all
        /// </summary>
        public static readonly string[] IMAGE_EXTENSIONS_ALL = { "jpg", "jpeg", "png", "bmp", "gif" };
        /// <summary>
        /// The runable extensions
        /// </summary>
        public static readonly string[] RUNABLE_EXTENSIONS = { "exe" };
        /// <summary>
        /// The office extensions
        /// </summary>
        public static readonly string[] OFFICE_EXTENSIONS = { "doc", "docx", "xls", "xlsx" };
        /// <summary>
        /// The zip extension
        /// </summary>
        public static readonly string[] ZIP_EXTENSION = { "zip" };

        /// <summary>
        /// Moves the file.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="httpDirectoryPath">The HTTP directory path.</param>
        /// <returns>FileInfo.</returns>
        public static FileInfo MoveFile(string source, string destination, string httpDirectoryPath)
        {
            try
            {
                string serverDirectory = GetServerMapPath(httpDirectoryPath);
                if (!Directory.Exists(serverDirectory))
                {
                    Directory.CreateDirectory(serverDirectory);
                }
                File.Move(source, destination);

                return new FileInfo(destination);
            }
            catch (Exception ex)
            {
                if (File.Exists(source))
                {
                    File.Delete(source);
                }
                else if (File.Exists(destination))
                {
                    File.Delete(destination);
                }
                throw ex;
            }
        }

        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="httpFilePath">The HTTP file path.</param>
        public static void DeleteFile(string httpFilePath)
        {
            string fullPath = GetServerMapPath(httpFilePath);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        /// <summary>
        /// Deletes the file with absolute file path.
        /// </summary>
        /// <param name="absoluteFilePath">The absolute file path.</param>
        public static void DeleteFileWithAbsoluteFilePath(string absoluteFilePath)
        {
            if (File.Exists(absoluteFilePath))
            {
                File.Delete(absoluteFilePath);
            }
        }

        /// <summary>
        /// Gets the server map path.
        /// </summary>
        /// <param name="httpPath">The HTTP path.</param>
        /// <returns>System.String.</returns>
        public static string GetServerMapPath(string httpPath)
        {
            var absolutePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var directoryName = Path.GetDirectoryName(absolutePath);
            return Path.Combine(directoryName, ".." + httpPath.TrimStart('~').Replace('/', '\\'));
        }

        /// <summary>
        /// Determines whether [is valid extension] [the specified allow extensions].
        /// </summary>
        /// <param name="allowExtensions">The allow extensions.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns><c>true</c> if [is valid extension] [the specified allow extensions]; otherwise, <c>false</c>.</returns>
        public static bool IsValidExtension(string[] allowExtensions, string fileName)
        {
            string ext = Path.GetExtension(fileName.ToLower());
            ext = ext.TrimStart('.');
            return allowExtensions.Contains(ext);
        }

        /// <summary>
        /// Deletes the directory.
        /// </summary>
        /// <param name="directoryHttpPath">The directory HTTP path.</param>
        public static void DeleteDirectory(string directoryHttpPath)
        {
            string fullPath = GetServerMapPath(directoryHttpPath);
            if (Directory.Exists(fullPath))
            {
                ClearDirectory(fullPath);
                Directory.Delete(fullPath);
            }
        }

        /// <summary>
        /// Deletes the directory with absolute path.
        /// </summary>
        /// <param name="directoryAbsolutePath">The directory absolute path.</param>
        public static void DeleteDirectoryWithAbsolutePath(string directoryAbsolutePath)
        {
            if (Directory.Exists(directoryAbsolutePath))
            {
                ClearDirectory(directoryAbsolutePath);
                Directory.Delete(directoryAbsolutePath);
            }
        }

        /// <summary>
        /// Clears the directory.
        /// </summary>
        /// <param name="directoryPath">The directory path.</param>
        private static void ClearDirectory(string directoryPath)
        {
            DirectoryInfo dir = new DirectoryInfo(directoryPath);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                ClearDirectory(di.FullName);
                di.Delete();
            }
        }

        /// <summary>
        /// Combines the name of the HTTP path with file.
        /// </summary>
        /// <param name="httpDirectory">The HTTP directory.</param>
        /// <param name="fileFullName">Full name of the file.</param>
        /// <returns>System.String.</returns>
        public static string CombineHttpPathWithFileName(string httpDirectory, string fileFullName)
        {
            httpDirectory = httpDirectory.TrimStart('~');
            httpDirectory = httpDirectory.TrimStart('/');
            httpDirectory = httpDirectory.TrimEnd('/');

            return "/" + httpDirectory + "/" + fileFullName;
        }
    }
}
