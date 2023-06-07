using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMQ_Simple_API.Services
{
	public class RabbitMQService
	{
		private readonly ConnectionFactory _connectionFactory;
		private readonly IConnection _connection;
		private readonly IModel _channel;

		public RabbitMQService()
		{
			_connectionFactory = new ConnectionFactory()
			{
				HostName = "localhost", // RabbitMQ sunucusunun adresi
				Port = 5672, // RabbitMQ varsayılan bağlantı noktası
				UserName = "guest", // RabbitMQ kullanıcı adı
				Password = "guest" // RabbitMQ şifresi
			};

			_connection = _connectionFactory.CreateConnection();
			_channel = _connection.CreateModel();
		}

		public void PublishMessage(string message, string queueName)
		{
			_channel.QueueDeclare(queueName, false, false, false, null);
			var body = Encoding.UTF8.GetBytes(message);
			_channel.BasicPublish("", queueName, null, body);
		}
	}
}
