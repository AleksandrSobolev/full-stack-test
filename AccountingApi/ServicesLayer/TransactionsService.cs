using System;
using AccountingApi.DataModels;
using AccountingApi.DataStorage;
using AccountingApi.Models;
using System.Collections.Generic;
using AutoMapper;

namespace AccountingApi.ServicesLayer
{
    public class TransactionsService : ITransactionsService
    {
        private readonly IMapper _mapper;
        private readonly IDataStorage _dataStorage;

        public TransactionsService(IDataStorage dataStorage, IMapper mapper)
        {
            _dataStorage = dataStorage;
            _mapper = mapper;
        }

        public TransactionResponse Add(TransactionRequest transactionRequest)
        {
            var model = _mapper.Map<TransactionEntity>(transactionRequest);
            _dataStorage.Add(model);
            return _mapper.Map<TransactionResponse>(model);
        }

        public TransactionResponse[] GetAll()
        {
             return _mapper.Map<TransactionResponse[]>(_dataStorage.GetAll());
        }

        public TransactionResponse Get(Guid id)
        {
            return _mapper.Map<TransactionResponse>(_dataStorage.Get(id));
        }
    }
}
