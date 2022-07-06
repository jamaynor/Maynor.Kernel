namespace Maynor.Domain
{
    /// <summary>
    /// A domain object adhering to DDD principles. It has public property getters and
    /// hidden (private, protected, internal) setters. It's state can only be modified by the 
    /// AggregateRoot for which it is a property or field. Identity is a function of its ID (or 
    /// <see cref="CompositeKey"/>) rather than its attributes.
    /// </summary>
    public interface IEntity<TId> : IEquatable<object>
    {
        /// <summary>The unique key that identifies an entity.</summary>
        TId Id { get; }
    }
}
