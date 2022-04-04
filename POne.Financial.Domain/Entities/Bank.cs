using POne.Core.Entities;
using System.Collections.Generic;

namespace POne.Financial.Domain.Entities
{
    public class Bank : Entity
    {
        protected Bank() : base()
        {
            Wallets = new HashSet<Wallet>();
        }

        public Bank(string name, string code) : this()
        {
            Name = name;
            Code = code;
        }

        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ISet<Wallet> Wallets { get; }
    }
}
