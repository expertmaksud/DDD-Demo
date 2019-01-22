using System;
namespace PX.Core.Audit
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
