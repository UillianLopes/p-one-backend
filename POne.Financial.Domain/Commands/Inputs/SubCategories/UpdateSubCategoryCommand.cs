using POne.Core.CQRS;
using System;
using System.Text.Json.Serialization;

namespace POne.Financial.Domain.Commands.Inputs.SubCategories
{
    public class UpdateSubCategoryCommand : ICommand
    {
        [JsonIgnore] public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}
