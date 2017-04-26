using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using queue.implementacao;

namespace queue.generator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var b = new Base();

            var fila = "filaDoJoin";
            var host = "localhost";

            var alunos = new List<Aluno>(){
                new Aluno(){ Nome = "John", Idade = 23 },
                new Aluno(){ Nome = "Bira", Idade = 29 }
            };

            b.CriarFila(fila, host);

            var res = b.SerializarLista(alunos);

            b.EnviarMensagem(fila, res, host);

            Console.ReadKey();
        }

        public class Aluno
        {
            public string Nome { get; set; }
            public int Idade { get; set; }
        }

    }

    public class Base : Operacoes
    {
        
    }

}
