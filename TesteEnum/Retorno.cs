using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrarPessoas
{
    public class Retorno
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
        //<T> Dados;

        public Retorno(int codigo, string mensagem)  //T Dados
        {
            Codigo = codigo;
            Mensagem = mensagem;
            //this.Dados = dados;
        }   
    }
}
