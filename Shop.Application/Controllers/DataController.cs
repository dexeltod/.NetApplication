using ClassLibrary1.Domain;
using Microsoft.AspNetCore.Mvc;
using Shop.DataBase;
using Shop.Domain;

namespace WebApplication2.Controllers;

[ApiController] [Route("api/[controller]")]
public class DataController : ControllerBase
{
	[HttpGet("{number:int}")]
	public string GetDataWithParams(int number = 37)
	{
		return $"работает с параметром {number}";
	}

	[HttpGet("{number:int}")]
	public string PostDataWithParams(int number = 37)
	{
		return $"работает с параметром {number}";
	}

	[HttpGet]
	public IActionResult GetQuery(int number = 37)
	{
		var a = Request.Query.First().Value;
		return Ok($"работает с query параметром {a}");
	}
}