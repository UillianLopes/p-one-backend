using POne.Core.Entities;
using System.Collections.Generic;

namespace POne.Domain.Entities
{
    public class Account : Entity
    {
        protected Account() : base()
        {
            Users = new HashSet<User>();
            Accounts = new HashSet<Account>();
        }

        public Account(string name, string email) : this()
        {
            Name = name;
            Email = email;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public virtual ISet<User> Users { get; private set; }
        public virtual ISet<Account> Accounts { get; private set; }
        public virtual Account ParentAccount { get; private set; }

        public void AddUser(User user)
        {
            if (Users.Contains(user))
                return;

            Users.Add(user);
        }

        public void AddAccount(Account account)
        {
            if (Accounts.Contains(account))
                return;

            Accounts.Add(account);
        }

        public void RemoveUser(User user)
        {
            Users.Remove(user);
        }

        public void RemoveAccount(Account account)
        {
            Accounts.Remove(account);
        }
    }
}
