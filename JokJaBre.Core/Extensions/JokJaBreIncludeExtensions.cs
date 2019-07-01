using JokJaBre.Core.Objects;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace JokJaBre.Core.Extensions
{
    public static class JokJaBreIncludeExtensions
    {

        public static IQueryable<TResult> SelectEx<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector)
            where TResult : IJokJaBreModel
        {
            return source.Select(selector);
        }
    }
}
