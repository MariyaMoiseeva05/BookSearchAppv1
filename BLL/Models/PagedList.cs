using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Models
{
    public class PagedList<T> : List <T>
    {
		public int CurrentPage { get; private set; }
		public int TotalPages { get; private set; }
		public int PageSize { get; private set; }
		public int TotalCount { get; private set; }

		public bool HasPrevious => CurrentPage > 1; // HasPrevious истинно, если CurrentPage больше 1
		public bool HasNext => CurrentPage < TotalPages; //HasNext вычисляется, если CurrentPage меньше общего количества страниц
		public PagedList(List<T> items, int count, int pageNumber, int pageSize)
		{
			TotalCount = count;
			PageSize = pageSize;
			CurrentPage = pageNumber;
			TotalPages = (int)Math.Ceiling(count / (double)pageSize); //вычисляется путем деления количества элементов на размер страницы и последующего округления до большего числа

			AddRange(items);
		}

		public static PagedList<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
		{
			var count = source.Count();
			var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

			return new PagedList<T>(items, count, pageNumber, pageSize);
		}
	}
}

