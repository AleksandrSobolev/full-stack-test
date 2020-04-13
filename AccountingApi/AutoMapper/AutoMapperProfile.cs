using AccountingApi.DataModels;
using AccountingApi.Models;
using AutoMapper;

namespace AccountingApi.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TransactionEntity, TransactionBaseResponse>();
            CreateMap<TransactionEntity, TransactionResponse>();
            CreateMap<TransactionRequest, TransactionEntity>();
        }
    }
}
