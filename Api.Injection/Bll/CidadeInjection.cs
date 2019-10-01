using Api.Business;
using Api.Core.Contract.Bll;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Injection.Bll
{
	public static class CidadeInjection
	{
		public static IServiceCollection CidadeBllInjection(this IServiceCollection services)
		{
			services.AddSingleton<ICidadeBll, CidadeBll>();
			return services;
		}
	}
}
