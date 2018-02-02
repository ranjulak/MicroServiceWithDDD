using System;
using System.Collections.Generic;
using System.Text;
using ChangeRequest.Domain.AggregatesModel.ChangeRequestAggregate;
using ChangeRequest.Domain.SeedWork;

namespace ChangeRequest.Infrastructure.Repositories
{
    public class ChangeRequestRepository:IChangeRequestRepository
    {
        private readonly ChangeRequestContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public ChangeRequestRepository()
        {

        }
    }
}
