// <copyright file="MarkdownHtmlHandler.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FHTW.CodeRunner.Services.Helpers
{
    /// <summary>
    /// Class that hadnles conversions between markdown and html.
    /// </summary>
    public class MarkdownHtmlHandler
    {
        /// <summary>
        /// Function that converts a html string to markdown.
        /// </summary>
        /// <param name="html">The html string.</param>
        /// <returns>The markdown string.</returns>
        public string HtmlToMarkdown(string html)
        {
            if (html == null)
            {
                return null;
            }

            var config = new ReverseMarkdown.Config
            {
                // Include the unknown tag completely in the result (default as well)
                UnknownTags = ReverseMarkdown.Config.UnknownTagsOption.PassThrough,

                // generate GitHub flavoured markdown, supported for BR, PRE and table tags
                GithubFlavored = true,

                // remove markdown output for links where appropriate
                SmartHrefHandling = true,
            };

            var converter = new ReverseMarkdown.Converter(config);

            string markdown = converter.Convert(html);

            return markdown;
        }

        /// <summary>
        /// Function that converts a markdown string to html.
        /// </summary>
        /// <param name="markdown">The markdown string.</param>
        /// <returns>The html string.</returns>
        public string MarkdownToHtml(string markdown)
        {
            if (markdown == null)
            {
                return null;
            }

            string html = Markdig.Markdown.ToHtml(markdown);

            return new XCData(html).ToString();
        }
    }
}
