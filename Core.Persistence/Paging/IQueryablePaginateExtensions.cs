using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Core.Persistence.Paging;
//Gelen datayı sayfalalı halde getirmek için

//Extension classı static olmalıdır.
public static class IQueryablePaginateExtensions
{
        //asynchronous version
        public static async Task<Paginate<T>> ToPaginateAsync<T>(this IQueryable<T> source,int index, int size,
        CancellationToken cancellationToken= default)// cancellation token async 
        {
                int count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
                List<T> items = await source.Skip((index) * size)
                    .Take(size)
                    .ToListAsync(cancellationToken)
                    .ConfigureAwait(false);
                Paginate<T> list = new Paginate<T>();
                list.Index = index;
                list.Size = size;
                list.Count = count;
                list.Items = items;
                list.Pages = (int)Math.Ceiling(count / (double)size);
                return list;

        }
        
        //non-asynchronous version
        public static Paginate<T> ToPaginate<T>(this IQueryable<T> source,int index,int size) 
        {
            int count =  source.Count();
            List<T> items =  source.Skip((index) * size).ToList();
            
            Paginate<T> list = new Paginate<T>();
            list.Index = index;
            list.Size = size;
            list.Count = count;
            list.Items = items;
            list.Pages = (int)Math.Ceiling(count / (double)size);
            return list;

        }
}