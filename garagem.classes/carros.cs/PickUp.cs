using System.Threading;
using System.Runtime.ExceptionServices;
using System;
using static System.Console;

namespace garagem.classes
{
    public class PickUp : Veiculos
    {

        internal PICKUPS PICKUP { get; set; }
        internal int CapacidadeDeCarga { get; set; }
        internal PICKUPS categoria { get; set; }

        public enum PICKUPS
        {
            Leve,
            Media,
            Pesada
        }
        public PickUp()
        {
            this.tipo = TipoVeiculo.PickUp;
        }

        public void Escolher(PICKUPS categoria)
        {
            if (categoria == PICKUPS.Leve)
            {
                this.PICKUP = PICKUPS.Leve;
                this.CapacidadeDeCarga = 900;
                this.Marca = "Chevrolet";
                this.Modelo = "Chev500";
            }
            else if (categoria == PICKUPS.Media)
            {
                this.PICKUP = PICKUPS.Media;
                this.CapacidadeDeCarga = 1500;
                this.Marca = "Ford";
                this.Modelo = "F1000";
            }
            else if (categoria == PICKUPS.Pesada)
            {
                this.PICKUP = PICKUPS.Pesada;
                this.CapacidadeDeCarga = 2500;
                this.Marca = "Dodge";
                this.Modelo = "RAM 2500";
            }
        }

        public override string ToString()
        {
            return base.ToString() + $" Capacidade de carga: {this.CapacidadeDeCarga} Kg.\n" +
            $"======================================================";
        }

        public override int Carregar(int carga)
        {
            if (JaEmplacado())
            {
                ValidarCarga(carga);
                for (int i = 0; i < carga; i++, CapacidadeDeCarga--)
                {
                    Clear();
                    WriteLine("Tecle espaço se desejar encerrar o carregamento\n");
                    WriteLine($"Carregando {tipo}, Placa: {Placa}\n");
                    Write("Peso:");
                    WriteLine(i);
                    Thread.Sleep(300);

                    if (Console.KeyAvailable)
                        break;
                }
                Clear();
                WriteLine($"Peso carregado: {carga} kg , Capacidade de carga {CapacidadeDeCarga} Kg.");
                ReadKey();
                return this.CapacidadeDeCarga;
            }
            else
                throw new Exception("Para carregar, o veículo precisa estar emplacado");


        }
        internal void ValidarCarga(int carga)
        {
            if (this.PICKUP == PICKUPS.Leve && carga > 900 || this.PICKUP == PICKUPS.Leve && CapacidadeDeCarga == 0)
                throw new Exception("A capacidade de carga é de 900 Kg");

            else if (this.PICKUP == PICKUPS.Media && carga > 1500 || this.PICKUP == PICKUPS.Media && CapacidadeDeCarga == 0)
                throw new Exception("A capacidade de carga é de 1500 Kg");

            else if (this.PICKUP == PICKUPS.Pesada && carga > 2500 || this.PICKUP == PICKUPS.Pesada && CapacidadeDeCarga == 0)
                throw new Exception("Capacidade do tanque é de 25 litros");
        }
    }




}




