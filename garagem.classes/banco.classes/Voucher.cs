using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Immutable;
using System.Text;

namespace garagem.classes
{

    public abstract class Voucher
    {
        protected double Saldo { get; set; }
        internal Empresa Empresa { get; set; }
        internal Pessoa Pessoa { get; set; }

        protected string HorarioDaMovimentacao { get; set; }


        public LocalConveniado LocalConveniado { get; set; }
        protected List<string> Historico { get; }

        internal Voucher(Empresa empresa)
        {
            Empresa = empresa;
            Historico = new List<string>();
        }

        protected abstract void Registrar(double quantia, string HoraDaCompra);

        public void Usar(double quantia)
        {
            if (Saldo < quantia)
                throw new Exception($"Saldo de R$ {Saldo}, insuficiente para a compra de R$ {quantia}.");

            Saldo -= quantia;
            HorarioDaMovimentacao = DateTime.Now.ToLongTimeString();
            Registrar(quantia, HorarioDaMovimentacao);

        }

        public void Depositar(double quantia)
        {
            if (quantia <= 0)
                throw new Exception($"Quantia a depositar deve ser superior a zero");

            Saldo += quantia;
            HorarioDaMovimentacao = DateTime.Now.ToShortDateString();
            Registrar(quantia, HorarioDaMovimentacao);

        }


        public override string ToString()
        {
            StringBuilder builder = new();

            foreach (var item in Historico)
                builder.AppendLine(item);

            return builder.ToString();

        }

        public List<string> HistoricoBancario()
        {
            return this.Historico;
        }

        public string InfoBanco()
        {
            string titulo = $"------ Extrato Bancário ------";
            string hora = $"Data:    {DateTime.Now}";
            string saldoBancario = $"Saldo:        R$ {Saldo}";

            return $"{titulo}\n{hora}\n{saldoBancario}";
        }

    }

    public enum Empresa
    {
        Amazonas,
        Murder,
        Hell,
    }


    public enum LocalConveniado
    {
        Posto_De_Combustivel,
        Loja_De_Veiculos,
        Detram,
        Deposito,
    }

    internal class Amazonas : Voucher
    {
        public Amazonas() : base(Empresa.Amazonas)
        {
            this.Saldo = 100;
        }

        protected override void Registrar(double quantia, string HorarioDaMovimentacao)
        {
            this.Historico.Add($"Quantia R$ {quantia}  Local {LocalConveniado}  Saldo restante R${Saldo}");
        }
    }

    internal class Hell : Voucher

    {
        public Hell() : base(Empresa.Hell)
        {
            this.Saldo = 11500;
        }

        protected override void Registrar(double quantia, string HorarioDaMovimentacao)
        {
            this.Historico.Add($"Local: {LocalConveniado}  R$ {quantia} - Hrs: {HorarioDaMovimentacao}");
        }

    }

    internal class Murder : Voucher
    {
        public Murder() : base(Empresa.Murder)
        {
            this.Saldo = 150;
        }

        protected override void Registrar(double quantia, string HorarioDaMovimentacao)
        {
            this.Historico.Add($"Quantia R$ {quantia}  Empresa - Murder  Saldo restante R${Saldo}");
        }

    }

    public class VoucherBuilder
    {
        public static Voucher Create(int opcaoDeConta)
        => opcaoDeConta switch
        {
            1 => new Hell(),
            2 => new Murder(),
            3 => new Amazonas(),
            _ => throw new Exception("Conta não existente.")
        };
    }
}
