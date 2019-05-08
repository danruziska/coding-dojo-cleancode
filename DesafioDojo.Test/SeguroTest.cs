using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesafioDojo.Test
{
    [TestClass]
    public class SeguroTest
    {
        [TestMethod]
        public void DeveRetornarValorCorretoDeCalculo()
        {
            //Arrange
            Seguro seguro = new Seguro()
            {
                Valor = 34000,
                EstadoCivil = 0,
                Garagem = false,
                Historico = 1,
                Idade = 27,
                ItensSeguranca = false,
                Sexo = 0,
                CEP = "06065020"
            };
            //Act
            double valorFranquiaCalculada = seguro.Calcular().Result;
            //Assert
            Assert.AreEqual(2971.085, valorFranquiaCalculada);
        }
    }
}
