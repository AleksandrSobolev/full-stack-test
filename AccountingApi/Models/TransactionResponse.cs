using AccountingApi.DataModels;
using System;

namespace AccountingApi.Models
{
    public class TransactionResponse : TransactionBaseResponse
    {
        public DateTime EffectiveDate { get; set; }
    }
}
