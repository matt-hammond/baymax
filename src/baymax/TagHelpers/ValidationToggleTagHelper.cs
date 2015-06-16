using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ModelBinding;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Mvc.TagHelpers;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace baymax.TagHelpers
{
    [TargetElement("div", Attributes = ValidationAttributeName)]
    public class ValidationToggleTagHelper : TagHelper
    {
        private const string ValidationAttributeName = "asp-validation-toggle";

        [Activate]
        protected internal ViewContext Context { get; set; }

        internal static string GetFullHtmlFieldName(ViewContext viewContext, string expression)
        {
            var fullName = viewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expression);
            return fullName;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var formContext = Context.ClientValidationEnabled ? Context.FormContext : null;
            if (Context.ViewData.ModelState.IsValid)
            {
                output.SuppressOutput();
            }



        }
    }
}