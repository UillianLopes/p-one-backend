using POne.Core.Entities;
using POne.Core.ValueObjects;
using POne.Identity.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Identity.Domain.Entities
{
    public class User : Entity
    {
        protected User(string name, string email, Password password) : this()
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public User(string name, string email, DateTime birthDate, Address address, PhoneNumber mobilePhone, Password password) : this(name, email, password)
        {
            BirthDate = birthDate;
            Address = address;
            MobilePhone = mobilePhone;
            Roles = new HashSet<Role>();
        }

        protected User() : base()
        {

        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public virtual Address Address { get; private set; }
        public virtual PhoneNumber MobilePhone { get; private set; }
        public virtual Password Password { get; private set; }
        public virtual ISet<Role> Roles { get; private set; }
        public virtual UserSettings Settings { get; private set; }

        public static User Simplified(string name, string email, Password password) => new (name, email, password);

        public void Update(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }


        public async Task UpdateUserSettingsAsync(GeneralSettings settings, CancellationToken cancellationToken)
        {
            if (Settings == null)
                Settings = new UserSettings();

            await Settings.UpdateAsync(settings, cancellationToken);
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
