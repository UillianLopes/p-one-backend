using POne.Core.CQRS;
using System.Collections.Generic;

namespace POne.Core.Queries.Outputs
{

    public record LineChartDataSerie
    {
        public string Name { get; set; }
        public decimal? Value { get; set; }
    }

    public record LineChartDataGroup
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public ICollection<LineChartDataSerie> Series { get; set; }
    }

    public record LineChartDataOutput
    {
        public ICollection<LineChartDataGroup> Groups { get; set; }
    }
}
