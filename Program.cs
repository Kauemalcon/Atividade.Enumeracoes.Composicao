using System;
using System.Globalization;
using Atividade.Enumeracoes.Composicao.Entities;
using Atividade.Enumeracoes.Composicao.Entities.Enums;

namespace Atividade.Enumeracoes.Composicao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entre com o nome do departamento: ");
            string nomeDept = Console.ReadLine();
            Console.WriteLine("Entre com os dados do tabalhador");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Nível (Junior, Pleno, Senior): ");
            //Parametrização da classe 'Enum' dentro da classe 'Trabalhador' para a classe 'program', para 'ler'
            NivelTrabalhador nivel = Enum.Parse<NivelTrabalhador>(Console.ReadLine());
            Console.Write("Salario base: ");
            double salarioBase = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //Chama a classe Departamento
            Departamento departamento = new Departamento(nomeDept);
            //Chama a classe Trabalhador
            Trabalhador trabalhador = new Trabalhador(nome, nivel, salarioBase, departamento);
            Console.WriteLine();
            Console.Write("Quantos contratos para esse trabalhador: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Entre com os dados do contrado #{i}");
                Console.Write("Data (DD/MM/AAAA): ");
                DateTime data = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor hora: ");
                double valorHora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duração (horas): ");
                int hora = int.Parse(Console.ReadLine());
                //Chama a classe ContratoHora
                ContratoHora contrato = new ContratoHora(data, valorHora, hora);
                //Com a classe Trabalhador ja instaciada, chamar o metodo AddContrato
                trabalhador.AddContrato(contrato);
            }

            Console.WriteLine();

            Console.Write("Entre com o mês e ano para calculara renda(MM/AAAA): ");
            //Variavel string para ler o mes e ano (MM/AAAA)
            string mesEano = Console.ReadLine();
            //Usando a variavel mes e ano para 'recortar' a data
            int mes = int.Parse(mesEano.Substring(0, 2));
            int ano = int.Parse(mesEano.Substring(3));
            Console.WriteLine("Nome: "+ trabalhador.Nome);
            Console.WriteLine("Departamento: "+ trabalhador.Departamento.Nome);
            //Método renda'Trabalahdor'.
            Console.WriteLine("Renda para ("+ mesEano + "): "+ trabalhador.Renda(ano, mes).ToString("F2", CultureInfo.InvariantCulture)); 

        }
        
    }
}
