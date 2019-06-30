using JokJaBre.Core.Objects;
using Microsoft.AspNetCore.Mvc;

namespace JokJaBre.Core.Controller
{
    public interface IJokJaBreController<TModel, TRequest, TResponse>
        where TModel : JokJaBreModel
        where TRequest : JokJaBreRequest<TModel>
        where TResponse : JokJaBreResponse<TModel>
    {
        IActionResult GetAll();
        IActionResult GetById(long id);

        IActionResult Create(TRequest request);
    }
}
