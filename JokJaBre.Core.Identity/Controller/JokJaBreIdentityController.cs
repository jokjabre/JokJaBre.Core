using JokJaBre.Core.Controller;
using Microsoft.AspNetCore.Mvc;

namespace JokJaBre.Core.Identity
{
    public class JokJaBreIdentityController<TIdentityModel, TRequest, TResponse> : JokJaBreControllerBase
        where TIdentityModel : IJokJaBreIdentityModel
        where TRequest : IJokJaBreIdentityRequest
        where TResponse : IJokJaBreIdentityResponse
    {
        protected readonly IJokJaBreIdentityService<TIdentityModel> m_service;
        public JokJaBreIdentityController(IJokJaBreIdentityService<TIdentityModel> service)
        {
            m_service = service;
        }

        protected IActionResult RegisterBase(TRequest request)
        {
            return CheckState(m_service.Register<TRequest, TResponse>(request));
        }

        protected IActionResult LoginBase(TRequest request)
        {
            return CheckState(m_service.Login<TRequest, TResponse>(request));
        }
    }
}
