using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTests
    {
        [Fact]
        public void LeilaoComTresClientes()
        {
            //Arranje - Cénario
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var Maria = new Interessada("Maria", leilao);
            var beltrano = new Interessada("beltrano", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(Maria, 900);
            leilao.RecebeLance(Maria, 990);
            leilao.RecebeLance(beltrano, 1400);
            leilao.RecebeLance(fulano, 1000);

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert            
            var valorEsperado = 1400;            
            var valorObitido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObitido);
            Assert.Equal(beltrano, leilao.Ganhador.Cliente);
        }

        [Fact]
        public void LeilaoComLanceOrdenadosPorValor()
        {
            //Arranje - Cénario
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var Maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(Maria, 900);            
            leilao.RecebeLance(Maria, 990);
            leilao.RecebeLance(Maria, 999);
            leilao.RecebeLance(fulano, 1000);

            //Act - método sob teste
            leilao.TerminaPregao();

            //Assert
            var valorEsperado = 1000;
            var valorObitido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObitido);
        }

        [Fact]
        public void LeilaoComVariosLances()
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
            Assert.Equal(valorEsperado, valorObitido);

        }

        [Fact]
        public void LeilaoComApenasUmLance()
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

            Assert.Equal(valorEsperado, valorObitido);
        }
    }
}
