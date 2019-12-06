using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelReserve.Classes
{
    public static class HtmlExtensions
    {

        /// <summary>
        /// 自定义一个@html.Submit()
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="value">value属性</param>
        /// <returns></returns>
        /// 

        //首先，要用TagBuilder就要引入System.Web.Mvc类库。
        //接着我们看这个函数的参数，this HtmlHelper helper保证这个方法会被添加到HtmlHelper中，string value对应将来的提交按钮显示的文字，也就是value属性。
        //var builder = new TagBuilder("input"); 使我们创建的标签名字设为input。
        //MergeAttribute函数给创建出的元素添加属性，如MergeAttribute("type", "submit") 就是加入 type = "submit" 属性。
        //TagRenderMode.SelfClosing使生成的标签自我关闭，也就是说有<input /> 这种形式。
        //最后用MvcHtmlString作为返回值是为了使返回值不被转义，比如"<"不会被转成"&lt"。这是我们不想看到的。
        public static MvcHtmlString Submit(this HtmlHelper helper, string value)
        {
            var builder = new TagBuilder("input");
            builder.MergeAttribute("type", "submit");
            builder.MergeAttribute("value", value);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

    }
}
