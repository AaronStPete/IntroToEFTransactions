using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingTransactionRedux.Data
{
    class Transactions
    {
        public int Id { get; set; }
        public DateTime? Timestamp { get; set; }
        public string Action { get; set; }
        public string AccountNumber { get; set; }
        public decimal? AmountChanged { get; set; }
        public decimal? NewAmount { get; set; }
    }
}
