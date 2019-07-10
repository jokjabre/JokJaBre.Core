using Microsoft.Extensions.Configuration;
using JokJaBre.Core.Exceptions;

namespace JokJaBre.Core.Identity
{
    public class JokJaBreIdentityService<TIdentityModel> : IJokJaBreIdentityService<TIdentityModel>
        where TIdentityModel : IJokJaBreIdentityModel
    {
        protected IJokJaBreIdentityRepository<TIdentityModel> m_repository;
        protected IConfiguration m_configuration;

        public JokJaBreIdentityService(IJokJaBreIdentityRepository<TIdentityModel> repository, IConfiguration configuration)
        {
            m_repository = repository;
            m_configuration = configuration;
        }

        public TResponse Login<TRequest, TResponse>(TRequest request)
            where TRequest : IJokJaBreIdentityRequest
            where TResponse : IJokJaBreIdentityResponse
        {
            var model = request.ToIdentityModel<TRequest, TIdentityModel>(m_configuration);
            var user = m_repository.Get(model);
            if (user == null) throw ApiExceptions.NotFound("Username, email or password are not correct");

            return user.ToIdentityResponse<TResponse>(m_configuration);
        }

        public TResponse Register<TRequest, TResponse>(TRequest request)
            where TRequest : IJokJaBreIdentityRequest
            where TResponse : IJokJaBreIdentityResponse
        {
            TIdentityModel model = request.ToIdentityModel<TRequest, TIdentityModel>(m_configuration);

            return m_repository.Create(model).ToIdentityResponse<TResponse>(m_configuration);
        }

        public bool EmailAvaiilable(string email)
        {
            return m_repository.EmailAvaiilable(email);
        }


        public bool UsernameAvailable(string username)
        {
            return m_repository.UsernameAvailable(username);
        }
    }
}
