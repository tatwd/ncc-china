namespace Ncc.China.Services.Postsys.Logic.Dto
{
    public class PostPaginateByCategoryDto
    {
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 20;
        public string Category { get; set; } = "all";
        public bool Desc { get; set; } = true;

        public bool IsValid
        {
            get
            {
                return Page != 0 && Limit != 0 && !string.IsNullOrEmpty(Category);
            }
        }
    }
}
