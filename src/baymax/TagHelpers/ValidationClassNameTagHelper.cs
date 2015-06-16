using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ModelBinding;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Mvc.TagHelpers;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace baymax.TagHelpers
{
    [TargetElement("div", Attributes = ValidationForAttributeName)]
    public class ValidationClassNameTagHelper : TagHelper
    {
        private const string ValidationForAttributeName = "asp-validation-add-class-for";
        private const string ClassNameAttributeName = "asp-validation-class-name";

        [HtmlAttributeName(ValidationForAttributeName)]
        public ModelExpression For { get; set; }

        [HtmlAttributeName(ClassNameAttributeName)]
        public string ClassName { get; set; }

        [Activate]
        protected internal ViewContext Context { get; set; }

        internal static string GetFullHtmlFieldName(ViewContext viewContext, string expression)
        {
            var fullName = viewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expression);
            return fullName;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var fullName = GetFullHtmlFieldName(Context, For.Name);
            if (string.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException();
            }

            var formContext = Context.ClientValidationEnabled ? Context.FormContext : null;
            if (!Context.ViewData.ModelState.ContainsKey(fullName) && formContext == null)
            {
                return;
            }

            ModelState modelState;
            var tryGetModelStateResult = Context.ViewData.ModelState.TryGetValue(fullName, out modelState);
            var modelErrors = tryGetModelStateResult ? modelState.Errors : null;

            ModelError modelError = null;
            if (modelErrors != null && modelErrors.Count != 0)
            {
                modelError = modelErrors.FirstOrDefault(m => !string.IsNullOrEmpty(m.ErrorMessage)) ?? modelErrors[0];
            }

            if (modelError != null)
            {
                var tag = Context.ValidationMessageElement;

                var tagBuilder = new TagBuilder(tag);

                tagBuilder.AddCssClass(ClassName);
                var childContent = await context.GetChildContentAsync();
                output.Content.SetContent(childContent);

                output.MergeAttributes(tagBuilder);
            }


        }
    }
}


