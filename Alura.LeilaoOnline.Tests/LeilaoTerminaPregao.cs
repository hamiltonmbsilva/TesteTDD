using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(double valorEsperado, double [] ofertas)
        {
            //Arranje - Cénario
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i % 2) == 0)
                {
                    leilao.RecebeLance(fulano, valor);
                }
                else
                {
                    leilao.RecebeLance(maria, valor);
                }

            }


            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert            
            var valorObitido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObitido);

        }

        [Fact]
        public void RetornaZeroDadoLeilaoSemLance()
        {            
                //Arranje - Cénario
                var leilao = new Leilao("Van Gogh");  

                //Act - método sob teste
                leilao.TerminaPregao();

                //Assert
                var valorEsperado = 0;
                var valorObitido = leilao.Ganhador.Valor;

                Assert.Equal(valorEsperado, valorObitido);            
        }

        
    }
}
