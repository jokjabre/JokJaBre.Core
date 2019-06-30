using JokJaBre.Core.Objects;
using JokJaBre.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JokJaBre.Core.Controller
{
    public class JokJaBreController<TModel, TRequest, TResponse> : ControllerBase, IJokJaBreController<TModel, TRequest, TResponse>
        where TModel : JokJaBreModel
        where TRequest : JokJaBreRequest<TModel>
        where TResponse : JokJaBreResponse<TModel>
    {
        protected IJokJaBreService<TModel, TRequest, TResponse> m_service;
        public JokJaBreController(IJokJaBreService<TModel, TRequest, TResponse> service)
        {
            m_service = service;
        }

        public IActionResult Create(TRequest request)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetAll()
        {
            return Ok(m_service.GetAll());
        }

        public IActionResult GetById(long id)
        {
            return Ok(m_service.GetById(id));
        }
    }
}
