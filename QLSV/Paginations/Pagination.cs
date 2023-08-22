using System;
namespace QLSV.Paginations
{
	public class Pagination
	{
		public int CurentPage { get; private set; }

        public int PageSize { get; private set; }

		public int TotalPages { get; private set; }

        public int TotalCount { get; private set; }

        public bool HasPrevious => CurentPage > 1;

		public bool HasNext => CurentPage < TotalPages;

        public Pagination(int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            CurentPage = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
    }
}

