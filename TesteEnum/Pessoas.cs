using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrarPessoas
{
    internal class Pessoas
    {
        List<Pessoa> ListaPessoas = new List<Pessoa>();

        public Retorno ValidarNome(string nome)
        {
            if (nome.Where(c => char.IsNumber(c)).Count() > 0)
            {
                return new Retorno(10, "<<Nome contém números>>");
            }
            if (nome.Where(c => char.IsSymbol(c)).Count() > 0)
            {
                return new Retorno(11, "<<Nome contém caracteres especiais>>");
            }
            return new Retorno(0, "<<NOME CADASTRADO>>");
        }
        public Retorno ValidarCpf(string cpf)
        {
            String regex = "^\\d{11}$";
            if (System.Text.RegularExpressions.Regex.IsMatch(cpf, regex))
                return new Retorno(0, "<<CPF CADASTRADO>>");
            else
            {
                return new Retorno(13, "<<CPF Inválido>>");
            }
        }
        public Retorno ValidarCpfCompleto(string cpf)
        {
            String regex = "^\\d{11}$";
            if (System.Text.RegularExpressions.Regex.IsMatch(cpf, regex))
            {
                foreach (var duplicata in ListaPessoas)
                {
                    if (duplicata.Cpf.Equals(cpf))
                        return new Retorno(12, "<<CPF já cadastrado>>");
                }
                return new Retorno(0, "<<CPF ACEITO>>");
            }
            else
            {
                return new Retorno(13, "<<CPF Inválido>>");
            }
        }
        public Retorno ValidarIdade(string idade)
        {
            int valida = 0;
            if (int.TryParse(idade, out valida))
            {
                if (valida < 0)
                    return new Retorno(14, "<<Idade menor que 0>>");
                return new Retorno(0, "<<IDADE CADASTRADA>>");
            }
            else
                return new Retorno(15, "<<Valor inserido não é uma idade>>");
            
        }
        public Retorno ValidarSexo(int sex)
        {
            switch (sex)
            {
                case 1:
                    Console.WriteLine($"Sexo: {SexoPessoa.Masculino}");
                    return new Retorno(0,"<<SEXO CADASTRADO>>");
                case 2:
                    Console.WriteLine($"Sexo: {SexoPessoa.Feminino}");
                    return new Retorno(0, "<<SEXO CADASTRADO>>");
                default:
                    Console.WriteLine($"Opção Inválida! ");
                    return new Retorno(16, "<<Falha na Operação>>");
            }
        }
        public Retorno ValidarDtNasc(string dataNasc)
        {
            DateTime data;
            DateTime hoje = DateTime.Now;
            string dataPattern = "dd/MM/yyyy";

            if (DateTime.TryParseExact(dataNasc, dataPattern, null, DateTimeStyles.None, out data))
            {
                if (data > hoje)
                    return new Retorno(17, "<<Data inserida é maior que a atual>>");
            }
            else
                return new Retorno(18, "<<Formato não aceito>>");
            return new Retorno(0, "<<NASCIMENTO ACEITO>>");
        }


        public Retorno AdicionarPessoa()
        {
            Pessoa novaPessoa = new Pessoa();
            Retorno retNome, retCpf, retIdade, retSexo, retDataNasc;

            do
            {
                Console.Write("Entre com o Nome: ");
                string nome = Console.ReadLine();
                retNome = ValidarNome(nome);
                Console.WriteLine($"{retNome.Codigo} - {retNome.Mensagem}");
                if (retNome.Codigo == 0)
                    novaPessoa.Nome = nome;
            } while (retNome.Codigo != 0);

            do
            {
                Console.Write("Entre com o CPF: ");
                string cpf = Console.ReadLine();
                retCpf = ValidarCpfCompleto(cpf);
                Console.WriteLine($"{retCpf.Codigo} - {retCpf.Mensagem}");
                if (retCpf.Codigo == 0)
                    novaPessoa.Cpf = cpf;
            } while (retCpf.Codigo != 0);

            do
            {
                Console.Write("Entre com a idade: ");
                string idade = Console.ReadLine();
                retIdade = ValidarIdade(idade);
                Console.WriteLine($"{retIdade.Codigo} - {retIdade.Mensagem}");
                if (retIdade.Codigo == 0)
                    novaPessoa.Idade = int.Parse(idade);
            } while (retIdade.Codigo != 0);


            do
            {
                Console.Write("Entre com o sexo: [1 - Masculino 2 - Feminino]: ");
                int sexo = int.Parse(Console.ReadLine());
                retSexo = ValidarSexo(sexo);
                Console.WriteLine($"{retSexo.Codigo} - {retSexo.Mensagem}");
                if (retSexo.Codigo == 0)
                    novaPessoa.Sexo = (SexoPessoa) sexo;
            } while (retSexo.Codigo != 0);

            do
            {
                Console.Write("Entre com a data de nascimento: ");
                string dataNasc = Console.ReadLine();
                retDataNasc = ValidarDtNasc(dataNasc);
                Console.WriteLine($"{retDataNasc.Codigo} - {retDataNasc.Mensagem}");
                if (retDataNasc.Codigo == 0)
                    novaPessoa.DataNasc = DateTime.ParseExact(dataNasc,"dd/MM/yyyy",null);
            } while (retDataNasc.Codigo != 0);

            ListaPessoas.Add(novaPessoa);
            return new Retorno(0, "<<REGISTRO CADASTRADO>>");
        }

        public Retorno RemoverPessoa()
        {
            Retorno retCpf;
            string cpf;
            do
            {
                Console.Write("Entre com o CPF: ");
                cpf = Console.ReadLine();
                retCpf = ValidarCpf(cpf);
                Console.WriteLine($"{retCpf.Codigo} - {retCpf.Mensagem}");
            } while (retCpf.Codigo != 0);
            
            if (retCpf.Codigo == 0)
            {
                foreach (var lp in ListaPessoas)
                {
                    if (lp.Cpf.Equals(cpf))
                    {
                        ListaPessoas.Remove(lp);
                        return new Retorno(0, "<<Sucesso na Operação>>");
                    }
                }
            }
            return new Retorno(19, "<<Não foi possível remover>>");

        }

        public Retorno ListarPessoas()
        {
            if (ListaPessoas.Count > 0)
            {
                var listaOrdenada = ListaPessoas.OrderBy(l => l.Nome);
                foreach (var lista in listaOrdenada)
                {
                    Console.WriteLine($"{lista.Nome} {lista.Cpf} {lista.Idade} {lista.Sexo} {lista.DataNasc.ToShortDateString()}");
                }
                return new Retorno(0, "<<Sucesso na operação>>");
            }
            else
                return new Retorno(20, "Não foi possível listar");
        }

    }

}
