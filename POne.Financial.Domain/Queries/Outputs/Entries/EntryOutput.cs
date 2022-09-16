using POne.Core.Enums;
using POne.Core.Models;
using System;

namespace POne.Financial.Domain.Queries.Outputs.Entries
{
    public class EntryOutput
    {
        public Guid? InstallmentId { get; set; }
        public int? Index { get; set; }
        public EntryOperation Type { get; set; }
        public decimal Value { get; set; }
        public DateTime? DueDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public OptionModel Category { get; set; }
        public OptionModel SubCategory { get; set; }
        public OptionModel Wallet { get; set; }
        public int? Recurrences { get; set; }
        public Guid? Id { get; set; }
        public Guid? ParentId { get; set; }
        public string BarCode { get; set; }
        public decimal PaidValue { get; set; }
        public string Currency { get; set; }
        public PaymentOutput[] Payments { get; set; }
        public EntryPaymentStatus PaymentStatus
        {
            get
            {
                if (PaidValue >= Value)
                    return EntryPaymentStatus.Paid;

                if (DueDate != null && DueDate.Value.Date < DateTime.Now.Date)
                    return EntryPaymentStatus.Overdue;

                if (DueDate != null && DueDate.Value.Date == DateTime.Now.Date)
                    return EntryPaymentStatus.ToPayToday;

                return EntryPaymentStatus.Opened;
            }
        }
        public DateTime? RecurrenceBegin { get; set; }
        public DateTime? RecurrenceEnd { get; set; }
        public EntryRecurrence? Recurrence { get; set; }
    }
}
