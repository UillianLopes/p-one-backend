using POne.Core.Entities;
using POne.Core.ValueObjects;
using System;
using System.Collections.Generic;

namespace POne.Domain.Entities
{
    public class User : Entity
    {
        public User(string name, string email, DateTime birthDate, Address address, PhoneNumber mobilePhone, Password password) : this()
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Address = address;
            MobilePhone = mobilePhone;
            Password = password;
            Accounts = new HashSet<Account>();
            Roles = new HashSet<Role>();
        }

        protected User() : base() { }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public virtual Address Address { get; private set; }
        public virtual PhoneNumber MobilePhone { get; private set; }
        public virtual Password Password { get; private set; }
        public virtual ISet<Account> Accounts { get; private set; }
        public virtual ISet<Role> Roles { get; private set; }

        public void Update(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public void UpdatePassowrd(string password)
        {
            Password = new Password(password);
        }

        public void UpdateAddress(string street, string district, string number, string city, string state, string country, string zipCode)
        {
            Address = new Address(street, district, number, city, state, country, zipCode);
        }

        public void AddRole(Role role)
        {
            if (Roles.Contains(role))
                return;

            Roles.Add(role);
        }

        public void RemoveRole(Role role)
        {
            if (!Roles.Contains(role))
                return;

            Roles.Remove(role);
        }
    }
}
