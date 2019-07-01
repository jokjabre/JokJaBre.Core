using System;
using System.Collections.Generic;
using System.Text;

namespace JokJaBre.Core.Objects
{

    public interface IJokJaBreRequest : IJokJaBreObject
    {
        void SetTo(IJokJaBreModel obj);
    }

    public abstract class JokJaBreRequest<T> : IJokJaBreRequest
        where T : IJokJaBreModel
    {
        public abstract void SetTo(IJokJaBreModel obj);
    }
}
