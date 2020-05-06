namespace Blog.Core.Resources
{
    public interface IPageable
    {
        public int PageNr { get; set; }
        public int PageSize { get; set; }
    }
}