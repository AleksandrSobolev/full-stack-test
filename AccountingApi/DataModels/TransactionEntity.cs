using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingApi.DataModels
{
    public class TransactionEntity
    {
        public Guid Id { get; set; }

        public TransactionTypeEnum Type { get; set; }

        public decimal Amount { get; set; }

        public DateTime EffectiveDate { get; set; }
    }
}
