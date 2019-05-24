using DotNetCore.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCore.Objects
{
    public class PagedList<T>
    {
        public PagedList(IQueryable<T> queryable, PagedListParameters parameters)
        {
            if (queryable == default || parameters == default)
            {
                return;
            }

            Count = queryable.LongCount();

            if (parameters.Order != default)
            {
                queryable = queryable.Order(parameters.Order.Property, parameters.Order.Ascending);
            }

            if (parameters.Page != default)
            {
                queryable = queryable.Page(parameters.Page.Index, parameters.Page.Size);
            }

            List = queryable.AsEnumerable();
        }

        public long Count { get; }

        public IEnumerable<T> List { get; }
    }
}
