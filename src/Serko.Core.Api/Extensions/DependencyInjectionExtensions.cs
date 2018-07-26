using Microsoft.Extensions.DependencyInjection;
using Serko.Core.Infrastructure.CrossCutting.IoC;

namespace Serko.Core.Api.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}