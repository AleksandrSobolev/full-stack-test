using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingApi.DataModels;

namespace AccountingApi.DataStorage
{
    public interface IDataStorage
    {
        TransactionEntity[] GetAll();

        TransactionEntity Get(Guid id);

        void Add(TransactionEntity transaction);
    }
}
