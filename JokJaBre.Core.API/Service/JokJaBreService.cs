using System.Collections.Generic;
using System.Threading.Tasks;
using JokJaBre.Core.Extensions;
using JokJaBre.Core.Objects;

namespace JokJaBre.Core.API
{
    public class JokJaBreService<TModel> : IJokJaBreService<TModel>
        where TModel : IJokJaBreModel
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

        public IEnumerable<TResponse> GetAll<TResponse>()
            where TResponse : IJokJaBreResponse
        {
            return m_repository.GetAll().ToResponse<TModel, TResponse>();
        }

        public async Task<TResponse> GetById<TResponse, TClass>(TClass key)
            where TResponse : IJokJaBreResponse
        {
            return (await m_repository.GetById(key)).ToResponse<TResponse>();
        }
    }
}
