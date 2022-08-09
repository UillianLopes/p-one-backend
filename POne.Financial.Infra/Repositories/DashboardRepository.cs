using Microsoft.EntityFrameworkCore;
using POne.Core.Contracts;
using POne.Core.Queries.Outputs;
using POne.Financial.Domain.Contracts;
using POne.Financial.Domain.Queries.Inputs.Dashboards;
using POne.Financial.Infra.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POne.Financial.Infra.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly POneFinancialDbContext _financialDbContext;
        private readonly IAuthenticatedUser _authenticatedUser;

        public DashboardRepository(POneFinancialDbContext financialDbContext, IAuthenticatedUser authenticatedUser)
        {
            _financialDbContext = financialDbContext;
            _authenticatedUser = authenticatedUser;
        }

        public async Task<LineChartDataOutput> GetBalanceOverTimeAsync(GetBalanceOverTime request, CancellationToken cancellationToken)
        {
            var currentDate = request.Begin.Date;
            var begin = request.Begin.Date;
            var end = request.End.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            var dates = new List<DateTime>();

            while (currentDate <= request.End.Date)
            {
                dates.Add(currentDate);
                currentDate = currentDate.AddDays(1);
            }


            var wallets = await _financialDbContext.Wallets
                .Where(wallet => (_authenticatedUser.IsStandalone && wallet.UserId != null && wallet.UserId == _authenticatedUser.Id || !_authenticatedUser.IsStandalone && _authenticatedUser.AccountId == _authenticatedUser.AccountId))
                .ToListAsync(cancellationToken);

            var groups = new List<LineChartDataGroup>();
            var ramdom = new Random();

            foreach (var wallet in wallets)
            {

                var balances = wallet
                 .Balances
                 .Where(balance => balance.Creation >= begin && balance.Creation <= end)
                 .ToList();

                var series = new List<LineChartDataSerie>();

                var lastValue = 0.00m;


                foreach (var date in dates)
                {
                    var balance = balances
                        .Where(balance => balance.Creation.Date == date)
                        .OrderByDescending(balance => balance.Creation)
                        .FirstOrDefault();

                    var nextRamdom = (decimal)ramdom.Next(0, 100);

                    var balanceValue = request.UseMock ? ((nextRamdom / 100.00m) * 100000.00m) : balance?.Value ?? lastValue;

                    series.Add(new LineChartDataSerie
                    {
                        Name = date.ToString("dd/MM/yyyy"),
                        Value = date.Date >= wallet.Creation.Date && date.Date <= DateTime.Now.Date ? balanceValue : null
                    });
                    var teste = new LineChartDataSerie
                    {
                        Name = date.ToString("dd/MM/yyyy"),
                        Value = date.Date >= wallet.Creation.Date && date.Date <= DateTime.Now.Date ? balanceValue : null
                    };

                    lastValue = balanceValue;
                }

                groups.Add(new LineChartDataGroup
                {
                    Name = wallet.Name,
                    Color = wallet.Color,
                    Series = series
                });
            }

            return new LineChartDataOutput
            {
                Groups = groups
            };

        }
    }
}
