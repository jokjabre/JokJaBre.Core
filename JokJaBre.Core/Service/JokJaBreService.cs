using System;
using System.Collections.Generic;
using System.Text;
using JokJaBre.Core.Extensions;
using JokJaBre.Core.Service;
using JokJaBre.Core.Repository;

namespace JokJaBre.Core.Objects.Service
{
    public class JokJaBreService<TModel, TRequest, TResponse> : IJokJaBreService<TModel, TRequest, TResponse>
        where TModel : JokJaBreModel
        where TRequest : JokJaBreRequest<TModel>
        where TResponse : JokJaBreResponse<TModel>
    {
        protected IJokJaBreRepository<TModel> m_repository;
        public JokJaBreService(IJokJaBreRepository<TModel> repository)
        {
            m_repository = repository;
        }

        public JokJaBreResponse<TModel> Create(JokJaBreRequest<TModel> request)
        {
            TModel model = request.ToModel();

            return m_repository.Create(model).ToResponse();
        }

        public IEnumerable<JokJaBreResponse<TModel>> GetAll()
        {
            return m_repository.GetAll().ToResponse();
        }

        public JokJaBreResponse<TModel> GetById(long id)
        {
            return m_repository.GetById(id).ToResponse();
        }
    }
}
