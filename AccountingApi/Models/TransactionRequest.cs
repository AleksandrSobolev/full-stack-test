using AccountingApi.DataModels;
using System;

namespace AccountingApi.Models
{
    public class TransactionRequest
    {

        public TransactionTypeEnum Type { get; set; }

        public decimal Amount { get; set; }

    }
}
