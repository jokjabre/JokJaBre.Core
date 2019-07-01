using JokJaBre.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JokJaBre.Core.Extensions
{
    public static class JokJaBreConversionExtensions
    {
        public static TResponse ToResponse<TResponse>(this IJokJaBreModel model) 
            where TResponse : IJokJaBreResponse
        {
            var response = (TResponse)Activator.CreateInstance(typeof(TResponse));
            model.CopyTo(response);
            response.SetFrom(model);

            return response;
        }

        public static IEnumerable<TResponse> ToResponse<TModel, TResponse>(this IEnumerable<TModel> models)
            where TModel : IJokJaBreModel
            where TResponse : IJokJaBreResponse
        {
            return models.Select(model => model.ToResponse<TResponse>());
        }

        public static TModel ToModel<TRequest, TModel>(this TRequest request)
            where TRequest : IJokJaBreRequest
            where TModel : IJokJaBreModel
        {
            var model = (TModel)Activator.CreateInstance(typeof(TModel));
            request.CopyTo(model);
            request.SetTo(model);

            return model;
        }

        public static IEnumerable<TModel> ToModel<TRequest, TModel>(this IEnumerable<TRequest> models)
            where TRequest : IJokJaBreRequest
            where TModel : IJokJaBreModel
        {
            return models.Select(model => model.ToModel<TRequest, TModel>());
        }


        public static void CopyTo<TSource, TDestination>(this TSource source, TDestination destination)
            where TSource : IJokJaBreObject
            where TDestination : IJokJaBreObject
        {
            var sourceProps = source.GetType().GetProperties();
            var destType = destination.GetType();
            foreach (var prop in sourceProps)
            {
                var destProp = destType.GetProperty(prop.Name);
                destProp?.SetValue(destination, prop.GetValue(source));
            }
        }
    }
}
