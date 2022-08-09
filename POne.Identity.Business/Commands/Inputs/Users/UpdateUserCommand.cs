

using POne.Core.CQRS;
using System;
using System.Text.Json.Serialization;

namespace POne.Identity.Business.Commands.Inputs.Users
{
    public class UpdateUserCommand : ICommand
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string MobilePhone { get; set; }
        public string Password { get; set; }
        public AddressCommand Address { get; set; }
    }
}
