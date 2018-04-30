using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDemo01.TagHelpers
{
    public class EmailTagHelper: TagHelper
    {
        public string DireccionEDestino { get; set; }
        public string DetalleMensaje { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:" + DireccionEDestino);
            output.Content.SetContent(DetalleMensaje);
        }

    }
}
