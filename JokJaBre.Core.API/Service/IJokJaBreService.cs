using JokJaBre.Core.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JokJaBre.Core.API
{
    public interface IJokJaBreService<TModel> 
        where TModel : IJokJaBreModel
    {

        IEnumerable<TResponse> GetAll<TResponse>() 
            where TResponse : IJokJaBreResponse;

        Task<TResponse> GetById<TResponse, TClass>(TClass key) 
            where TResponse : IJokJaBreResponse;

        Task<TResponse> Create<TRequest, TResponse>(TRequest obj)
            where TRequest : IJokJaBreRequest
            where TResponse : IJokJaBreResponse;

        Task<bool> Delete<TClass>(TClass key);
    }
}
