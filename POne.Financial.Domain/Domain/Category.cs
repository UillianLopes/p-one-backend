using POne.Core.Entities;
using System;
using System.Collections.Generic;

namespace POne.Financial.Domain.Domain
{
    public class Category : OrganizationalEntity
    {
        protected Category() : base()
        {
            Entries = new HashSet<Entry>();
        }

        public Category(string name, string description, Guid userId, Guid? accountId) : base(name, description)
        {
            UserId = userId;
            AccountId = accountId;
        }

        public Guid? AccountId { get; private set; }
        public Guid UserId { get; private set; }

        public virtual ISet<Entry> Entries { get; private set; }

    }
}
