
using ETradeAPI.Application.Repositories.AbstractCustomer;
using ETradeAPI.Application.Repositories.AbstractOrder;
using ETradeAPI.Application.Repositories.AbstractProduct;
using ETradeAPI.Persistence.Contexts;
using ETradeAPI.Persistence.Repositories.ConcreteCustomer;
using ETradeAPI.Persistence.Repositories.ConcreteOrder;
using ETradeAPI.Persistence.Repositories.ConcreteProduct;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ETradeDbContext>(options => options.UseSqlServer(ConfigurationService.GetConnectionString()));
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();


        }
    }
}
