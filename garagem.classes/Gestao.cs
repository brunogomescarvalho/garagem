using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using garagem.classes.pessoas.cs;

namespace garagem.classes
{
    public class Gestao
    {
        private List<Pessoa> Pessoas { get; set; }
        public Trabalhos trabalho { get; set; }
        public Gestao()
        {
            Pessoas = new List<Pessoa>();
            trabalho = new Trabalhos();
        }

        public void AdicionarPessoa(Pessoa pessoa)
        {
            Pessoas.Add(pessoa);
        }

        public Pessoa PesquisarPessoa(string nome)
        {
            var index = Pessoas.FindIndex(p => p.MeuNome().Equals(nome.ToLower()));

            if (index == -1)
                throw new Exception("Ninguem encontrado com esse nome");
            return Pessoas[index];
        }

        public List<Pessoa> MostrarPessoas()
        {
            return this.Pessoas;
        }
        public int QuantidadeDeJogadores(List<Pessoa> Pessoas)
        {
            return this.Pessoas.Count;
        }
    }
}