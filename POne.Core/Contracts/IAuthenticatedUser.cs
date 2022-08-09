using System;

namespace POne.Core.Contracts
{
    public interface IAuthenticatedUser
    {
        public Guid Id { get; }
        public Guid? AccountId { get; }
        public string Email { get; }
        public bool IsStandalone { get; }
    }
}
