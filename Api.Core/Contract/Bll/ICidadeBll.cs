using Api.Core.Models;
using Api.Core.Models.DTO;

namespace Api.Core.Contract.Bll
{
	public interface ICidadeBll
	{
		BaseResponse<CidadeDTO>.Collection ListAllCities();
	}
}
