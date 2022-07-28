using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DJT.EntityFrameworkCore
{
    /// <summary>
    /// Extension methods to be applied to <see cref="IQueryable{T}"/>
    /// </summary>
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Applies a predicate expression to filter the query as long
        /// as condition evaluates to true
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="qry"></param>
        /// <param name="condition">If true, the predicate expression will be applied</param>
        /// <param name="predicate">The predicate expression to apply if condition is true</param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> qry, bool condition, Expression<Func<T, bool>> predicate)
        {
            if (condition)
                qry = qry.Where(predicate);
            return qry;
        }

        /// <summary>
        /// Outputs the number of items in the input query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="qry">The original query to count from</param>
        /// <param name="total">Outputs the number of items</param>
        /// <returns></returns>
        public static IQueryable<T> Total<T>(this IQueryable<T> qry, out int total)
        {
            total = qry.Count();
            return qry;
        }
    }
}
