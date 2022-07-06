
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Maynor.Domain
{
    /// <inheritdoc />
    public abstract class Entity<TId> : IEntity<TId>
    {
        // Fields
        protected TId _id;

        // <inheritdoc />
        public TId Id { get => _id; protected set => _id = value; }

        protected Entity() { }

        #region IEquatable<object>

        /// <summary>
        /// Compared the Ids of two <see cref="Entity{TId}"/>s to determine equality.
        /// </summary>
        public static bool operator ==(Entity<TId> obj1, Entity<TId> obj2)
        {
            if (Equals(obj1, null))
            {
                if (Equals(obj2, null))
                {
                    return true;
                }
                return false;
            }
            return obj1.Equals(obj2);
        }

        /// <summary>
        /// Compared the Ids of two <see cref="Entity{TId}"/>s to determine equality.
        /// </summary>
        public static bool operator !=(Entity<TId> obj1, Entity<TId> obj2)
        {
            return !(obj1 == obj2);
        }

        /// <summary>
        /// Compared the Ids of two <see cref="Entity{TId}"/>s to determine equality.
        /// </summary>
        public override bool Equals(object? other)
        {
            if (other is null) return false;
            if (other.GetType().FullName != GetType().FullName) return false;

            var otherEntity = other as Entity<TId>;
            if (otherEntity is null) return false;

            return EqualityComparer<TId>.Default.Equals(Id, otherEntity.Id);
        }
        #endregion

        #region GetHashCode

        public override int GetHashCode()
        {
            if (hCode != 0) return hCode;
            hCode = 23;

            unchecked
            {
                foreach (PropertyInfo prop in GetType().GetProperties())
                {
                    var h = GetPropertyHashCode(prop);
                    hCode = hCode * h + h;
                }
            }
            return hCode;
        }
        private int hCode = 0;

        private int GetPropertyHashCode(PropertyInfo prop)
        {
            if (prop is null) return 31;
            if (prop.GetValue(this) is null) return 17;
            return prop.GetValue(this).GetHashCode();
        }
        #endregion
    }
}
