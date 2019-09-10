using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JokJaBre.Core.Extensions;
using JokJaBre.Core.Objects;
using Microsoft.EntityFrameworkCore;

namespace JokJaBre.Core.API
{
    public class JokJaBreService<TModel> : IJokJaBreService<TModel>
        where TModel : class, IJokJaBreModel
    {
        protected IJokJaBreRepository<TModel> m_repository;
        public JokJaBreService(IJokJaBreRepository<TModel> repository)
        {
            m_repository = repository;
        }

        public async Task<TResponse> Create<TRequest, TResponse>(TRequest request)
            where TRequest : IJokJaBreRequest
            where TResponse : IJokJaBreResponse
        {
            TModel model = request.ToModel<TRequest, TModel>();

            return (await m_repository.Create(model)).ToResponse<TResponse>();
        }

        public async Task<bool> Delete<TClass>(TClass key)
        {
            return await m_repository.Delete(key);
        }

        public IEnumerable<TResponse> GetAll<TResponse>(Func<DbSet<TModel>, IQueryable<TModel>> includes = null)
            where TResponse : IJokJaBreResponse
        {
            return m_repository.GetAll(includes).ToResponse<TModel, TResponse>();
        }

        public async Task<TResponse> GetById<TResponse, TClass>(TClass key, Func<DbSet<TModel>, IQueryable<TModel>> includes = null)
            where TResponse : IJokJaBreResponse
        {
            return (await m_repository.GetById(key, includes)).ToResponse<TResponse>();
        }
    }
}
