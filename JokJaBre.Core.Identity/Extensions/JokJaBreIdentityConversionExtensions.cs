using JokJaBre.Core.Extensions;
using Microsoft.Extensions.Configuration;
using System;

namespace JokJaBre.Core.Identity
{
    public static class JokJaBreIdentityConversionExtensions
    {
        public static TResponse ToIdentityResponse<TResponse>(this IJokJaBreIdentityModel model, IConfiguration configuration)
           where TResponse : IJokJaBreIdentityResponse
        {
            if (model == null) return default;

            var response = (TResponse)Activator.CreateInstance(typeof(TResponse));
            model.CopyTo(response);
            response.Token = model.GetToken(configuration);

            response.SetFrom(model);

            return response;
        }


        public static TModel ToIdentityModel<TRequest, TModel>(this TRequest request, IConfiguration configuration)
            where TRequest : IJokJaBreIdentityRequest
            where TModel : IJokJaBreIdentityModel
        {
            if (request == null) return default;

            var model = (TModel)Activator.CreateInstance(typeof(TModel));
            request.CopyTo(model);
            model.HashPassword(configuration);

            request.SetTo(model);

            return model;
        }

    }
}
