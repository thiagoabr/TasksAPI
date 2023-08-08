using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Messages.Settings;

namespace TasksAPI.Messages.Managers
{
    public class RabbitMQManager : IDisposable
    {
        private readonly RabbitMQSettings? _rabbitMQSettings;
        private IConnection? _connection;
        private IModel? _model;

        public RabbitMQManager(IOptions<RabbitMQSettings>? rabbitMQSettings)
        {
            _rabbitMQSettings = rabbitMQSettings.Value;

            var connectionFactory = new ConnectionFactory { Uri = new Uri(_rabbitMQSettings.Url) };
            _connection = connectionFactory.CreateConnection();
            _model = _connection.CreateModel();

            _model.QueueDeclare(
                queue: _rabbitMQSettings.Queue,
                durable: true,
                autoDelete: false,
                exclusive: false,
                arguments: null
                );
        }

        public IModel GetModel => _model;

        public void Dispose()
        {
            _model.Dispose();
            _connection.Dispose();
        }
    }
}
