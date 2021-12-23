using POne.Core.Entities;
using System.Collections.Generic;

namespace POne.Financial.Domain.Domain
{
    public class Bank : Entity
    {
        protected Bank() : base()
        {
            Balances = new HashSet<Balance>();
        }

        public Bank(string name, string code) : this()
        {
            Name = name;
            Code = code;
        }

        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ISet<Balance> Balances { get; }
    }
}
