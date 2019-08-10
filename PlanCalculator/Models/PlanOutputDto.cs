using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanCalculator.Models
{
    public class PlanOutputDto
    {
        public decimal RoundedInstalmentAmount { get; set; }
        public List<DateTime> InstalmentDates { get; set; }
        public string FormattedDeposit { get; set; }
    }
}
