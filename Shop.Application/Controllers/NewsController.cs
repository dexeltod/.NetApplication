using Microsoft.AspNetCore.Mvc;
using Shop.ControllerInterfaces;
using Shop.Services.Repositoryes;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

[ApiController] [Route("api/news")] public class NewsController(
	NewsRepository repository,
	UserRepository userRepository
) : ControllerBase, IApiTasksController
// надо подумать надо абстракцией
{
	private readonly NewsRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

	private readonly UserRepository _userRepository
		= userRepository ?? throw new ArgumentNullException(nameof(userRepository));

	[HttpPost("{title}/{description}/{authorId:guid}")]
	public async Task Add(string title, string description, Guid authorId)
	{
		User author = await _userRepository.GetById(authorId);
		Guid a = Guid.NewGuid();
		News news = new News()
		{
			Id = a,
			Title = title,
			Description = description,
			Author = author,
			AuthorId = authorId
		};
		
		await _repository.Add(news);
	}

	public Task<Guid> Remove(Guid id) =>
		throw new NotImplementedException();

	public Task<Guid> Edit(News product) =>
		throw new NotImplementedException();

	public Task<News> GetById(Guid id) =>
		throw new NotImplementedException();

	[HttpGet]
	public async Task<List<News>> GetAll()
	{
		var result = await _repository.GetAll();
		if (result == null) throw new ArgumentNullException(nameof(result));
		Ok();
		return result;
	}

	[HttpGet("{count:int}")]
	public async Task<List<News>> GetByCount(int count)
	{
		Console.WriteLine("GetByCount" + count);
		var result = await _repository.GetByCount(count);
		Ok();
		return result;
	}
}