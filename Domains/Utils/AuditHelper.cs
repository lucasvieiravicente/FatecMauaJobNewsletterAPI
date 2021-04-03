using FatecMauaJobNewsletter.Domains.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FatecMauaJobNewsletter.Domains.Utils
{
    public static class AuditHelper
    {
        private const string System = "SYSTEM";

        public static void UpdateAuditInfo<T>(T entity, EntityState entityState, string user = null) where T : BaseEntity
        {
            var date = DateTime.Now;
            user ??= System;

            if (entityState == EntityState.Added)
            {
                entity.FlagActive = true;
                entity.CreatedAt = date;
                entity.CreatedBy = user;
            }
                
            if(entityState == EntityState.Deleted)
            {
                entity.FlagActive = false;
            }

            entity.ModifiedAt = date;
            entity.ModifiedBy = user;
        }

        public static void UpdateAuditInfo<T>(IEnumerable<T> entities, EntityState entityState, string user = null) where T : BaseEntity
        {
            foreach (var entity in entities)
                UpdateAuditInfo(entity, entityState, user);
        }
    }
}
