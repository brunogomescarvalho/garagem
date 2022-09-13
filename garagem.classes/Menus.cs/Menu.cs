using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using garagem.classes.Menus.cs;

namespace garagem.classes
{
    public static class Menu
    {
        private static byte _mode;
        private static SubMenu _subMenu;
        private const byte PICK_UP_MODE = 1;
        private const byte CARRO_MODE = 2;
        private const byte MOTO_MODE = 3;
        private const byte JOGADOR_MODE = 4;
        private const byte QUIT_OPTION = 9;

        public static void Show()
        {
            _subMenu = new JogadorSubMenu();
            _subMenu.Show();
        }
        public static void ModoGaragem()
        {  //em breve
            while (_mode != PICK_UP_MODE || _mode != CARRO_MODE || _mode != MOTO_MODE)
            {
                Clear();
                WriteLine("Bem vindo ao sistema de GARAGEM do Trop Tech!");
                WriteLine("Escolha o modo de execução: ");
                WriteLine("1 - PickUp ");
                WriteLine("2 - Carro");
                WriteLine("3 - Moto");
                WriteLine("4 - JOGADOR");
                WriteLine("9 - Sair");
                _mode = byte.Parse(ReadLine());

                switch (_mode)
                {
                    case PICK_UP_MODE:
                        _subMenu = new PickUpSubMenu();
                        break;
                    case CARRO_MODE:
                        _subMenu = new CarroSubMenu();
                        break;
                    case MOTO_MODE:
                        _subMenu = new MotoSubMenu();
                        break;
                    case JOGADOR_MODE:
                        _subMenu = new JogadorSubMenu();
                        break;
                    case QUIT_OPTION:
                        break;
                    default:
                        Clear();
                        WriteLine($"Opção inválida!");
                        WriteLine("Pressione qualquer tecla para continuar...");
                        ReadKey();
                        Clear();
                        break;
                }

                if (_mode == QUIT_OPTION)
                    break;

                _subMenu.Show();
            }
        }

    }
}
