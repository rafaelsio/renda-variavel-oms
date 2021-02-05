using NUnit.Framework;

namespace RendaVariavel.OMS.TestesUnitarios
{
    public class Tests
    {
        
        [SetUp]
        public void Setup()
        {

            
        }

        [Test]
        public void NaoPermiteOrdemCompraNoFeriado()
        {
            var resultado = ordemCompraDominioServico.PermiteEnvioDeOrdemCompra();
            Assert(resultado.CodigoErro==OMS_014);
        }
    }
}