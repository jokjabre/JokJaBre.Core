using JokJaBre.Core.Objects.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JokJaBre.Core.API.Context
{
    public class JokJaBreContext : DbContext
    {
        protected bool ImplementsSoftDelete { get; set; } = true;

        private void DoSoftDelete()
        {
            if (!ImplementsSoftDelete) return;

            ChangeTracker.DetectChanges();
            var deleted = ChangeTracker.Entries<IJokJaBreSoftDeletable>().Where(x => x.State == EntityState.Deleted);
            foreach (var entity in deleted)
            {
                entity.State = EntityState.Modified;
                entity.Entity.DateRemoved = DateTime.Now;
            }
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            DoSoftDelete();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            DoSoftDelete();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
