using System;
using System.Collections.Generic;
using System.Text;

namespace JokJaBre.Core.Objects
{

    public interface IJokJaBreRequest : IJokJaBreObject
    {
        void SetTo(IJokJaBreModel obj);
    }

    public abstract class JokJaBreRequest<TModel> : IJokJaBreRequest
        where TModel : IJokJaBreModel
    {
        public abstract void SetTo(TModel obj);
        public void SetTo(IJokJaBreModel obj)
        {
            if(obj is TModel model)
            {
                SetTo(model);
            }
        }
    }
}
