using System;
using System.Collections.Generic;
using Atividade.Enumeracoes.Composicao.Entities.Enums;

namespace Atividade.Enumeracoes.Composicao.Entities
{
    class Trabalhador
    {
        public string Nome { get; set; }
        public NivelTrabalhador Nivel { get; set; }
        public double BaseSalario { get; set; }
        public Departamento Departamento { get; set; }
        public List<ContratoHora> Contratos { get; set; } = new List<ContratoHora>();

        public Trabalhador()
        {

        }
        public Trabalhador(string nome, NivelTrabalhador nivel, double baseSalario, Departamento departamento)
        {
            Nome = nome;
            Nivel = nivel;
            BaseSalario = baseSalario;
            Departamento = departamento;
        }

        public void AddContrato(ContratoHora contrato)
        {
            Contratos.Add(contrato);
        }

        public void RemoverContrato(ContratoHora contrato)
        {
            Contratos.Remove(contrato);
        }
        public double Renda(int ano, int mes)
        {
            double soma = BaseSalario;

            foreach(ContratoHora x in Contratos)
            {
                if(x.Data.Year == ano && x.Data.Month == mes)
                {
                    soma += x.ValorTotal();
                }
            }
            return soma;
        }


    }
}
