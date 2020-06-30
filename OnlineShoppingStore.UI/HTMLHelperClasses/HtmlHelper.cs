using OnlineShoppingStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.UI.HTMLHelperClasses
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper htmlHelper,
            PagingInfo pagingInfo, Func<int, string> getPageURL)
        {
            StringBuilder resultMVCHtmlString = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", getPageURL(i));
                tag.InnerHtml = i.ToString() + "  ";

                resultMVCHtmlString.Append(tag.ToString());
            }
            return MvcHtmlString.Create(resultMVCHtmlString.ToString());
        }
    }
}