using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Contract_Processing_Automation.Entities;
using Contract_Processing_Automation.Services;

namespace Contract_Processing_Automation.Services
{
    class ContractService
    {
        private IOnlinePaymentService _onlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService)
        {
            _onlinePaymentService = onlinePaymentService;
        }
        public void ProcessContract(Contract contract, int months)
        {
            double basicQuota = contract.TotalValue / months;
            for (int i = 1; i <= months; i++)
            {
                DateTime date = contract.Date.AddMonths(i);
                double updatedQuota = basicQuota + _onlinePaymentService.Interest(basicQuota, i);
                double fullQuota = updatedQuota + _onlinePaymentService.PaymentFee(updatedQuota);
                contract.Installment.Add(new Installment(date, fullQuota));
            }
        }
    }
}
