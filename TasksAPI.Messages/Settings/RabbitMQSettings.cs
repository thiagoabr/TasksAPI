using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksAPI.Messages.Settings
{
    public class RabbitMQSettings
    {
        public string? Url { get; set; }
        public string? Queue { get; set; }
    }
}
