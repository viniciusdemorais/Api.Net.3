using Api.Injection.Bll;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Injection
{
	public static class InjectionsBll
	{
		public static IServiceCollection AddInjectionsBll(this IServiceCollection services)
		{
			services.CidadeBllInjection();
			return services;
		}
	}
}
