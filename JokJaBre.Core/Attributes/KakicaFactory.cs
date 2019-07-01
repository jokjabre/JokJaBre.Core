using JokJaBre.Core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JokJaBre.Core.Attributes
{
    public  static class KakicaFactory
    {
        public static object Response<T>(T model) where T : IJokJaBreModel
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            var attributes = typeof(T).GetCustomAttributes(true)
                .Where(a => a is ShownAttribute)
                .Select(s => s as ShownAttribute)
                .Where(i => i.ShownIn == Dto.Both || i.ShownIn == Dto.Response);

            foreach (var attr in attributes)
            {
                var obj = model.GetType().GetProperty(attr.PositionalString);
                result.Add(attr.PositionalString, obj.GetValue(model));
            }

            return result;
        }
    }
}
