using JokJaBre.Core.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace JokJaBre.Core.Service
{
    public interface IJokJaBreService<TModel> 
        where TModel : IJokJaBreModel
    {

        IEnumerable<TResponse> GetAll<TResponse>() where TResponse : IJokJaBreResponse;
        TResponse GetById<TResponse, TClass>(TClass key) where TResponse : IJokJaBreResponse;
        TResponse Create<TRequest, TResponse>(TRequest obj)
            where TRequest : IJokJaBreRequest
            where TResponse : IJokJaBreResponse;
    }
}
