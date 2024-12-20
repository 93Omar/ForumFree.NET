namespace ForumFree.NET.Pagination
{
    internal class FifteenMultiplePaginationStrategy : IPaginationStrategy
    {
        public int GetPageNumber(int pageIndex)
        {
            if (pageIndex == 1)
                return 0;

            return (pageIndex - 1) * 15;
        }
    }
}
