using AccountingApi.DataModels;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using AccountingApi.Validation;

namespace AccountingApi.DataStorage
{
    public class DataStorage : IDataStorage
    {
        private readonly ConcurrentDictionary<Guid, TransactionEntity> _transactions = new ConcurrentDictionary<Guid, TransactionEntity>();
        private readonly object _locker = new object();

        public DataStorage()
        {
            // mock test data
            var debitEntity = new TransactionEntity { Id = Guid.NewGuid(), Amount = 100, Type = TransactionTypeEnum.Debit, EffectiveDate = DateTime.Now };
            var creaditEntity = new TransactionEntity { Id = Guid.NewGuid(), Amount = 50, Type = TransactionTypeEnum.Credit, EffectiveDate = DateTime.Now.AddSeconds(1) };
            _transactions.TryAdd(debitEntity.Id, debitEntity);
            _transactions.TryAdd(creaditEntity.Id, creaditEntity);
        }

        public TransactionEntity[] GetAll()
        {
            return _transactions.Select(tr => tr.Value).OrderBy(t => t.EffectiveDate).ToArray();
        }

        public TransactionEntity Get(Guid id)
        {
            _transactions.TryGetValue(id, out var transaction);
            return transaction;
        }

        public void Add(TransactionEntity transaction)
        {
            //Added Lock here for validate client negative balance
            lock (_locker)
            {
                ValidateTransactionAmount(transaction);
                transaction.Id = Guid.NewGuid();
                transaction.EffectiveDate = DateTime.Now;
                _transactions.TryAdd(transaction.Id, transaction);
            }
        }

        private void ValidateTransactionAmount(TransactionEntity transaction)
        {
            if (transaction.Type == TransactionTypeEnum.Debit)
            {
                return;
            }

            var transactions = GetAll();
            var debitTotal = transactions.Where(t => t.Type == TransactionTypeEnum.Debit).Sum(t => t.Amount);
            var creditTotal = transactions.Where(t => t.Type == TransactionTypeEnum.Credit).Sum(t => t.Amount);

            if (debitTotal - creditTotal + transaction.Amount * -1 < 0)
            {
                throw new NegativeAmountException();
            }
        }

    }
}
