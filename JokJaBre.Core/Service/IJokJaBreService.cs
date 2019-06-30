using JokJaBre.Core.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace JokJaBre.Core.Service
{
    public interface IJokJaBreService<TModel, TRequest, TResponse> : IJokJaBreCrudProvider<JokJaBreRequest<TModel>, JokJaBreResponse<TModel>>
        where TModel : JokJaBreModel
        where TRequest : JokJaBreRequest<TModel>
        where TResponse : JokJaBreResponse<TModel>
    {
    }
}
