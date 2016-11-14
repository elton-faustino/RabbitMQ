using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Connect();
        }

        IConnection _connection;

        public void Connect()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "test",
                Password = "test",
                RequestedHeartbeat = 60
            };

            _connection = connectionFactory.CreateConnection();
        }
    }
}
