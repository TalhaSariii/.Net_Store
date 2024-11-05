using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.Contracts;

namespace StoreApp.Infrastructe.TagHelpers
{
    public class LastestProductTagHelper : TagHelper
    {
        private readonly IServiceManager _manager;

        public LastestProductTagHelper(IServiceManager manager)
        {
            _manager=manager;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder div=new TagBuilder("div");
            div.Attributes.Add("class","my-3");

            TagBuilder h6=new TagBuilder("h6");
            h6.Attributes.Add("class","lead");

            TagBuilder icon=new TagBuilder("i");
            h6.Attributes.Add("class","fa fa-box text-secondary");

            h6.InnerHtml.AppendHtml(icon);
            h6.InnerHtml.AppendHtml("Lastest Products");
        }
    }
}