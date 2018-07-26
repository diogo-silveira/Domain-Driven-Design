using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serko.Core.ApplicationService;
using Serko.Core.Domain.Interfaces.ApplicationService;
using Serko.Core.Domain.Interfaces.Repository;
using Serko.Core.Domain.Interfaces.Service;
using Serko.Core.Domain.Interfaces.UnitOfWork;
using Serko.Core.Infrastructure.Data.Context;
using Serko.Core.Infrastructure.Data.Repository;
using Serko.Core.Infrastructure.Data.UnitOfWork;
using Serko.Core.Service;

namespace Serko.Core.Infrastructure.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #region [ APPLICATION SERVICE ]

            services.AddScoped<IBaseApplicationService, BaseApplicationService>();

            services.AddScoped<IEmployeeApplicationService, EmployeeApplicationService>();
            services.AddScoped<IExpenseApplicationService, ExpenseApplicationService>();


            #endregion

            #region [ SERVICE ]
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IExpenseService, ExpenseService>();

            #endregion

            #region [ DATA ] 

            services.AddScoped<SerkoCoreDataContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();


            #endregion

        }
    }
}