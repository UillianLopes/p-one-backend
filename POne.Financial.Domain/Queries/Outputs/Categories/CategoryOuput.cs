using POne.Core.Enums;
using System;

namespace POne.Financial.Domain.Queries.Outputs.Categories
{
    public class CategoryOuput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EntryType Type { get; set; }
        public string Color { get; set; }
    }
}
