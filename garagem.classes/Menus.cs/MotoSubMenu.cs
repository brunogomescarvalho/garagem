using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace garagem.classes
{
    internal class MotoSubMenu : SubMenu
    {
        private const byte ESCOLHER_MOTO = 1;
        private const byte LICENCIAR = 2;
        private const byte MOSTRAR_GARAGEM = 3;
        private const byte ABASTECER = 4;
        private const byte EXCLUIR_MOTO = 5;
        private const byte VOLTAR_AO_MENU_INICIAL = 9;

        public MotoSubMenu()
        {
            Option = VOLTAR_AO_MENU_INICIAL;
        }
        public override void Show()
        {
            while (Option != ESCOLHER_MOTO || Option != LICENCIAR || Option != MOSTRAR_GARAGEM)
            {
                try
                {
                    Clear();
                    WriteLine("1 - Escolher Moto");
                    WriteLine("2 - Licenciar");
                    WriteLine("3 - Mostrar Motos");
                    WriteLine("4 - Abastecer");
                    WriteLine("5 - Excluir Moto");
                    WriteLine("9 - Voltar ao Menu Inicial");
                    Option = byte.Parse(ReadLine());

                    switch (Option)
                    {
                        case ESCOLHER_MOTO:
                            EscolherMoto();
                            break;
                        case LICENCIAR:
                            Licenciar();
                            break;
                        case MOSTRAR_GARAGEM:
                            MostrarGaragem();
                            break;
                        case ABASTECER:
                            Abastecer();
                            break;
                        case EXCLUIR_MOTO:
                            ExcluirMoto();
                            break;
                        case VOLTAR_AO_MENU_INICIAL:
                            break;
                        default:
                            Clear();
                            WriteLine($"Opção inválida!");

                            Wait();
                            break;
                    }
                    if (Option == VOLTAR_AO_MENU_INICIAL)
                        break;
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                    ReadKey();
                }
            }
        }

        public static void MostrarGaragem()
        {
            Clear();
            List<Veiculos> Garagem = _garagem.MostrarVeiculos();
            foreach (Veiculos item in Garagem)
            {
                if (item is Moto && item.meuVeiculo)
                    WriteLine(item);
            }
            ReadKey();
        }

        public static void EscolherMoto()
        {
            Clear();
            WriteLine("Escolha o tipo de Moto:\n [1] URBANA [2] OFF_ROAD [3] VIAGEM");
            var opcao = ReadLine();

            Moto.MOTOS tipo = Moto.MOTOS.Viagem;

            switch (opcao)
            {
                case "1":
                    tipo = Moto.MOTOS.Urbana;
                    break;
                case "2":
                    tipo = Moto.MOTOS.OffRoad;
                    break;
                case "3":
                    tipo = Moto.MOTOS.Viagem;
                    break;
                default:
                    throw new Exception("Opção Inválida");
            }

            Moto moto = new Moto();
            moto.Escolher(tipo);
            _garagem.AdicionarNaGaragem(moto);
            Clear();
            WriteLine(moto);
            ReadKey();
        }

        public static void Licenciar()
        {
            Clear();
            WriteLine("Digite a id do veiculo");
            var id = int.Parse(ReadLine());
            var licenciar = _garagem.PesquisarVeiculo(id);

            if (licenciar.MeuTipo() == TipoVeiculo.Moto)
            {
                var licenciado = licenciar.Emplacar();
                Clear();
                WriteLine($"Sua placa é {licenciado}");
                ReadKey();
            }
            else
                throw new Exception("Nenhuma moto com essa Id Encontrada");
        }

        public static void Abastecer()
        {
            Clear();
            WriteLine("Digite a Id da Moto");
            var id = int.Parse(ReadLine());
            var veiculoParaAbastecer = _garagem.PesquisarVeiculo(id);

            if (veiculoParaAbastecer.MeuTipo() == TipoVeiculo.Moto)
            {
                WriteLine("Digite quanto litros deseja abastecer");
                var litros = ushort.Parse(ReadLine());
                var abasteceu = veiculoParaAbastecer.Abastece(litros);
            }
            else
                throw new Exception("Nenhuma moto com essa Id Encontrada");
        }

        public static void ExcluirMoto()
        {
            Clear();
            WriteLine("Digite a Id da Moto para excluir:");
            var id = int.Parse(ReadLine());
            var excluir = _garagem.PesquisarVeiculo(id);

            if (excluir.MeuTipo() == TipoVeiculo.Moto)
            {
                _garagem.Excluir(id);
            }
            else
                throw new Exception("Nenhuma moto com essa Id Encontrada");
        }
    }
}