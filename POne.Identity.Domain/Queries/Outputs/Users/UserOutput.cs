using POne.Core.Models;
using System;

namespace POne.Identity.Domain.Queries.Outputs.Users
{
    public class UserOutput
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public OptionModel Profile { get; set; }
    }
}
