using JokJaBre.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JokJaBre.Core.Extensions
{
    public static class JokJaBreConversionExtensions
    {
        public static JokJaBreResponse<TModel> ToResponse<TModel>(this TModel model) 
            where TModel : JokJaBreModel
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<JokJaBreResponse<TModel>> ToResponse<TModel>(this IEnumerable<TModel> models) 
            where TModel : JokJaBreModel
        {
            return models.Select(model => model.ToResponse());
        }

        public static TModel ToModel<TModel>(this JokJaBreRequest<TModel> model)
            where TModel : JokJaBreModel
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<TModel> ToModel<TModel>(this IEnumerable<JokJaBreRequest<TModel>> models)
            where TModel : JokJaBreModel
        {
            return models.Select(model => model.ToModel());
        }
    }
}
