using System;

namespace Serko.Core.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ActionResponse Commit();
    }
}