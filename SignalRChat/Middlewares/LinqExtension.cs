using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Middlewares
{
    public static class LinqExtension
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query,bool condition,Func<T, bool> predicate)
        {
            List<T> returnData = new List<T>();

            if (condition)
            {
                foreach (var item in query)
                {
                    if (predicate(item))
                    {
                        returnData.Add(item);
                    }
                }
            }
            else
            {
                returnData.AddRange(query.ToList());
            }
            return returnData.AsQueryable();
        }
    }
}
