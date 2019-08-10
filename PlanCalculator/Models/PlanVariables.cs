using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanCalculator.Models
{
    public class PlanVariables
    {
        public decimal deposit { get; set; }
        public int InstalmentInterval { get; set; }
        public int InstalmentPeriod { get; set; }
    }
}
