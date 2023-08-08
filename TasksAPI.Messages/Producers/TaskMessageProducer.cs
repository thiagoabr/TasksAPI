using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksAPI.Domain.Ports.Messages.Producers;
using TasksAPI.Messages.Managers;
using TasksAPI.Messages.Settings;
using Task = TasksAPI.Domain.Models.Task;

namespace TasksAPI.Messages.Producers
{
    public class TaskMessageProducer : ITaskMessageProducer
    {
        private readonly RabbitMQManager? _rabbitMQManager;
        private readonly RabbitMQSettings? _rabbitMQSettings;

        public TaskMessageProducer(RabbitMQManager? rabbitMQManager, IOptions<RabbitMQSettings>? rabbitMQSettings)
        {
            _rabbitMQManager = rabbitMQManager;
            _rabbitMQSettings = rabbitMQSettings.Value;
        }

        public void CreateLog(Task task, OperationType operationType)
        {
            using (var model = _rabbitMQManager?.GetModel)
            {
                model.BasicPublish(
                    exchange: string.Empty,
                    routingKey: _rabbitMQSettings?.Queue,
                    basicProperties: null,
                    body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(
                        new {
                            LogAt = DateTime.Now,
                            Type = operationType.ToString(),
                            Task = new
                            {
                                task.Id,
                                task.Name,
                                task.Description,
                                task.Date,
                                task.Time,
                                task.UserId
                            }
                        }))
                    );
            }
        }
    }
}
