using JokJaBre.Core.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokJaBre.Core.API
{
    public interface IJokJaBreRepository<TModel>
        where TModel : class, IJokJaBreModel
    {
        IEnumerable<TModel> GetAll(Func<DbSet<TModel>, IQueryable<TModel>> includes = null);
        Task<TModel> GetById<TClass>(TClass key, Func<DbSet<TModel>, IQueryable<TModel>> includes = null, bool shouldThrow = true);

        Task<TModel> Create(TModel model);
        Task<bool> Delete<TClass>(TClass key);

        Task<bool> SaveChanges();
    }
}
