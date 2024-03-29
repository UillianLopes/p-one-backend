﻿using System.Collections.Generic;
using System.Linq;

namespace POne.Core.ValueObjects
{
    public abstract class ValueObject
    {
        public static bool operator ==(ValueObject left, ValueObject right)
        {
            if (left is null ^ right is null)
                return false;

            return left is null || left.Equals(right);
        }

        public static bool operator !=(ValueObject left, ValueObject right) => !(left == right);

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var other = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(eqc => eqc != null ? eqc.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}
