using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace LectureRoomMgt.ClassFiles
{
    public class ScriptTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            var js = (await output.GetChildContentAsync()).GetContent();
            if (!string.IsNullOrWhiteSpace(js))
            {
                var minifiedJs = JSMinifier.MinifyJs(js);
                output.Content.SetHtmlContent(minifiedJs);
            }
        }
    }

}
