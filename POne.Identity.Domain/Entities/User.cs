using IdentityModel;
using POne.Core.Entities;
using POne.Core.ValueObjects;
using POne.Identity.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Identity.Domain.Entities
{
    public class User : Entity
    {
        protected User() : base() 
        {
            Contacts = new HashSet<Contact>();
        }

        protected User(string name, string email, Password password) : this()
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public User(
            string name,
            string email,
            DateTime birthDate,
            Address address,
            Password password,
            Profile profile
        ) : this(name, email, password)
        {
            BirthDate = birthDate;
            Address = address;
            Profile = profile;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public virtual Address Address { get; private set; }
        public virtual Password Password { get; private set; }
        public virtual Profile Profile { get; private set; }
        public virtual UserSettings Settings { get; private set; }
        public virtual Account Account { get; private set; }
        public virtual ISet<Contact> Contacts { get; private set; }

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

        public void UpdatePassowrd(string password) => Password = new Password(password);

        public void UpdateAddress(string street, string district, string number, string city, string state, string country, string zipCode)
        {
            Address = new Address(street, district, number, city, state, country, zipCode);
        }

        public IEnumerable<Claim> ReadRoles()
        {
            yield return new Claim(JwtClaimTypes.Name, Name);
            yield return new Claim(JwtClaimTypes.Email,Email);
            yield return new Claim(JwtClaimTypes.Id, Id.ToString());
            if (Account is Account account)
                yield return new Claim("AccountId", account.Id.ToString());

            if (Profile is null)
                yield break;

            foreach (var role in Profile.Roles)
                yield return new Claim(JwtClaimTypes.Role, role.Key);
        }


    }
}
