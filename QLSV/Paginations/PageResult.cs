using System;
using System.Net.NetworkInformation;

namespace QLSV.Paginations
{
	public class PageResult<T>
	{
        public List<T> Data { get; set; }

        public Pagination Pagination { get; set; }


        public PageResult(List<T> data, int pageNumber, int pageSize)
        {
            Data = data.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            Pagination = new Pagination(data.Count(), pageNumber, pageSize);
		}

	}
}

