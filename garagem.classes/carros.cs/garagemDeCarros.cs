using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using garagem.classes;

namespace garagem.classes
{
    public class garagemDeCarros
    {
        public List<Veiculos> Garagem { get; set; }
    
        public garagemDeCarros()
        {
            Garagem = new List<Veiculos>();          
        }

        public void AdicionarNaGaragem(Veiculos carro)
        {
            Garagem.Add(carro);
        }

        public List<Veiculos> MostrarVeiculos()
        {
            return Garagem;
        }

        public Veiculos PesquisarVeiculo(int identificacao)
        {
            foreach (var veiculo in Garagem)
            {
                if (veiculo.MinhaID().Equals(identificacao))
                {
                    return veiculo;
                }
            }
            return null;
        }

        public Veiculos Excluir(int identificacao)
        {
            var pesquisa = PesquisarVeiculo(identificacao);
            Garagem.Remove(pesquisa);
            return null;
        }

    }
}