using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq;

namespace Common.Web.TagHelpers
{
    [HtmlTargetElement("form", Attributes = ActionAttributeName)]
    [HtmlTargetElement("form", Attributes = AntiforgeryAttributeName)]
    [HtmlTargetElement("form", Attributes = AreaAttributeName)]
    [HtmlTargetElement("form", Attributes = FragmentAttributeName)]
    [HtmlTargetElement("form", Attributes = ControllerAttributeName)]
    [HtmlTargetElement("form", Attributes = RouteAttributeName)]
    [HtmlTargetElement("form", Attributes = RouteValuesDictionaryName)]
    [HtmlTargetElement("form", Attributes = IsAjaxAttributeName)]
    [HtmlTargetElement("form", Attributes = RouteValuesPrefix + "*")]
    public class FormTagHelperEx : FormTagHelper
    {
        private const string ActionAttributeName = "asp-action";
        private const string AntiforgeryAttributeName = "asp-antiforgery";
        private const string AreaAttributeName = "asp-area";
        private const string FragmentAttributeName = "asp-fragment";
        private const string ControllerAttributeName = "asp-controller";
        private const string RouteAttributeName = "asp-route";
        private const string RouteValuesDictionaryName = "asp-all-route-data";
        private const string RouteValuesPrefix = "asp-route-";
        private const string IsAjaxAttributeName = "asp-is-ajax";

        private const string ClassAttributeName = "class";
        private const string ClassAttributeAjaxValue = "ajax-load";

        [HtmlAttributeName(IsAjaxAttributeName)]
        public bool IsAjax { get; set; }

        public FormTagHelperEx(IHtmlGenerator generator) : base(generator)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (IsAjax)
            {
                if (output.Attributes.ContainsName(ClassAttributeName))
                {
                    var attr = output.Attributes.FirstOrDefault(i => i.Name == ClassAttributeName);
                    var classTag = new TagHelperAttribute(ClassAttributeName, $"{attr.Value} {ClassAttributeAjaxValue}");

                    output.Attributes.Remove(attr);
                    output.Attributes.Add(classTag);
                }
                else
                {
                    var classTag = new TagHelperAttribute(ClassAttributeName, ClassAttributeAjaxValue);
                    output.Attributes.Add(classTag);
                }
            }
        }
    }
}