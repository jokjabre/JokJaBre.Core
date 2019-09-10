using JokJaBre.Core.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokJaBre.Core.API
{
    public interface IJokJaBreService<TModel> 
        where TModel : class, IJokJaBreModel
    {

        IEnumerable<TResponse> GetAll<TResponse>(Func<DbSet<TModel>, IQueryable<TModel>> includes = null) 
            where TResponse : IJokJaBreResponse;

        Task<TResponse> GetById<TResponse, TClass>(TClass key, Func<DbSet<TModel>, IQueryable<TModel>> includes = null) 
            where TResponse : IJokJaBreResponse;

        Task<TResponse> Create<TRequest, TResponse>(TRequest obj)
            where TRequest : IJokJaBreRequest
            where TResponse : IJokJaBreResponse;

        Task<bool> Delete<TClass>(TClass key);
    }
}
