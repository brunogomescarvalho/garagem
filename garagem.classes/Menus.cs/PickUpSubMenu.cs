using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace garagem.classes
{
    internal class PickUpSubMenu : SubMenu
    {
        private const byte ESCOLHER_CAMIONETE = 1;
        private const byte LICENCIAR = 2;
        private const byte MOSTRAR_GARAGEM = 3;
        private const byte ABASTECER = 4;
        private const byte CARREGAR = 5;
        private const byte EXCLUIR_PICK_UP = 6;
        private const byte VOLTAR_AO_MENU_INICIAL = 9;

        public PickUpSubMenu()
        {
            Option = VOLTAR_AO_MENU_INICIAL;
        }

        public override void Show()
        {
            while (Option != ESCOLHER_CAMIONETE || Option != LICENCIAR || Option != MOSTRAR_GARAGEM)
            {
                try
                {
                    Clear();
                    WriteLine("1 - Escolher Pick-Up");
                    WriteLine("2 - Licenciar");
                    WriteLine("3 - Mostrar Pick-Ups");
                    WriteLine("4 - Abastecer");
                    WriteLine("5 - Carregar");
                    WriteLine("6 - Excluir");
                    WriteLine("9 - Voltar ao Menu Inicial");
                    Option = byte.Parse(ReadLine());

                    switch (Option)
                    {
                        case ESCOLHER_CAMIONETE:
                            EscolherCamionete();
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
                        case CARREGAR:
                            CarregarCamionete();
                            break;
                        case EXCLUIR_PICK_UP:
                            ExcluirCamionete();
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
                if (item is PickUp && item.meuVeiculo)
                    WriteLine(item);
            }
            ReadKey();
        }

        public static void EscolherCamionete()
        {
            Clear();
            WriteLine("Escolha o tipo da Camionete:\n [1] LEVE [2] MÉDIA [3] PESADA");
            var opcao = ReadLine();
            PickUp.PICKUPS tipo = PickUp.PICKUPS.Leve;

            switch (opcao)
            {
                case "1":
                    tipo = PickUp.PICKUPS.Leve;
                    break;
                case "2":
                    tipo = PickUp.PICKUPS.Media;
                    break;
                case "3":
                    tipo = PickUp.PICKUPS.Pesada;
                    break;
                default:
                    throw new Exception("Opção Inválida");
            }

            PickUp pickUp = new PickUp();
            pickUp.Escolher(tipo);
            _garagem.AdicionarNaGaragem(pickUp);
            Clear();
            WriteLine(pickUp);
            ReadKey();
        }

        public static void Licenciar()
        {
            Clear();
            WriteLine("Digite a id do veiculo");
            var id = int.Parse(ReadLine());
            var licenciar = _garagem.PesquisarVeiculo(id);
            var licenciado = licenciar.Emplacar();
            Clear();
            WriteLine($"Sua placa é {licenciado}");
            ReadKey();
        }


        public static void Abastecer()
        {
            Clear();
            WriteLine("Digite a id do veiculo");
            var id = int.Parse(ReadLine());
            var veiculoParaAbastecer = _garagem.PesquisarVeiculo(id);
            WriteLine("Digite quanto litros deseja abastecer");
            var litros = int.Parse(ReadLine());
            var abasteceu = veiculoParaAbastecer.Abastece(litros);
        }

        public static void ExcluirCamionete()
        {
            Clear();
            WriteLine("Digite a Id da Pick-Up para excluir:");
            var id = int.Parse(ReadLine());
            var excluir = _garagem.PesquisarVeiculo(id);
            if (excluir.MeuTipo() == TipoVeiculo.PickUp)
            {
                _garagem.Excluir(id);
            }
            else
                throw new Exception("Nenhuma Pick-Up com essa Id Encontrada");

        }

        public static void CarregarCamionete()
        {
            Clear();
            WriteLine("Digite a Id da Pick-Up para carregar:");
            var id = int.Parse(ReadLine());
            WriteLine("Digite o peso da carga:");
            var peso = int.Parse(ReadLine());
            var pesquisa = _garagem.PesquisarVeiculo(id);
            var carregou = pesquisa.Carregar(peso);




        }

    }
}
