using Xunit;
using Alura.LeilaoOnline.Core;
using System.Linq;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Fact]
        public void NaoAceitaProximoLanceDadoMesmoClienteRealizouUltimoLance()
        {
            //Arranje - Cénario
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            leilao.IniciaPregao();
            leilao.RecebeLance(fulano, 800);           


            //Act - método sob teste
            leilao.RecebeLance(fulano, 1000);

            //Assert 
            var qtdEsperada = 1;
            var qtdObitido = leilao.Lances.Count();
            Assert.Equal(qtdEsperada, qtdObitido);
        }

        [Theory]
        [InlineData(4, new double[] { 1000, 1200, 1400, 1300})]
        [InlineData(2, new double[] { 800, 900})]
        public void NaoPermiteNovosLancesDadosLeilaoFinalizado(int qtdEsperada, double[] ofertas)
        {
            //Arranje - Cénario
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i%2)==0)
                {
                    leilao.RecebeLance(fulano, valor);
                }
                else
                {
                    leilao.RecebeLance(maria, valor);
                }
                
            }
            
            leilao.TerminaPregao();


            //Act - método sob teste
            leilao.RecebeLance(fulano, 1000);

            //Assert 
            
            var qtdObitido = leilao.Lances.Count();
            Assert.Equal(qtdEsperada, qtdObitido);
        }
    }
}
