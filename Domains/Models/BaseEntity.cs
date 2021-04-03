using System;

namespace FatecMauaJobNewsletter.Domains.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
        }

        public BaseEntity(string createdBy, DateTime createdAt, string modifiedBy, DateTime modifiedAt, bool flagActive = true)
        {
            Id = Guid.NewGuid();
            CreatedBy = createdBy;
            CreatedAt = createdAt;
            ModifiedBy = modifiedBy;
            ModifiedAt = modifiedAt;
            FlagActive = flagActive;
        }

        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool FlagActive { get; set; }
    }
}
