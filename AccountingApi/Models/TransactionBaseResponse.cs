using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingApi.DataModels;

namespace AccountingApi.Models
{
    public class TransactionBaseResponse
    {
        public Guid Id { get; set; }

        public TransactionTypeEnum Type { get; set; }

        public decimal Amount { get; set; }
    }
}
