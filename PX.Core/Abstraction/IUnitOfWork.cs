using System;
namespace PX.Core.Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
