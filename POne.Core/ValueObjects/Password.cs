using POne.Core.Extensions;
using System.Collections.Generic;

namespace POne.Core.ValueObjects
{
    public class Password : ValueObject
    {
        public static bool operator ==(Password left, string right)
        {
            if (left is null ^ right is null)
                return false;

            return left is null || BCrypt.Net.BCrypt.Verify(right, left.Value);
        }

        public static bool operator !=(Password left, string right) => !(left == right);

        public string Value { get; private set; }

        protected Password() { }

        public Password(string value)
        {
            Value = Encrypt(value);
        }

        public override bool Equals(object obj) => base.Equals(obj);

        public override int GetHashCode() => base.GetHashCode();

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        private static string Encrypt(string password)
        {
            return password.HashPassword();
        }

    }
}
