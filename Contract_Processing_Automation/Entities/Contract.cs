using System;
using System.Collections.Generic;
using System.Text;
using Contract_Processing_Automation.Entities;

namespace Contract_Processing_Automation
{
    class Contract
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public double TotalValue { get; set; }
        public List<Installment> Installment { get; set; } = new List<Installment>();

        public Contract()
        {
        }

        public Contract(int number, DateTime date, double totalValue)
        {
            Number = number;
            Date = date;
            TotalValue = totalValue;
        }

    }
}
