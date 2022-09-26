using POne.Core.CQRS;

namespace POne.Financial.Domain.Queries.Inputs.Wallets
{
    public class GetAllWalletsAsOptions : IQuery
    {
        public string Currency { get; set; }
    }
}
