using System;
namespace PX.Core.Audit
{
    public abstract class FullyAuditedEntity<T> : Entity<T>, IFullyAuditedEntity
    {

        public DateTime CreateDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public long? UpdateBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
