using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTests
    {
        [Theory]
        [InlineData(1000, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void LeilaoComVariosLances(double valorEsperado, double [] ofertas)
        {
            //Arranje - Cénario
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            

            foreach(var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }
            

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert            
            var valorObitido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObitido);

        }

        [Fact]
        public void LeilaoSemLances()
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
