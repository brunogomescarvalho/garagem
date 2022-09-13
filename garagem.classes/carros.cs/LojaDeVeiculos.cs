using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace garagem.classes
{
    public class LojaDeVeiculos
    {
        public static void Estoque(List<Veiculos> Garagem)
        {
            Garagem.Add((new Moto { MOTO = Moto.MOTOS.Urbana, meuVeiculo = false, Modelo = "CG", Marca = "Honda", AnoDeFabricacao = 2000, Preco = 5000 }));
            Garagem.Add((new Moto { MOTO = Moto.MOTOS.OffRoad, meuVeiculo = false, Modelo = "DT", Marca = "Yamaha", AnoDeFabricacao = 1995, Preco = 7000 }));
            Garagem.Add((new Moto { MOTO = Moto.MOTOS.Viagem, meuVeiculo = false, Modelo = "GS", Marca = "BMW", AnoDeFabricacao = 2020, Preco = 75000 }));
            Garagem.Add((new PickUp { PICKUP = PickUp.PICKUPS.Leve, meuVeiculo = false, Modelo = "Chev500", Marca = "Chevrolet", AnoDeFabricacao = 1993, Preco = 10600 }));
            Garagem.Add((new PickUp { PICKUP = PickUp.PICKUPS.Media, meuVeiculo = false, Modelo = "F1000", Marca = "Ford", AnoDeFabricacao = 1987, Preco = 25000 }));
            Garagem.Add((new PickUp { PICKUP = PickUp.PICKUPS.Pesada, meuVeiculo = false, Modelo = "RAM 2500", Marca = "Dodge", AnoDeFabricacao = 2015, Preco = 125000 }));
        }  
    }
}