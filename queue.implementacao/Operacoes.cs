using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using queue.interfaces;
using RabbitMQ.Client;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace queue.implementacao
{
    public abstract class Operacoes : IOperacoes
    {

        public void CriarFila(string fila, string host)
        {
            var factory = new ConnectionFactory() { HostName = host };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: fila,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                }
            }
        }

        public void EnviarMensagem(string fila, string mensagem, string host)
        {
            var factory = new ConnectionFactory() { HostName = host };

            using (var connection = factory.CreateConnection())
            {

                using (var channel = connection.CreateModel())
                {
                    var body = Encoding.UTF8.GetBytes(mensagem);

                    channel.BasicPublish(exchange: string.Empty,
                                         routingKey: fila,
                                         basicProperties: null,
                                         body: body);
                }

            }
        }

        public string Serializar<TEntity>(TEntity entidade)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(entidade.GetType());
            var xml = string.Empty;

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xmlSerializer.Serialize(writer, entidade);
                    xml = sww.ToString();
                }
            }

            return xml;
        }

        public string SerializarLista<TEntity>(List<TEntity> lista)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(lista.GetType());
            var xml = string.Empty;

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xmlSerializer.Serialize(writer, lista);
                    xml = sww.ToString();
                }
            }

            return xml;
        }

    }

}
