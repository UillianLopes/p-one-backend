using POne.Core.CQRS;
using System;
using System.Collections.Generic;
using System.Net;

namespace POne.Financial.Domain.Commands.Outputs.Entries
{

    public class ProcessEntryRecurrencyItem
    {
        public int Index { get; set; }
        public decimal Value { get; set; }
        public DateTime DueDate { get; set; }
    }

    public class ProcessEntryRecurrencyOutput : CommandOutput<List<ProcessEntryRecurrencyItem>>
    {
        protected ProcessEntryRecurrencyOutput(HttpStatusCode httpStausCode, string[] messages, List<ProcessEntryRecurrencyItem> data, string uri = null) : base(httpStausCode, messages, data, uri)
        {
        }
    }
}
