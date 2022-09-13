using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using garagem.classes;
using garagem.classes.pessoas.cs;

namespace garagem.classes
{
    internal abstract class SubMenu
    {
        protected byte Option { get; set; }
        public static garagemDeCarros _garagem { get; private set; } = new garagemDeCarros();
        public static Pessoa _pessoa { get; private set; } = new Pessoa(" ", 1);
        public static Gestao _gestao { get; private set; } = new Gestao();

      

        public abstract void Show();

        public void Wait()
        {
            WriteLine("Pressione qualquer tecla para continuar...");
            ReadKey();
        }
    }
}