using JokJaBre.Core.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace JokJaBre.Core.Extensions
{
    public static class JokJaBreConversionExtensions
    {
        public static TResponse ToResponse<TResponse>(this IJokJaBreModel model) 
            where TResponse : IJokJaBreResponse
        {
            if (model == null) return default;

            var response = Activator.CreateInstance<TResponse>();
            model.CopyTo(response);
            response.SetFrom(model);

            return response;
        }

        public static IEnumerable<TResponse> ToResponse<TModel, TResponse>(this IEnumerable<TModel> models)
            where TModel : IJokJaBreModel
            where TResponse : IJokJaBreResponse
        {
            return models?.Select(model => model.ToResponse<TResponse>());
        }

        public static TModel ToModel<TRequest, TModel>(this TRequest request)
            where TRequest : IJokJaBreRequest
            where TModel : IJokJaBreModel
        {
            if (request == null) return default;

            var model = (TModel)Activator.CreateInstance(typeof(TModel));
            request.CopyTo(model);
            request.SetTo(model);

            return model;
        }

        public static IEnumerable<TModel> ToModel<TRequest, TModel>(this IEnumerable<TRequest> requests)
            where TRequest : IJokJaBreRequest
            where TModel : IJokJaBreModel
        {
            return requests?.Select(request => request.ToModel<TRequest, TModel>());
        }

        public static void CopyTo(this object source, object destination)
        {
            var sourceProps = source.GetType().GetProperties();
            var destType = destination.GetType();
            foreach (var prop in sourceProps)
            {
                var destProp = destType.GetProperty(prop.Name);
                if (destProp == null) continue;

                //conditions
                bool assignable = prop.PropertyType.IsAssignableFrom(destProp.PropertyType);
                bool sameGenArgs = prop.PropertyType.GetGenericArguments().SequenceEqual(destProp.PropertyType.GetGenericArguments());
                if (!assignable || !sameGenArgs) continue;

                destProp?.SetValue(destination, prop.GetValue(source));
            }
        }
    }
}
