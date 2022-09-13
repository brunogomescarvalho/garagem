using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace garagem.classes
{
    public class Pessoa
    {
        public Voucher voucher { get; set; }
        private string Nome { get; set; }
        public garagemDeCarros Garagem { get; set; }
        public Moto veiculos { get; set; }

        public Pessoa(string nome, int opcaoDeConta)
        {
            this.Nome = nome;
            
            this.voucher = VoucherBuilder.Create(opcaoDeConta);

            this.veiculos = new Moto { MOTO = Moto.MOTOS.Urbana, meuVeiculo = true };
            veiculos.Escolher(Moto.MOTOS.Urbana);
        }

        public string MeuNome()
        {
            return $"{Nome}";
        }

        public override string ToString()
        {
            return $"{this.Nome} {this.Garagem.MostrarVeiculos()} {this.voucher.HistoricoBancario()}";
        }

    }
}