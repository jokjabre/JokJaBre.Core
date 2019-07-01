using JokJaBre.Core.Objects;
using Microsoft.AspNetCore.Mvc;

namespace JokJaBre.Core.Controller
{
    interface IJokJaBreController<TModel>
        where TModel : IJokJaBreModel
    {
        IActionResult GetAll<TResponse>() where TResponse : IJokJaBreResponse;
        IActionResult GetById<TResponse>(long id) where TResponse : IJokJaBreResponse;

        IActionResult Create(JokJaBreRequest<TModel> request);
    }
}
