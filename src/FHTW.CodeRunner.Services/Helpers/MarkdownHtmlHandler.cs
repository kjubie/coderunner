// <copyright file="MarkdownHtmlHandler.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using HtmlAgilityPack;

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
            HtmlCodeBlockHandler htmlCodeBlockHandler = new HtmlCodeBlockHandler();

            if (markdown == null)
            {
                return null;
            }

            string rawHtml = Markdig.Markdown.ToHtml(markdown);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(rawHtml);

            IEnumerable<HtmlNode> nodes = doc.DocumentNode.SelectNodes("//code[contains(@class, 'language')]");
            foreach (var node in nodes)
            {
                string lexer = null;

                foreach (var className in node.GetClasses())
                {
                    if (className.Contains("language-"))
                    {
                        lexer = className.Replace("language-", string.Empty);
                        break;
                    }
                }

                if (node.InnerHtml != null && lexer != null)
                {
                    string codeBlock = htmlCodeBlockHandler.CreateHtmlCodeBlock(node.InnerHtml, lexer);

                    if (codeBlock != null)
                    {
                        node.InnerHtml = codeBlock;
                    }
                }
            }

            string convertedHtml = doc.DocumentNode.OuterHtml;

            return new XCData(convertedHtml).ToString();
        }
    }
}
