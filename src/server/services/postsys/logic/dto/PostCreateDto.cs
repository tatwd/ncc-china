using System;
using Ncc.China.Services.Postsys.Data;

namespace Ncc.China.Services.Postsys.Logic.Dto
{
    public class PostCreateDto
    {
        public string CategoryId { get; set; }
        public string Title { get; set; }
        public Owner Author { get; set; }
        public string AbstractText { get; set; } = string.Empty;
        public string HtmlText { get; set; }
        public string[] Tags { get; set; }
    }
}
