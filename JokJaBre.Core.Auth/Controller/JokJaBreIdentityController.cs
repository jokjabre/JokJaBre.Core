using JokJaBre.Core.Auth.Objects;
using JokJaBre.Core.Controller;
using JokJaBre.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace JokJaBre.Core.Auth.Controller
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
