using POne.Core.CQRS;
using POne.Core.Enums;
using System;
using System.Text.Json.Serialization;

namespace POne.Financial.Domain.Commands.Inputs.Categories
{

    public class UpdateCategoryCommand : ICommand
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EntryType Type { get; set; }
        public string Color { get; set; }
    }
}
