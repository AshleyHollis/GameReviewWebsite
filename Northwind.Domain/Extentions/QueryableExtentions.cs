using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Northwind.Domain.Entities;

namespace Northwind.Domain.Extentions
{
    public static class QueryableExtentions
    {
        public static IQueryable<T> Sort<T>(this IQueryable<T> source, string sortBy)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (string.IsNullOrEmpty(sortBy))
                throw new ArgumentNullException(nameof(sortBy));

            return source.OrderBy(sortBy);
        }
    }

    public static class ListExtentions
    {
        public static List<T> Sort<T>(this IList<T> source, string sortBy)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (string.IsNullOrEmpty(sortBy))
                throw new ArgumentNullException(nameof(sortBy));

            return source.AsQueryable().OrderBy(sortBy).ToList();
        }
    }
}