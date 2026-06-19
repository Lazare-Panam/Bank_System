using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class LowBalanceEventArgs : EventArgs
    {
        public Guid Id { get; set; }
        public decimal Balance { get; set; }
    }
    public class LowBalanceEvent
    {
        public event EventHandler<LowBalanceEventArgs> LowBalanceOccured;
        public void OnLowBalanceOccured(Guid accountId, decimal amount, TransactionType transactionType, decimal totalBalance)
        {
            Console.WriteLine("Low Balance Occured");
            LowBalanceOccured?.Invoke(this, new LowBalanceEventArgs
            {
                Id = accountId,
                Balance = totalBalance
            });
        }
    }
}

