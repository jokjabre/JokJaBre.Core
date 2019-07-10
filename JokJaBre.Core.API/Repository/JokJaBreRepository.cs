using JokJaBre.Core.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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

        public TModel Create(TModel model)
        {
            try
            {
                var res = m_context.Set<TModel>().Add(model);
                m_context.SaveChanges();
                res.Reload();

                return res.Entity;
            }
            catch (Exception ex)
            {
                throw ApiExceptions.Error("Error while creating object", ex);
            }
        }

        public virtual IEnumerable<TModel> GetAll()
        {
            try
            {
                return m_context.Set<TModel>();
            }
            catch(Exception ex)
            {
                throw ApiExceptions.Error("Error while retrieving all objects", ex);
            }
        }

        public TModel GetById<TClass>(TClass key, bool shouldThrow = true)
        {
            TModel result;
            try
            {
                result =  m_context.Find<TModel>(key);
            }
            catch (Exception ex)
            {
                throw ApiExceptions.Error("Error while retrieving object", ex);
            }

            if(result == null && shouldThrow)
            {
                throw ApiExceptions.ObjectNotFound;
            }

            return result;
        }
    }
}
