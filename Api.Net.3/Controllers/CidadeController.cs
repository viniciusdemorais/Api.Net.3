using Api.Core.Contract.Bll;
using Microsoft.AspNetCore.Mvc;


namespace Api.Net._3.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class CidadeController : Controller
	{
		readonly ICidadeBll _cidadeBll;
		public CidadeController(ICidadeBll cidadeBll)
		{
			_cidadeBll = cidadeBll;
		}

		[HttpGet]
		public IActionResult List()
		{
			var received = _cidadeBll.ListAllCities();
			if (received.Success)
				return Ok(received.List);
			else
				return BadRequest(received.Message);
		}
	}
}
