using JokJaBre.Core.Objects;
using JokJaBre.Core.API;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JokJaBre.Core.API
{
    public abstract class JokJaBreController<TModel> : JokJaBreControllerBase
        where TModel : IJokJaBreModel
    {
        protected IJokJaBreService<TModel> m_service;
        public JokJaBreController(IJokJaBreService<TModel> service)
        {
            m_service = service;
        }
    }
}
