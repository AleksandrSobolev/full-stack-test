using System;
using System.Collections.Generic;
using System.Linq;
using AccountingApi.DataStorage;
using AccountingApi.ServicesLayer;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AccountingApi
{
    static class Container
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IDataStorage, DataStorage.DataStorage>();
            services.AddScoped<ITransactionsService, TransactionsService>();
        }

        public static void RegisterAutomapper(IServiceCollection services)
        {
            var typesWithMappings = new List<Type>()
            {
                typeof(AccountingApi.AutoMapper.AutoMapperProfile),
            };

            var assembliesWithMappings = typesWithMappings
                .Select(t => t.Assembly);

            services.AddAutoMapper(assembliesWithMappings);
        }
    }
}
