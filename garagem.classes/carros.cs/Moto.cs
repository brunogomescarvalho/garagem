using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace garagem.classes
{
    public class Moto : Veiculos
    {
        internal int Cilindradas { get; set; }
        internal MOTOS MOTO { get; set; }
        internal MOTOS categoria { get; set; }

        public Moto()
        {
            this.tipo = TipoVeiculo.Moto;
        }

        public enum MOTOS
        {
            Urbana,
            OffRoad,
            Viagem,
        }

        public void Escolher(MOTOS categoria)
        {
            if (categoria == MOTOS.Urbana)
            {
                this.MOTO = MOTOS.Urbana;
                this.Cilindradas = 150;
                this.Marca = "Honda";
                this.Modelo = "CG";
            }
            else if (categoria == MOTOS.OffRoad)
            {
                this.MOTO = MOTOS.OffRoad;
                this.Cilindradas = 380;
                this.Marca = "Yamaha";
                this.Modelo = "DT";
            }
            else if (categoria == MOTOS.Viagem)
            {
                this.MOTO = MOTOS.Viagem;
                this.Cilindradas = 1300;
                this.Marca = "BMW";
                this.Modelo = "GS";
            }

        }
        public override int Carregar(int carga)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString() + $" Cilindradas {this.Cilindradas}\n" +
            $"=======================================================";
        }
    }
}