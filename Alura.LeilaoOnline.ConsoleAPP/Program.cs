using Alura.LeilaoOnline.Core;
using System;

namespace Alura.LeilaoOnline.ConsoleAPP
{
    class Program
    {

        private static void Verifica(double esperado, double obtido)
        {
            var cor = Console.ForegroundColor;
            if (esperado == obtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Teste Ok");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    $"Teste Falhou! Esperado:{esperado}, Obtido: {obtido}.");
            }

            Console.ForegroundColor = cor;
        }
        private static void LeilaoComVariosLances()
        {
            //Arranje - Cénario
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var Maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(Maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(Maria, 990);
            leilao.RecebeLance(Maria, 999);

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 1000;
            var valorObitido = leilao.Ganhador.Valor;
            Verifica(valorEsperado, valorObitido);
            
        }

        private static void LeilaoComApenasUmLance()
        {
            //Arranje - Cénario
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            

            leilao.RecebeLance(fulano, 800);
            

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 800;
            var valorObitido = leilao.Ganhador.Valor;

            Verifica(valorEsperado, valorObitido);
        }


        static void Main()
        {
            LeilaoComVariosLances();
            LeilaoComApenasUmLance();
           
        }
    }
}
