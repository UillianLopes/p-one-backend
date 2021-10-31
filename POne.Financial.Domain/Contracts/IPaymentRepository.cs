﻿using POne.Core.Contracts;
using POne.Financial.Domain.Domain;

namespace POne.Financial.Domain.Contracts
{
    public interface IPaymentRepository : IRepository<Payment>
    {
    }
}
