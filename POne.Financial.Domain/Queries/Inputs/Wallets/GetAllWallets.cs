﻿using POne.Core.CQRS;

namespace POne.Financial.Domain.Queries.Inputs.Wallets
{
    public class GetAllWallets : IQuery
    {
        public string Currency { get; set; }
    }
}
