using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrarPessoas
{
    internal class Program
    {
        private static Pessoas cadastro = new Pessoas();
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            int op;
            do
            {
                Console.WriteLine("<<CADASTRO DE PESSOAS>>\n");
                Console.WriteLine("1 - Adicinar pessoas");
                Console.WriteLine("2 - Excluir Pessoas");
                Console.WriteLine("3 - Listar Pessoas");
                Console.WriteLine("4 - Persistir");
                Console.WriteLine("5 - Sair\n");
                Console.Write("Escolha: ");
                op = int.Parse(Console.ReadLine());
                EscolhaMenu(op);
            } while (op >= 1 && op <= 4);
        }

        static void EscolhaMenu(int op)
        {
            Retorno ret;
            switch (op)
            {
                case 1:
                    ret = cadastro.AdicionarPessoa();
                    Console.WriteLine($"\n{ret.Codigo} - {ret.Mensagem}\n");
                    FinalizarOperacao();
                    break;
                case 2:
                    ret = cadastro.RemoverPessoa();
                    Console.WriteLine($"\n{ret.Codigo} - {ret.Mensagem}\n");
                    FinalizarOperacao();
                    break;
                case 3:
                    ret = cadastro.ListarPessoas();
                    Console.WriteLine($"\n{ret.Codigo} - {ret.Mensagem}\n");
                    FinalizarOperacao();
                    break;
                case 4:

                    break;
                default:
                    break;
            }
        }
        static void FinalizarOperacao()
        {
            Console.WriteLine("<<PRESSIONE ENTER>>");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
