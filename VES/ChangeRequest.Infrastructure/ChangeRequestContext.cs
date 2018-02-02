using System;
using System.Collections.Generic;
using System.Text;
using ChangeRequest.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

namespace ChangeRequest.Infrastructure
{
    class ChangeRequestContext:  DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await _mediator.DispatchDomainEventsAsync(this);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed throught the DbContext will be commited
            var result = await base.SaveChangesAsync();

            return true;
        }
    }
}
