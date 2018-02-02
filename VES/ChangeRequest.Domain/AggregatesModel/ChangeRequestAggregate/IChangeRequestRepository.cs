using System;
using ChangeRequest.Domain.SeedWork;
using ChangeRequest.Domain.AggregatesModel.ChangeRequestAggregate;

namespace ChangeRequest.Domain.AggregatesModel.ChangeRequestAggregate
{
    public interface IChangeRequestRepository:IRepository<ChangeRequest>
    {

    }
}
