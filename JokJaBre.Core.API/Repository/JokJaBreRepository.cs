using JokJaBre.Core.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokJaBre.Core.API
{
    public class JokJaBreRepository<TModel> : IJokJaBreRepository<TModel>
        where TModel : class, IJokJaBreModel
    {
        protected DbContext m_context;
        public JokJaBreRepository(DbContext context)
        {
            m_context = context;
        }

        public async Task<TModel> Create(TModel model)
        {
            try
            {
                var res = await m_context.Set<TModel>().AddAsync(model);
                await m_context.SaveChangesAsync();
                await res.ReloadAsync();

                return res.Entity;
            }
            catch (Exception ex)
            {
                throw ApiExceptions.Error("Error while creating object", ex);
            }
        }

        public virtual IEnumerable<TModel> GetAll(Func<DbSet<TModel>, IQueryable<TModel>> includes = null)
        {
            try
            {
                return GetIncludes(includes);
            }
            catch(Exception ex)
            {
                throw ApiExceptions.Error("Error while retrieving all objects", ex);
            }
        }

        public virtual async Task<TModel> GetById<TClass>(TClass key, Func<DbSet<TModel>, IQueryable<TModel>> includes = null, bool shouldThrowIfNull = true)
        {
            TModel result;
            try
            {
                result =  await ((DbSet<TModel>)GetIncludes(includes)).FindAsync(key);
            }
            catch (Exception ex)
            {
                throw ApiExceptions.Error("Error while retrieving object", ex);
            }

            if(result == null && shouldThrowIfNull)
            {
                throw ApiExceptions.ObjectNotFound;
            }

            return result;
        }

        public virtual async Task<bool> Delete<TClass>(TClass key)
        {
            try
            {
                var obj = m_context.Find<TModel>(key);
                if(obj == null)
                {
                    throw ApiExceptions.ObjectNotFound;
                }
                m_context.Remove(obj);
                return (await m_context.SaveChangesAsync()) > 0;
            }
            catch (Exception ex)
            {
                throw ApiExceptions.Error("Error while deleting object", ex);
            }
        }

        public virtual async Task<bool> SaveChanges()
        {
            return (await m_context.SaveChangesAsync()) > 0;
        }

        protected IQueryable<TModel> GetIncludes(Func<DbSet<TModel>, IQueryable<TModel>> includes)
        {
            var result = m_context.Set<TModel>();
            return includes?.Invoke(result) ?? result;
        }
    }
}
