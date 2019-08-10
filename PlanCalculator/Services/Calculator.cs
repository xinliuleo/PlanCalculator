using PlanCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanCalculator.Services
{
    public class Calculator : ICalculator
    {
        public List<PlanOutput> CalculatePaymentPlan(PlanInput input)
        {
            var result = new List<PlanOutput>();
            var planVariables = new List<PlanVariables>();
            switch (input.Price)
            {
                case decimal n when (n < 100 || n > 10000):
                    return null;
                case decimal n when (n >= 100 && n < 1000):
                    planVariables = new List<PlanVariables>{
                       new PlanVariables{ deposit=0.2M, InstalmentInterval = 15, InstalmentPeriod = 5 },
                       new PlanVariables{ deposit=0.3M, InstalmentInterval = 15, InstalmentPeriod = 4 }
                    };
                    break;
                case 1000:
                    planVariables = new List<PlanVariables>{
                       new PlanVariables{ deposit=0.2M, InstalmentInterval = 15, InstalmentPeriod = 5 },
                       new PlanVariables{ deposit=0.3M, InstalmentInterval = 15, InstalmentPeriod = 4 },
                       new PlanVariables{ deposit=0.25M, InstalmentInterval = 30, InstalmentPeriod = 4}
                    };
                    break;
                case decimal n when (n > 1000 && n <= 10000):
                    planVariables = new List<PlanVariables>{
                       new PlanVariables{ deposit=0.25M, InstalmentInterval = 30, InstalmentPeriod = 4}
                    };
                    break;
            }
            foreach (var plan in planVariables)
            {
                result.Add(
                    new PlanOutput
                    {
                        Deposit = plan.deposit,
                        InstalmentAmount = GetInstalmentAmount(input.Price, plan.deposit, plan.InstalmentPeriod),
                        InstalmentDates = GetInstalmentDates(input.PurchasedDate, plan.InstalmentInterval, plan.InstalmentPeriod)
                    });
            }
            return result;
        }
        private decimal GetInstalmentAmount(decimal price, decimal deposit, int instalmentPeriod)
        {
            return price * (1 - deposit) / instalmentPeriod;
        }

        private List<DateTime> GetInstalmentDates(DateTime purchasedDate, int instalmentIntrval, int instalmentPeriod)
        {
            var dates = new List<DateTime>();
            for (int i = 1; i <= instalmentPeriod; i++)
                dates.Add(purchasedDate.AddDays(instalmentIntrval * i));
            return dates;
        }

    }
}
