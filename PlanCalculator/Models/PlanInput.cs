using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanCalculator.Models
{
    public class PlanInput
    {
        public decimal Price { get; set; }
        public string Date { get; set; }
        public DateTime PurchasedDate => Convert.ToDateTime(Date);
    }
}
