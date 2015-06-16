using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Mvc.TagHelpers;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Microsoft.Framework.WebEncoders;

namespace baymax.TagHelpers
{
    [TargetElement("asp-prettify")]
    public class PrettifyTagHelper : TagHelper
    {
        [Activate]
        protected internal ViewContext Context { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            var tagBuilder = new TagBuilder("pre");

            tagBuilder.AddCssClass("prettyprint");

            var childContent = await context.GetChildContentAsync();
            tagBuilder.InnerHtml = childContent.GetContent();

            output.TagName = "pre";
            output.MergeAttributes(tagBuilder);
            output.Content.SetContent(HtmlEncoder.Default.HtmlEncode(childContent.GetContent()));

        }
    }
}