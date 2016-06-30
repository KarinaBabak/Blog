using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Blog.Models;
using System.Text;

namespace Blog.Helpers
{
    public static class PageHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PageInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            if (pageInfo.TotalPages > 1)
            {
                for (int i = 1; i <= pageInfo.TotalPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.MergeAttribute("href", pageUrl(i));
                    tag.InnerHtml = i.ToString();

                    if (i == pageInfo.PageNumber)
                    {
                        tag.AddCssClass("now");
                    }
                    result.Append(tag.ToString());
                }
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}