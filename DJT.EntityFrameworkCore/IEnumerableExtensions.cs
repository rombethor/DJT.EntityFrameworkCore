using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJT.EntityFrameworkCore
{
    /// <summary>
    /// Extension methods which apply to <see cref="IEnumerable{T}"/>
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Applys the predicate where clause to the input query as long as 
        /// the condition evaluates to true
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="qry">The original query</param>
        /// <param name="condition">If true, the predicate function is applied</param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> qry, bool condition, Func<T, bool> predicate)
        {
            if (condition)
                qry = qry.Where(predicate);
            return qry;
        }

        /// <summary>
        /// Outputs the total number of items in the enumerable collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="qry">The enumerable collection</param>
        /// <param name="total">The count of items</param>
        /// <returns></returns>
        public static IEnumerable<T> Total<T>(this IEnumerable<T> qry, out int total)
        {
            total = qry.Count();
            return qry;
        }
    }
}
