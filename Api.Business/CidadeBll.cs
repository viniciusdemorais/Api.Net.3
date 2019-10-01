using Api.Core.Contract.Bll;
using Api.Core.Contract.Repository;
using Api.Core.Models;
using Api.Core.Models.DTO;
using Api.Repository;

namespace Api.Business
{
	public class CidadeBll : ICidadeBll
	{
		public BaseResponse<CidadeDTO>.Collection ListAllCities()
		{
			var resp = new BaseResponse<CidadeDTO>.Collection();
			using (ICidadeRepository cidadeRepository = new CidadeRepository())
			{
				resp = cidadeRepository.ListAll();
			}
			return resp;
		}
	}
}
