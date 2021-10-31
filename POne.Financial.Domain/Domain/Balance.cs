using POne.Core.Entities;
using System;

namespace POne.Financial.Domain.Domain
{
    public class Balance : Entity
    {
        protected Balance() : base()
        {
        }

        public Balance(Guid userId, string name, decimal value) : this()
        {
            UserId = userId;
            Value = value;
            Name = name;
        }

        public Guid UserId { get; set; }
        public decimal Value { get; set; }
        public string Name { get; set; }
    }
}
