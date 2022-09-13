using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace garagem.classes
{
    internal class CarroSubMenu : SubMenu
    {
        private const byte ESCOLHER_CARRO = 1;
        private const byte LICENCIAR = 2;
        private const byte MOSTRAR_GARAGEM = 3;
        private const byte VOLTAR_AO_MENU_INICIAL = 9;

        public CarroSubMenu()
        {
            Option = VOLTAR_AO_MENU_INICIAL;
        }
        public override void Show()
        {

        }
    }
}