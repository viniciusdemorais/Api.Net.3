using Api.Core.Models;
using Api.Core.Models.DTO;
using System;

namespace Api.Core.Contract.Repository
{
	public interface ICidadeRepository : IDisposable
	{
		BaseResponse<CidadeDTO>.Collection ListAll();
	}
}
