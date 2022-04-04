using System;

namespace POne.Financial.Domain.Queries.Outputs.Banks
{
    public record BankOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
