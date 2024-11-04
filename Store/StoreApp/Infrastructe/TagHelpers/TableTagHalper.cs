using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StoreApp.Infrastructe.TagHelpers
{
    [HtmlTargetElement("table")]
    public class TagHelpers :TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class","table table-hover");
        }
    }
}