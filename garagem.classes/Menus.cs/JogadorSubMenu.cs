using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using garagem.classes.pessoas.cs;

namespace garagem.classes.Menus.cs
{
    internal class JogadorSubMenu : SubMenu
    {

        private const byte CRIAR_JOGADOR = 1;
        private const byte OPCAO_JOGADORES = 2;
        private const byte OPCAO_VEICULOS = 3;
        private const byte VER_JOGADORES = 4;
        private const byte SAIR = 9;
        private bool continuar = true;

        public JogadorSubMenu()
        {
            Option = SAIR;
        }

        public override void Show()
        {
            while (continuar == true)
            {
                try
                {
                    Console.Clear();
                    System.Console.WriteLine("--- Bem Vindo ---");
                    Console.WriteLine("1 - Criar Jogador");
                    Console.WriteLine("2 - Opções Jogador");
                    Console.WriteLine("3 - Opcoes Veiculos");
                    Console.WriteLine("4 - Ver Jogadores");
                    Console.WriteLine("9 - Sair");
                    Option = byte.Parse(Console.ReadLine());

                    switch (Option)
                    {
                        case CRIAR_JOGADOR:
                            CriarPersonagem();
                            break;
                        case OPCAO_JOGADORES:
                            InformacoesJogador();
                            break;
                        case OPCAO_VEICULOS:
                            OpcoesVeiculos();
                            break;
                        case VER_JOGADORES:
                            Ver_Jogadores();
                            break;
                        case SAIR:
                            Sair();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine($"Opção inválida!");
                            Aguarde();
                            break;
                    }
                    if (Option == SAIR)
                    {
                        break;
                    }

                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }
        }

        public void CriarPersonagem()
        {
            try
            {
                Console.Clear();
                List<Pessoa> qtd = _gestao.MostrarPessoas();
                var temGente = _gestao.QuantidadeDeJogadores(qtd);
                if (!temGente.Equals(0))
                {
                    System.Console.WriteLine("Ainda não há suporte para mais jogadores.\n");
                    Aguarde();
                    Show();
                }
                System.Console.WriteLine("---- Bem Vindo -----");
                LojaDeVeiculos.Estoque(_garagem.Garagem);
                _gestao.trabalho.VagasDeEmprego(_gestao.trabalho.trabalho);

                System.Console.Write("Digite seu nome: ");
                var nickName = Console.ReadLine();

                Pessoa pessoa = new Pessoa(nickName, 1);

                _garagem.AdicionarNaGaragem(pessoa.veiculos);
                _gestao.AdicionarPessoa(pessoa);

                Console.Clear();

                System.Console.WriteLine($"Lages SC - {DateTime.Now.ToLongDateString()}\n\n"
                + $"\tOlá {pessoa.MeuNome()}.\n\tVocê agora tem uma conta bancária e uma garagem de automóveis." +
                $"\n\tVeja no menu suas opções.");
                Aguarde();
                Console.Clear();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        public void Sair()
        {
            bool confirmou = false;
            while (confirmou == false)
            {
                Console.Clear();
                System.Console.WriteLine("Tem certeza que deseja sair? S ou N ");
                var confirmacao = Console.ReadLine();
                if (confirmacao.ToUpper() == "N")
                    Show();
                if (confirmacao.ToUpper() == "S")
                {
                    confirmou = true;
                    continuar = false;
                }
            }
        }
        public static void InformacoesJogador()
        {

            const byte MINHA_GARAGEM = 1;
            const byte MINHA_CONTA = 2;
            const byte VER_EMPREGOS = 3;
            const byte HISTORICO_DE_TRABALHO = 4;
            const byte VOLTAR_AO_MENU_INICIAL = 5;
            var opcao = VOLTAR_AO_MENU_INICIAL;
            bool continuar = true;

            if (Verifica_Se_Existe_Jogador())
            {
                try
                {
                    while (continuar == true)
                    {
                        Console.Clear();
                        Console.WriteLine("1 - Minha Garagem");
                        Console.WriteLine("2 - Minha Conta Bancária");
                        Console.WriteLine("3 - Ver Empregos");
                        Console.WriteLine("4 - Histórico de Trabalho");
                        Console.WriteLine("5 - Voltar");

                        opcao = byte.Parse(Console.ReadLine());
                        switch (opcao)
                        {
                            case MINHA_GARAGEM:
                                MostrarMinhaGaragem();
                                break;
                            case MINHA_CONTA:
                                Opcoes_Conta();
                                break;
                            case VER_EMPREGOS:
                                ClassificadosDeEmpregos();
                                break;
                            case HISTORICO_DE_TRABALHO:
                                VerTRabalhosRealizados();
                                break;
                            case VOLTAR_AO_MENU_INICIAL:
                                continuar = false;
                                break;
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }

            }
        }

        public static bool Verifica_Se_Existe_Jogador()
        {
            Console.Clear();
            List<Pessoa> qtd = _gestao.MostrarPessoas();
            var temGente = _gestao.QuantidadeDeJogadores(qtd);
            if (temGente.Equals(0))
            {
                System.Console.WriteLine("É necessário primeiro criar um jogador.\n");
                Aguarde();
                return false;
            }
            return true;
        }

        public static void Opcoes_Conta()
        {
            const byte SALDO = 1;
            const byte EXTRATO = 2;
            const byte VOLTAR = 3;

            Console.Clear();
            Console.WriteLine("1 - Saldo");
            Console.WriteLine("2 - Extrato");
            Console.WriteLine("3 - Voltar");

            try
            {
                var opc = byte.Parse(Console.ReadLine());
                switch (opc)
                {
                    case SALDO:
                        Saldo();
                        break;
                    case EXTRATO:
                        MostrarHistorico();
                        break;
                    case VOLTAR:
                        break;
                    default:
                        throw new Exception("Opção inválida");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                Console.ReadKey();
            }


        }

        public static void MostrarHistorico()
        {
            Console.Clear();
            string minhaConta = _pessoa.voucher.InfoBanco();
            Console.WriteLine(minhaConta);
            Console.WriteLine("-------- Histórico --------");
            List<string> historico = _pessoa.voucher.HistoricoBancario();
            if (historico.Count != 0)
                foreach (var item in historico)
                {
                    Console.WriteLine(item);
                }
            else
                throw new Exception("Nenhuma movimentação registrada até o momento");
            Console.ReadKey();
        }

        public static void MinhaInfos()
        {
            Console.Clear();
            Console.WriteLine("Digite seu nome");
            var nome = Console.ReadLine();
            var minhasInfos = _gestao.PesquisarPessoa(nome);
            Console.Clear();
            Console.WriteLine("---- Meus Dados ----");
            Console.WriteLine($"Nome: {minhasInfos.MeuNome()}\n\n" +
            $"{_pessoa.voucher.InfoBanco()}");
            Console.ReadKey();
        }

        public static void Ver_Jogadores()
        {
            Console.Clear();
            Console.WriteLine("----- Jogadores -----");
            List<Pessoa> Pessoas = _gestao.MostrarPessoas();
            foreach (var item in Pessoas)
            {
                System.Console.WriteLine($"Nome: {item.MeuNome()}");
            }
            if (Pessoas.Count.Equals(0))
            {
                throw new Exception("Ainda não existem jogadores cadastrados.");
            }
            Console.ReadKey();

        }

        public static void MostrarMinhaGaragem()
        {
            Console.Clear();
            Console.WriteLine("----- Veículos Na Garagem ----");
            List<Veiculos> Garagem = _garagem.MostrarVeiculos();
            foreach (Veiculos item in Garagem)
            {
                if (item.meuVeiculo == true)
                    Console.WriteLine(item);
            }
            Console.ReadKey();

        }
        public static void Saldo()
        {
            Console.Clear();
            string minhaConta = _pessoa.voucher.InfoBanco();
            Console.WriteLine(minhaConta);
            Console.ReadKey();
        }

        public static void OpcoesVeiculos()
        {
            const byte CLASSIFICADOS_DE_VEICULOS = 1;
            const byte ABASTECER = 2;
            const byte EMPLACAR = 3;
            const byte VOLTAR_AO_MENU_INICIAL = 9;
            var opcao = VOLTAR_AO_MENU_INICIAL;
            bool continuar = true;

            if (Verifica_Se_Existe_Jogador())
            {
                try
                {
                    while (continuar == true)
                    {
                        Console.Clear();
                        Console.WriteLine("------ Veículos -----");
                        Console.WriteLine("1 - Ver Classificados");
                        Console.WriteLine("2 - Abastecer Veiculos");
                        Console.WriteLine("3 - Emplacar Veiculo");
                        Console.WriteLine("9 - Voltar");

                        opcao = byte.Parse(Console.ReadLine());
                        switch (opcao)
                        {
                            case CLASSIFICADOS_DE_VEICULOS:
                                ClassificadosDeVeiculos();
                                break;
                            case ABASTECER:
                                Abastecer();
                                break;
                            case EMPLACAR:
                                Licenciar();
                                break;
                            case VOLTAR_AO_MENU_INICIAL:
                                continuar = false;
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine($"Opção inválida!");
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }
        }
        public static void ClassificadosDeVeiculos()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("----- Veículos Á Venda -----\n");
                List<Veiculos> Garagem = _garagem.MostrarVeiculos();
                foreach (Veiculos item in Garagem)
                {
                    if (item.meuVeiculo == false)
                        Console.WriteLine(item.Classificados());
                }
                Console.ReadKey();

                System.Console.WriteLine("\nDeseja efetuar compra");
                System.Console.WriteLine("Digite S ou N");

                var resposta = Console.ReadLine();
                if (resposta.ToUpper() == "S")
                {
                    FazerCompra();
                }
                else if (resposta.ToUpper() == "N")
                {
                    Console.Clear();
                    System.Console.WriteLine("Obrigado pela visita, volte sempre");
                    Aguarde();
                }
                else throw new Exception("Opção Inválida");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        public static void FazerCompra()
        {
            try
            {
                Console.WriteLine("\n----- Escritório ------\n");
                _pessoa.voucher.LocalConveniado = LocalConveniado.Loja_De_Veiculos;
                Console.WriteLine("Digite a id do veiculo");
                var id = int.Parse(Console.ReadLine());
                var veiculoComprar = _garagem.PesquisarVeiculo(id);
                _pessoa.voucher.Usar(veiculoComprar.Preco);
                veiculoComprar.Comprar();
                Console.Clear();
                Console.WriteLine($"Parabens! Você acabou de comprar um(a) lindo(a) {veiculoComprar.Marca} {veiculoComprar.Modelo}" +
                $" pelo valor de R$ {veiculoComprar.Preco}.");
                Aguarde();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public static void Abastecer()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("----- Posto De Combustível ------");
                _pessoa.voucher.LocalConveniado = LocalConveniado.Posto_De_Combustivel;
                Console.WriteLine("Digite a do Veículo");
                var id = int.Parse(Console.ReadLine());
                var veiculoParaAbastecer = _garagem.PesquisarVeiculo(id);

                if (veiculoParaAbastecer.meuVeiculo && veiculoParaAbastecer.JaEmplacado())
                {
                    Console.WriteLine("Digite quanto litros deseja abastecer");
                    var litros = int.Parse(Console.ReadLine());
                    veiculoParaAbastecer.Abastece(litros);
                    _pessoa.voucher.Usar(veiculoParaAbastecer.TotalAPagar());
                    Aguarde();
                }
                else if (!veiculoParaAbastecer.meuVeiculo)
                {
                    throw new Exception("Voçê não possui esse veículo em sua garagem.");
                }
                else
                {
                    Solicita_Emplacar();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        public static void Licenciar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("----- Detran ------");
                _pessoa.voucher.LocalConveniado = LocalConveniado.Detram;
                Console.WriteLine("Digite a id do veiculo");
                var id = int.Parse(Console.ReadLine());
                var licenciar = _garagem.PesquisarVeiculo(id);

                if (licenciar.meuVeiculo)
                {
                    var licenciado = licenciar.Emplacar();
                    _pessoa.voucher.Usar(licenciar.PagarDetran());
                    Console.Clear();
                    Console.WriteLine($"A placa de sua {licenciar.MeuTipo()} é: {licenciado}\n");
                    Console.WriteLine($"A taxa do Detran custou R$ {licenciar.PagarDetran()}");
                    Aguarde();
                }
                else
                    throw new Exception("Voçê não possui esse veículo em sua garagem.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public static void ClassificadosDeEmpregos()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("----- Vagas Disponiveis -----\n");
                List<Trabalhos> Trabalho = _gestao.trabalho.trabalho;
                foreach (Trabalhos item in Trabalho)
                {
                    if (item.TrabalhoDisponivel())
                        Console.WriteLine(item);
                }
                Console.ReadKey();

                System.Console.WriteLine("\nDeseja aceitar algum trabalho");
                System.Console.WriteLine("Digite S ou N");

                var resposta = Console.ReadLine();
                if (resposta.ToUpper() == "S")
                {
                    IrTRabalhar();
                }
                else
                {
                    Console.Clear();
                    System.Console.WriteLine("Obrigado pela visita, volte sempre");
                    Aguarde();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

        }

        public static void IrTRabalhar()
        {
            Console.WriteLine("\n----- RH ------\n");
            _pessoa.voucher.LocalConveniado = LocalConveniado.Deposito;
            Console.WriteLine("Digite a id da vaga");
            var id = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a id do seu veiculo");
            var idveiculo = int.Parse(Console.ReadLine());

            try
            {
                var carroParaTrabalhar = _garagem.PesquisarVeiculo(idveiculo);
                var vagaParaTrabalhar = _gestao.trabalho.PesquisarVagas(id);
                double salario;
                if (carroParaTrabalhar.MeuTipo() == vagaParaTrabalhar.VeiculosParaTrabalhar)
                {
                    if (carroParaTrabalhar.JaEmplacado())
                    {
                        salario = _gestao.trabalho.AceitarTrabalho(vagaParaTrabalhar);
                        Obtem_Endereco();
                        _pessoa.voucher.Depositar(salario);
                        vagaParaTrabalhar.VagaPreenchida();
                        Console.Clear();
                        Console.WriteLine($"Você acabou de trabalhar na função: " +
                        $"{vagaParaTrabalhar.Descricao}\n e recebeu R${vagaParaTrabalhar.ValorPago}.");
                        Aguarde();
                    }
                    else
                    {
                        Solicita_Emplacar();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Seu veículo é incompátivel com o serviço \n" +
                    $"Voçê está de {carroParaTrabalhar.MeuTipo()} e requer um(a) {vagaParaTrabalhar.VeiculosParaTrabalhar}");
                    Aguarde();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public static void VerTRabalhosRealizados()
        {
            bool trabalhou = false;
            Console.Clear();
            Console.WriteLine("----- Registros de Trabalho -----\n");
            List<Trabalhos> Trabalho = _gestao.trabalho.trabalho;
            foreach (Trabalhos item in Trabalho)
            {
                if (!item.TrabalhoDisponivel())
                {
                    Console.WriteLine(item);
                    trabalhou = true;
                }
            }
            if (trabalhou == false && Trabalho.Contains(_gestao.trabalho) != _gestao.trabalho.TrabalhoDisponivel())
                System.Console.WriteLine("Nenhum trabalho registrado até o momento");
            Aguarde();

        }
        public static void Aguarde()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public static void Solicita_Emplacar()
        {
            Console.Clear();
            System.Console.WriteLine("Primeiro é preciso emplacar seu veículo, gostaria de fazer isso agora?\n");
            bool respostaEhValida = false;
            while (respostaEhValida == false)
            {
                System.Console.WriteLine("Digite S ou N");
                var opcao = Console.ReadLine();
                switch (opcao.ToUpper())
                {
                    case "S":
                        respostaEhValida = true;
                        Licenciar();
                        break;
                    case "N":
                        respostaEhValida = true;
                        break;
                    default: throw new Exception("Opção Inválida");
                }
                Console.ReadKey();
            }

        }

        public static void Obtem_Endereco()
        {
            Console.Clear();
            var endereco = _gestao.trabalho.ObtemEndereco();
            Console.WriteLine($"Endereço para entrega: {endereco}");
            Aguarde();
            Console.WriteLine("Calculando rota");
            Thread.Sleep(1200);
            Console.Write("Aguarde");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(1200);
            }
            Console.WriteLine("\nIniciando o percurso");
            Thread.Sleep(2000);
            Console.WriteLine("Pronto... Encomenda entregue com sucesso!");
            Thread.Sleep(2000);

        }

    }
}
