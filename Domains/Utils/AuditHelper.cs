using FatecMauaJobNewsletter.Domains.Models;
using System;
using System.Collections.Generic;

namespace FatecMauaJobNewsletter.Domains.Utils
{
    public static class AuditHelper<T> where T : BaseEntity
    {
        public static void UpdateAuditInfo(T model, string userLogin)
        {
            DateTime date = DateTime.Now;
            string user = userLogin ?? "SYSTEM";

            if (model.CreatedAt == DateTime.MinValue)
                model.CreatedAt = date;

            if (string.IsNullOrEmpty(model.CreatedBy))
                model.CreatedBy = user;

            model.ModifiedAt = date;
            model.ModifiedBy = user;
        }

        public static void UpdateAuditInfo(IEnumerable<T> models, string userLogin)
        {
            DateTime date = DateTime.Now;
            string user = userLogin ?? "SYSTEM";

            foreach(var model in models)
            {
                if (model.CreatedAt == DateTime.MinValue)
                    model.CreatedAt = date;

                if (string.IsNullOrEmpty(model.CreatedBy))
                    model.CreatedBy = user;

                model.ModifiedAt = date;
                model.ModifiedBy = user;
            }
        }
    }
}
