using System.Collections.Generic;

namespace JokJaBre.Core.Objects
{
    public interface IJokJaBreCrudProvider<T> where T : IJokJaBreObject
    {
        IEnumerable<T> GetAll();
        T GetById(long id);

        T Create(T model);
    }

    public interface IJokJaBreCrudProvider<TIn, TOut> 
        where TIn : IJokJaBreObject
        where TOut : IJokJaBreObject
    {
        IEnumerable<TOut> GetAll();
        TOut GetById(long id);
        TOut Create(TIn obj);
    }
}
