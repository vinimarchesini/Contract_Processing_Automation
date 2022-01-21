using System;
using System.Globalization;
using System.Collections.Generic;
using Contract_Processing_Automation.Entities;
using Contract_Processing_Automation.Services;

namespace Contract_Processing_Automation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract Data:");
            Console.Write("Number: ");
            int contractNumber = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime contractDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract value: ");
            double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number of installments: ");
            int months = int.Parse(Console.ReadLine());
            Contract myContract = new Contract(contractNumber, contractDate, contractValue);
            ContractService contractService = new ContractService(new PaypalService());
            contractService.ProcessContract(myContract, months);
            Console.WriteLine("Installments:");
            foreach(Installment inst in myContract.Installment)
            {
                Console.WriteLine(inst);
            }
        }
    }
}
