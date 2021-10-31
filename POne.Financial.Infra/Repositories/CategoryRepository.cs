﻿using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Domain;
using POne.Financial.Infra.Connections;
using POne.Infra.Repositories;

namespace POne.Financial.Infra.Repositories
{
    public class CategoryRepository : Repository<POneFinancialDbContext, Category>, ICategoryRepository
    {
        public CategoryRepository(POneFinancialDbContext dbContext) : base(dbContext)
        {
        }
    }
}
