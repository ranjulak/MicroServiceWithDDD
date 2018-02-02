using System;
using ChangeRequest.Domain.SeedWork;

namespace ChangeRequest.Domain.AggregatesModel.ChangeRequestAggregate
{
    public class ChangeRequest:Entity, IAggregateRoot

    {
        public string Description { get; set; }
        public Notifier Notifier { get; set; }
        public string Status { get; set; }
        public Source Source { get; set; }
        public DateTime CreateDateTime { get; set; }


    }
}
