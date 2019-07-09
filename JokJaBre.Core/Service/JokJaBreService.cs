
using System;
using System.Collections.Generic;
using System.Text;
using JokJaBre.Core.Extensions;
using JokJaBre.Core.Service;
using JokJaBre.Core.Repository;
using JokJaBre.Core.Objects;

namespace JokJaBre.Core.Service
{
    public class JokJaBreService<TModel> : IJokJaBreService<TModel>
        where TModel : IJokJaBreModel
    {
        protected IJokJaBreRepository<TModel> m_repository;
        public JokJaBreService(IJokJaBreRepository<TModel> repository)
        {
            m_repository = repository;
        }

        public TResponse Create<TRequest, TResponse>(TRequest request)
            where TRequest : IJokJaBreRequest
            where TResponse : IJokJaBreResponse
        {
            TModel model = request.ToModel<TRequest, TModel>();

            return m_repository.Create(model).ToResponse<TResponse>();
        }

        public IEnumerable<TResponse> GetAll<TResponse>()
            where TResponse : IJokJaBreResponse
        {
            return m_repository.GetAll().ToResponse<TModel, TResponse>();
        }

        public TResponse GetById<TResponse, TClass>(TClass key)
            where TResponse : IJokJaBreResponse
        {
            return m_repository.GetById(key).ToResponse<TResponse>();
        }
    }
}
