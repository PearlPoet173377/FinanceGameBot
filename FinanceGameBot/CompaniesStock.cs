using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceGameBot
{
    class CompaniesStock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float CurrentPrice { get; set; }
        public float OneRoundlaterprice { get; set; }
        public float TwoRoundlaterprice { get; set; }
        public float ThreeRoundlaterprice { get; set; }
        public float FourRoundlaterprice { get; set; }
    }
}
