using POne.Core.CQRS;
using System;

namespace POne.Financial.Domain.Queries.Inputs.Dashboards
{
    public class DashboardFilter : IQuery
    {
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public bool UseMock { get; set; }
    }
}
