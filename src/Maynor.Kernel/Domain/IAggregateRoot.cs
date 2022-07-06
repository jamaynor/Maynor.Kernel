namespace Maynor.Domain
{
    /// <summary>
    /// A domain object adhering to DDD principles. It has public property getters and
    /// hidden (private, protected, internal) setters. Its methods manage state for 
    /// the root object and its properties and fields. Identity is a function of its ID (or 
    /// <see cref="CompositeKey"/>) rather than its attributes. 
    /// </summary>
    public interface IAggregateRoot<TId> : IEntity<TId>
    {
        /// <summary>The DateTime this AggregateRoot was created.</summary>
        public DateTime CreatedOn { get; }

        /// <summary>The user that created this instance. This can take a userame (e.g., 'jbright') or a user token bepending on your use case.</summary>
        public string? CreatedBy { get; }

        /// <summary>The DateTime this was last updated.</summary>
        public DateTime? UpdatedOn { get; }


        /// <summary>A sequential id that is used to prevent concurrency issues.</summary>
        int Version { get; }
        /// <summary>Holds all domain events that would be executed upon persisting an aggregate.</summary>
        public IEnumerable<object> GetDomainEvents();
        /// <summary>Clears all domain events.</summary>
        public void ClearDomainEvents();
    }

}
