using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingApi.Models;

namespace AccountingApi.ServicesLayer
{
    public interface ITransactionsService
    {
        TransactionResponse[] GetAll();

        TransactionResponse Get(Guid id);

        TransactionResponse Add(TransactionRequest transaction);
    }
}
