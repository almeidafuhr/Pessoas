using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrarPessoas
{
    public class Pessoa
    {
        public string Nome;
        public string Cpf;
        public int Idade;
        public SexoPessoa Sexo;
        public DateTime DataNasc;

        public Pessoa() { }
        public Pessoa(string nome, string cpf, int idade, SexoPessoa sexo, DateTime dataNasc)
        {
            Nome = nome;
            Cpf = cpf;
            Idade = idade;
            Sexo = sexo;
            DataNasc = dataNasc;
        }
    }
}
