namespace Ncc.China.Services.Postsys.Logic.Dto
{
    public class PostPaginateByCategoryDto
    {
        public int Page { get; set; }
        public int Limit { get; set; }
        public string Category { get; set; }
        public bool Desc { get; set; }

        public bool IsValid
        {
            get
            {
                return Page != 0 && Limit != 0 && !string.IsNullOrEmpty(Category);
            }
        }
    }
}
