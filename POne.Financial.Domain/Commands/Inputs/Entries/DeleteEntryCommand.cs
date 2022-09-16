using POne.Core.CQRS;
using System;
using System.Text.Json.Serialization;

namespace POne.Financial.Domain.Commands.Inputs.Entries
{
    public class DeleteEntryCommand : ICommand
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
