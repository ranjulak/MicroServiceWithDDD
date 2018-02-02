using System;

namespace ChangeRequest.Domain.SeedWork
{

    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
