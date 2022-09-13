using System.Threading;
using System;
using static System.Console;
using System.Text;
using System.Collections.Generic;




namespace garagem.classes
{
    public abstract class Veiculos 
    {
        protected TipoVeiculo tipo { get; set; }
        protected int Identificador { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        protected string Placa { get; set; }
        protected bool Licenciado;
        protected int NivelDeCombustivel { get; set; }
        protected double totalAPagar { get; set; }
        public bool meuVeiculo = true;
        public int AnoDeFabricacao { get; set; }
        public double Preco { get; set; }
        protected double PagaDetran { get; set; }
       
        public Veiculos()
        {
            this.Identificador = IdentifierGenerator.Generate();
            this.Licenciado = false;
            this.NivelDeCombustivel = 8;
        }

        public int MinhaID()
        {
            return (Identificador);
        }
        public TipoVeiculo MeuTipo()
        {
            return tipo;
        }
        public bool Licenciou()
        {
            return this.Licenciado = true;
        }
        public bool JaEmplacado()
        {
            return this.Licenciado == true;
        }

        private class IdentifierGenerator
        {
            private static int _value = 1;

            internal static int Generate()
            {
                return _value++;
            }
        }
        public double PagarDetran()
        {
            return PagaDetran;
        }

        public string Emplacar()
        {
            if (JaEmplacado())
            {
                throw new Exception("Veículo já emplacado");
            }
            else
            {
                var numeros = "0123456789ABCDEFGHIJKLMNOPQRSTUVX";
                var CharsNumeros = new char[5];
                var randomA = new Random();

                for (int i = 0; i < CharsNumeros.Length; i++)
                {
                    CharsNumeros[i] = numeros[randomA.Next(numeros.Length)];
                }
                this.Placa = new String(CharsNumeros);
                this.PagaDetran = 354;

                Licenciou();
            }
            return Placa;
        }

        public int Abastece(int litros)
        {
            double preco = 7.25;
            totalAPagar = 0;
            for (int i = 0; i <= litros; i++, NivelDeCombustivel++)
            {
                Clear();
                WriteLine($"Abastecendo: {tipo} - Placa: {Placa}\n");
                Write($"Litros:");
                WriteLine(i);
                Thread.Sleep(800);

                if (this.tipo == TipoVeiculo.PickUp && litros >= 90 || tipo == TipoVeiculo.PickUp && NivelDeCombustivel == 90)
                    throw new Exception("Capacidade do tanque é de 90 litros");

                else if (this.tipo == TipoVeiculo.Carro && litros >= 55 || tipo == TipoVeiculo.Carro && NivelDeCombustivel == 55)
                    throw new Exception("Capacidade do tanque é de 55 litros");

                else if (this.tipo == TipoVeiculo.Moto && litros >= 25 || tipo == TipoVeiculo.Moto && NivelDeCombustivel == 25)
                    throw new Exception("Capacidade do tanque é de 25 litros");
                this.totalAPagar = litros * preco;
            }

            Clear();
            WriteLine($"Litros Abastecido: {litros} , Total a Pagar $ {totalAPagar} Reais.");

            return this.NivelDeCombustivel;

        }
        public abstract int Carregar(int carga);

        public double TotalAPagar()
        {
            return totalAPagar;
        }

        public override string ToString()
        {
            return $"Id: {this.Identificador} - Tipo: {this.tipo} - Emplacado: {(this.Licenciado ? "Sim" : "Não")} - Placa: {this.Placa}\n" +
            $"Marca: {this.Marca} - Modelo: {this.Modelo}\n" +
            $"Nivel De Combustível: {this.NivelDeCombustivel} litros -";
        }

        public string Classificados()
        {
            string id = $"Id: {this.Identificador}";
            string marca = $"{this.tipo} {this.Marca}";
            string modelo = $"Modelo: {this.Modelo}";
            string ano = $"Ano: {this.AnoDeFabricacao}";
            string preco = $"Preço: R$ {this.Preco}";
            return $"{id} - {marca} - {modelo} - {ano} - {preco}";
        }
        public void Comprar()
        {
            this.meuVeiculo = true;

        }

    }

}
