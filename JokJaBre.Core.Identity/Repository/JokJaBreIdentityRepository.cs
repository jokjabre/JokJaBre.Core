using JokJaBre.Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;

namespace JokJaBre.Core.Identity
{
    public class JokJaBreIdentityRepository<TIdentityModel> : IJokJaBreIdentityRepository<TIdentityModel>
        where TIdentityModel : class, IJokJaBreIdentityModel
    {
        protected DbContext m_context;
        public JokJaBreIdentityRepository(DbContext context)
        {
            m_context = context;
        }

        public TIdentityModel Create(TIdentityModel model)
        {
            try
            {
                var res = m_context.Set<TIdentityModel>().Add(model);
                m_context.SaveChanges();
                res.Reload();

                return res.Entity;
            }
            catch (Exception ex)
            {
                throw ApiExceptions.Error("Error while creating identity object", ex);
            }
        }

        public bool EmailAvaiilable(string email)
        {
            return m_context.Set<TIdentityModel>()
                .AnyAsync(m => m.Email == email)
                .Result;
        }

        public TIdentityModel Get(TIdentityModel model)
        {
            return m_context.Set<TIdentityModel>()
                .SingleOrDefaultAsync(m =>
                    (m.Username == model.Username || m.Email == model.Email) &&
                     m.Password == model.Password)
                .Result;
        }

        public bool UsernameAvailable(string username)
        {
            return m_context.Set<TIdentityModel>()
                .AnyAsync(m => m.Username == username)
                .Result;
        }
    }
}
