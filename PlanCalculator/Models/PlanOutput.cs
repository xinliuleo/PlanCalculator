using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanCalculator.Models
{
    public class PlanOutput
    {
        public decimal Deposit { get; set; }
        public decimal InstalmentAmount { get; set; }
        public List<DateTime> InstalmentDates { get; set; }
    }
}
