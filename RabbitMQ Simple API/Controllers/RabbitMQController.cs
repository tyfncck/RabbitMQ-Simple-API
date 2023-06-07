using Microsoft.AspNetCore.Mvc;
using RabbitMQ_Simple_API.Services;

namespace RabbitMQ_Simple_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly RabbitMQService _rabbitMQService;

		public ValuesController(RabbitMQService rabbitMQService)
		{
			_rabbitMQService = rabbitMQService;
		}

		[HttpPost]
		public IActionResult Post(string message, string queueName)
		{
			_rabbitMQService.PublishMessage(message, queueName);
			return Ok();
		}
	}
}