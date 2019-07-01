using JokJaBre.Core.Exceptions;
using JokJaBre.Core.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JokJaBre.Core.Repository
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

                return GetById(res.Entity.Id);
            }
            catch (Exception ex)
            {
                throw ApiExceptions.Error(ex.Message);
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
                throw ApiExceptions.Error(ex.Message);
            }
        }

        public TModel GetById(long id)
        {
            try
            {
                return m_context.Find<TModel>(id) ?? throw ApiExceptions.ObjectNotFound;
            }
            catch (Exception ex)
            {
                throw ApiExceptions.Error(ex.Message);
            }
        }
    }
}
