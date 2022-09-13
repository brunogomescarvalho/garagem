using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace garagem.classes.pessoas.cs
{
    public class Trabalhos
    {
        public List<Trabalhos> trabalho { get; set; }
        public List<string> Enderecos { get; set; }
        public TipoVeiculo VeiculosParaTrabalhar { get; set; }
        public Veiculos veiculo { get; set; }
        public string Descricao { get; set; }
        public int CodigoVaga { get; set; }
        public double ValorPago { get; set; }
        public string LocalParaEntrega { get; set; }
        protected bool VagaDisponivel = true;

        public Trabalhos()
        {
            trabalho = new List<Trabalhos>();
            Enderecos = new List<string>{
         "R. Gen. Nepomuceno Costa, 505 - Centro, Lages - SC, 88502-130",
         "Av. Mal. Floriano, 81 - Centro, Lages - SC, ",
         "R. João de Castro, 367 - Centro, Lages - SC,",
         "R. Lauro Muller, 192 - Centro, Lages - SC",
         "Av. Belizário Ramos, 2568 - Centro, Lages - SC,",
         "R. Rio Branco, 388 - São Cristovão, Lages - SC"};
        }

        public int GeracaoDeId()
        {
            var random = new Random();
            this.CodigoVaga = random.Next(0, 100);
            return CodigoVaga;
        }

        public string ObtemEndereco()
        {
            var random = new Random();
            this.LocalParaEntrega = Enderecos[random.Next(Enderecos.Count)];
            return LocalParaEntrega;
        }

        public Trabalhos PesquisarVagas(int codigoVaga)
        {
            var index = trabalho.FindIndex(t => t.CodigoVaga.Equals(codigoVaga));
            if (index == -1)
                throw new Exception("Nenhuma Vaga com esse Id");
            return trabalho[index];
        }



        public bool VagaPreenchida()
        {
            return this.VagaDisponivel = false;
        }
        public bool TrabalhoDisponivel()
        {
            return VagaDisponivel == true;
        }

        public List<Trabalhos> HistoricoVagas()
        {
            return this.trabalho;
        }

        public void VagasDeEmprego(List<Trabalhos> trabalho)
        {
            trabalho.Add(new Trabalhos { VeiculosParaTrabalhar = TipoVeiculo.Moto, Descricao = "Fazer entregas de remédios", ValorPago = 7, CodigoVaga = GeracaoDeId() });
            trabalho.Add(new Trabalhos { VeiculosParaTrabalhar = TipoVeiculo.PickUp, Descricao = "Fazer frete para loja", ValorPago = 25, CodigoVaga = GeracaoDeId() });
            trabalho.Add(new Trabalhos { VeiculosParaTrabalhar = TipoVeiculo.Moto, Descricao = "Fazer entregas de Pizza", ValorPago = 5, CodigoVaga = GeracaoDeId() });
            trabalho.Add(new Trabalhos { VeiculosParaTrabalhar = TipoVeiculo.Moto, Descricao = "Fazer entregas de remédios", ValorPago = 7, CodigoVaga = GeracaoDeId() });
            trabalho.Add(new Trabalhos { VeiculosParaTrabalhar = TipoVeiculo.PickUp, Descricao = "Fazer frete para loja", ValorPago = 25, CodigoVaga = GeracaoDeId() });

        }

        public double AceitarTrabalho(Trabalhos codigovaga)
        {
            return codigovaga.ValorPago;
        }

        public override string ToString()
        {
            string titulo = "------ EMPREGOS ------";
            string informacoes = $"Código Vaga - {CodigoVaga} - Veículo Necessário - {VeiculosParaTrabalhar}";
            string conteudo = $"{Descricao}";
            string remuneracao = $"Valor Pago R$ {ValorPago}";

            return $"{titulo}\n{informacoes}\n{conteudo}\n{remuneracao}";
        }
    }
}