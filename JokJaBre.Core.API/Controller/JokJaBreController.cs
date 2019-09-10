using JokJaBre.Core.Objects;
using JokJaBre.Core.API;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JokJaBre.Core.API
{
    public abstract class JokJaBreController<TModel> : JokJaBreControllerBase
        where TModel : class, IJokJaBreModel
    {
        protected IJokJaBreService<TModel> m_service;
        protected Func<DbSet<TModel>, IQueryable<TModel>> m_defaultIncludes;
        public JokJaBreController(IJokJaBreService<TModel> service)
        {
            m_service = service;

            //no includes
            m_defaultIncludes = i => i;
        }
    }
}
