using Api.Core.Contract.Repository;
using Api.Core.Lib;
using Api.Core.Models;
using Api.Core.Models.DTO;
using Api.Entity;
using Api.Entity.Entity;
using System;
using System.Linq;

namespace Api.Repository
{
	public class CidadeRepository : ICidadeRepository
	{
		private MyDbContext MyDbContext { get; set; }

		public CidadeRepository(MyDbContext context = null)
		{
			if (MyDbContext == null)
				MyDbContext = new MyDbContext();
		}

		public BaseResponse<CidadeDTO>.Collection ListAll()
		{
			var resp = new BaseResponse<CidadeDTO>.Collection();
			try
			{
				var query = MyDbContext.Cidade.ToList();
				resp.List = new Mapper<Cidade, CidadeDTO>().ConvertList(query);
				resp.Total = resp.List.Count;
			}
			catch (Exception ex)
			{
				resp.Success = false;
				resp.Message = ex.Message;
			}
			return resp;
		}

		~CidadeRepository()
		{
			Dispose();
		}
		public void Dispose()
		{
			MyDbContext.Dispose();
		}
	}
}

