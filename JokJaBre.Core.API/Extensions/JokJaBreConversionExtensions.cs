using JokJaBre.Core.API.Attributes;
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
            return models.Select(model => model.ToResponse<TResponse>());
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

        public static IEnumerable<TModel> ToModel<TRequest, TModel>(this IEnumerable<TRequest> models)
            where TRequest : IJokJaBreRequest
            where TModel : IJokJaBreModel
        {
            return models.Select(model => model.ToModel<TRequest, TModel>());
        }


        //public static void CopyTo<TSource, TDestination>(this TSource source, TDestination destination)
        //    where TSource : IJokJaBreObject
        //    where TDestination : IJokJaBreObject
        //{
        //    var sourceProps = source.GetType().GetProperties();
        //    var destType = destination.GetType();
        //    foreach (var prop in sourceProps)
        //    {
        //        var destProp = destType.GetProperty(prop.Name);
        //        if (destProp == null) continue;

        //        //collection mapping
        //        var customAttr = destProp.GetCustomAttributes(true)
        //            .FirstOrDefault(a => a is MapAsCollectionAttribute) as MapAsCollectionAttribute;
        //        if (customAttr != null)
        //        {
        //            var collection = prop.GetValue(source) as IEnumerable;
        //            var genericArg = destProp.PropertyType.GetGenericArguments().FirstOrDefault();
        //            if (genericArg == null) continue;

        //            destProp?.SetValue(destination, ConvertCollection(collection, genericArg).ToList());

        //            continue;
        //        }

        //        //property mapping
        //        if (!prop.PropertyType.IsAssignableFrom(destProp.PropertyType)) continue;
        //        destProp?.SetValue(destination, prop.GetValue(source));
        //    }
        //}

        public static void CopyTo(this object source, object destination)
        {
            var sourceProps = source.GetType().GetProperties();
            var destType = destination.GetType();
            foreach (var prop in sourceProps)
            {
                var destProp = destType.GetProperty(prop.Name);
                if (destProp == null) continue;

                //collection mapping
                var customAttr = destProp.GetCustomAttributes(true).OfType<MapAsCollectionAttribute>().FirstOrDefault();
                if (customAttr != null)
                {
                    var collection = prop.GetValue(source) as IEnumerable;
                    var genericArg = destProp.PropertyType.GetGenericArguments().FirstOrDefault();
                    if (genericArg == null) continue;

                    destProp?.SetValue(destination, ConvertCollection(collection, genericArg).AsQueryable());

                    continue;
                }

                //property mapping
                if (!prop.PropertyType.IsAssignableFrom(destProp.PropertyType)) continue;
                destProp?.SetValue(destination, prop.GetValue(source));
            }
        }


        private static IEnumerable ConvertCollection(IEnumerable source, Type destType)
        {
            foreach(var model in source)
            {
                var dest = Activator.CreateInstance(destType);
                model.CopyTo(dest);
                yield return dest;
            }
        }
    }
}
