
using System;
using System.Collections.Generic;

namespace Maynor.Domain
{
    /// <inheritdoc />
    public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot<TId>
    {
        // fields
        private List<object> _domainEvents = new List<object>();


        // <inheritdoc />
        public int Version { get; protected set; }
        /// <summary>The DateTime this AggregateRoot was created.</summary>
        public DateTime CreatedOn { get; protected set; }

        /// <summary>The user that created this instance. This can take a userame (e.g., 'jbright') or a user token bepending on your use case.</summary>
        public string? CreatedBy { get; protected set; }

        /// <summary>The DateTime this was last updated.</summary>
        public DateTime? UpdatedOn { get; protected set; }




        // <inheritdoc />
        public IEnumerable<object> GetDomainEvents() { return _domainEvents; }

        /// <summary>Adds a domain event to the list.</summary>
        protected void AddDomainEvent(object domainEvent)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));
            _domainEvents.Add(domainEvent);
        }

        // <inheritdoc />
        public void ClearDomainEvents() { _domainEvents.Clear(); }
    }

}
