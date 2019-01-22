using System;
namespace PX.Core.Audit
{
    public interface IFullyAuditedEntity
    {
        DateTime CreateDate { get; set; }
        long CreatedBy { get; set; }
        DateTime? UpdateDate { get; set; }
        long? UpdateBy { get; set; }
        bool IsDeleted { get; set; }
    }
}
