using System;
using System.Collections.Generic;

namespace POne.Financial.Domain.Commands.Inputs.Entries
{
    public class Installment
    {
        public int Index { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Value { get; set; }
        public string BarCode { get; set; }
    }

    public class CreateInstallmentEntriesCommand : CreateStandardEntryCommand
    {
        public ICollection<Installment> Installments { get; set; }
    }
}
