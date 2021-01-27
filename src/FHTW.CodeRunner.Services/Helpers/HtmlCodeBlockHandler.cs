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
    public class HtmlCodeBlockHandler
    {
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
