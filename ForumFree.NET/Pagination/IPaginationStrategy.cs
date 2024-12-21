
namespace ForumFree.NET.Pagination
{
    internal interface IPaginationStrategy
    {
        public int GetPageNumber(int pageIndex);
    }
}
