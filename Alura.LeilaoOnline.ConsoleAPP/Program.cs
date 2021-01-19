using Alura.LeilaoOnline.Core;
using System;

namespace Alura.LeilaoOnline.ConsoleAPP
{
    class Program
    {
        static void Main()
        {
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var Maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(Maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(Maria, 990);
            leilao.RecebeLance(Maria, 999);

            leilao.TerminaPregao();

            Console.WriteLine(leilao.Ganhador.Valor);
        }
    }
}
