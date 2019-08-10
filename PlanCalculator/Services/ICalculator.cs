using PlanCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanCalculator.Services
{
    public interface ICalculator
    {
        List<PlanOutput> CalculatePaymentPlan(PlanInput input);
    }
}
