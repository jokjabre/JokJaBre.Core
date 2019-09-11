using JokJaBre.Core.Objects;
using JokJaBre.Core.API;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JokJaBre.Core.API
{
    public abstract class JokJaBreController<TModel> : JokJaBreController<TModel, IJokJaBreService<TModel>>
        where TModel : class, IJokJaBreModel
    {
        public JokJaBreController(IJokJaBreService<TModel> service) : base(service)
        {
        }
    }

    public abstract class JokJaBreController<TModel, TService> : JokJaBreControllerBase
        where TModel : class, IJokJaBreModel
        where TService: class, IJokJaBreService<TModel>
    {
        protected TService m_service;
        protected Func<DbSet<TModel>, IQueryable<TModel>> m_defaultIncludes;
        public JokJaBreController(IJokJaBreService<TModel> service)
        {
            m_service = service as TService;

            //no includes
            m_defaultIncludes = i => i;
        }
    }
}
