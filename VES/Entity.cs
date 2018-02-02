﻿using System;
namespace ChangeRequest.SeedWork
{ 
    public abstract class Entity
    {
        int? _requestedHashCode;
        int _Id;
        private List<INotification> _domainEvents;
        public virtual int Id
        {
            get
            {
                return Id1;
            }
            protected set
            {
                Id1 = value;
            }
        }

        public List<INotification> DomainEvents => DomainEvents1;

            public int? RequestedHashCode { get => _requestedHashCode; set => _requestedHashCode = value; }
            public int Id1 { get => _Id; set => _Id = value; }
            public List<INotification> DomainEvents1 { get => _domainEvents; set => _domainEvents = value; }

            public void AddDomainEvent(INotification eventItem)
        {
            DomainEvents1 = DomainEvents1 ?? new List<INotification>();
            DomainEvents1.Add(eventItem);
        }
        public void RemoveDomainEvent(INotification eventItem)
        {
            if (DomainEvents1 is null) return;
            DomainEvents1.Remove(eventItem);
        }

        public bool IsTransient()
        {
            return this.Id == default(Int32);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;
            if (Object.ReferenceEquals(this, obj))
                return true;
            if (this.GetType() != obj.GetType())
                return false;
            Entity item = (Entity)obj;
            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!RequestedHashCode.HasValue)
                    RequestedHashCode = this.Id.GetHashCode() ^ 31;
                // XOR for random distribution. See:
                // http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx
                return RequestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }
        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }
        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}