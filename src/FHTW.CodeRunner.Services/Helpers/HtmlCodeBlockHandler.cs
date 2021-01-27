// <copyright file="HtmlCodeBlockHandler.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Logging;

namespace FHTW.CodeRunner.Services.Helpers
{
    /// <summary>
    /// Handler for the styling and creation od html code blocks.
    /// </summary>
    public class HtmlCodeBlockHandler
    {
        /// <summary>
        /// Function for creating the html code block.
        /// </summary>
        /// <param name="codeString">The unstyled html code string.</param>
        /// <param name="lexer">The lexer for the correct styling (https://pygments.org/docs/lexers/).</param>
        /// <returns>The formatted code block.</returns>
        public string CreateHtmlCodeBlock(string codeString, string lexer)
        {
            string baseUrl = @"http://hilite.me/api";
            UriBuilder uriBuilder = new UriBuilder(baseUrl);
            System.Collections.Specialized.NameValueCollection query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["code"] = codeString;
            query["lexer"] = lexer;
            uriBuilder.Query = query.ToString();
            string osmParams = uriBuilder.ToString();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();

                HttpResponseMessage res = client.GetAsync(osmParams).GetAwaiter().GetResult();

                if (res.IsSuccessStatusCode)
                {
                    string objResponse = res.Content.ReadAsStringAsync().Result;
                    return objResponse;
                }
                else
                {
                    return codeString;
                }
            }
        }
    }
}
