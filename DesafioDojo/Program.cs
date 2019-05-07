using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDojo
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Console.WriteLine(seguro.Calcular().Result);
        }
    }
}
