using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queue.interfaces
{
    public interface IOperacoes
    {
         void CriarFila(string fila, string host);

         void EnviarMensagem(string fila, string mensagem, string host);

         string Serializar<TEntity>(TEntity entidade);

         string SerializarLista<TEntity>(List<TEntity> lista);
    }
}
