// ***********************************************************************
// Assembly         : CS.Common
// Author           : TamNT
// Created          : 04-16-2020
//
// Last Modified By : Admin
// Last Modified On : 04-16-2020
// ***********************************************************************
// <copyright file="RestClient.cs" company="CS.Common">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Net;
using System.Text;

namespace CS.Common.Helpers
{
    /// <summary>
    /// The http verb.
    /// </summary>
    public enum HttpVerb
    {
        /// <summary>
        /// The GET.
        /// </summary>
        GET,

        /// <summary>
        /// The POST.
        /// </summary>
        POST,

        /// <summary>
        /// The PUT.
        /// </summary>
        PUT,

        /// <summary>
        /// The DELETE.
        /// </summary>
        DELETE
    }

    /// <summary>
    /// The rest client.
    /// </summary>
    public class RestClient
    {
        /// <summary>
        /// Gets or sets the end point.
        /// </summary>
        /// <value>The end point.</value>
        public string EndPoint { get; set; }

        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        /// <value>The method.</value>
        public HttpVerb Method { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        /// <value>The type of the content.</value>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the post data.
        /// </summary>
        /// <value>The post data.</value>
        public string PostData { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RestClient" /> class.
        /// </summary>
        public RestClient()
        {
            EndPoint = string.Empty;
            Method = HttpVerb.GET;
            ContentType = "application/json";
            PostData = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RestClient" /> class.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        public RestClient(string endpoint)
        {
            EndPoint = endpoint;
            Method = HttpVerb.GET;
            ContentType = "application/json";
            PostData = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RestClient" /> class.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="method">The method.</param>
        public RestClient(string endpoint, HttpVerb method)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "application/json";
            PostData = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RestClient" /> class.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="method">The method.</param>
        /// <param name="postData">The post data.</param>
        public RestClient(string endpoint, HttpVerb method, string postData)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "application/json";
            PostData = postData;
        }

        /// <summary>
        /// The make request.
        /// </summary>
        /// <returns>The <see cref="string" />.</returns>
        public string MakeRequest()
        {
            return MakeRequest(string.Empty);
        }

        /// <summary>
        /// The make request.
        /// </summary>
        /// <param name="parameters">The parameters to add to Request service.</param>
        /// <returns>the string value of the request data</returns>
        /// <exception cref="ApplicationException"></exception>
        public string MakeRequest(string parameters)
        {
            var request = (HttpWebRequest)WebRequest.Create(EndPoint + parameters);

            request.Method = Method.ToString();
            request.ContentLength = 0;
            request.ContentType = ContentType;

            if (!string.IsNullOrEmpty(PostData) && Method == HttpVerb.POST)
            {
                var bytes = Encoding.UTF8.GetBytes(PostData);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = string.Empty;

                if (response.StatusCode != (HttpStatusCode.OK) && response.StatusCode != (HttpStatusCode.Created))
                {
                    var message = string.Format("Request failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }

                // grab the response
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                }

                return responseValue;
            }
        }
    }
}