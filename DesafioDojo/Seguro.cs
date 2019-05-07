using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDojo
{
    public class Seguro
    {
        #region Propriedades

        public decimal Valor { get; set; }
        public int Idade { get; set; }
        public int Sexo { get; set; }
        public int EstadoCivil { get; set; }
        public int Historico { get; set; }
        public bool Garagem { get; set; }
        public bool ItensSeguranca { get; set; }   
        public string CEP { get; set; }

        #endregion

        #region Métodos

        public async Task<double> Calcular()
        {
            double fator = 1;
            if (Sexo == 0)
            {
                if (EstadoCivil == 0)
                {
                    if (Idade > 17 && Idade <= 20)
                    {
                        fator += 0.55;
                    }
                    else if (Idade > 20 && Idade <= 25)
                    {
                        fator += 0.45;
                    }
                    else if (Idade > 25 && Idade <= 30)
                    {
                        fator += 0.35;
                    }
                    else if (Idade > 30 && Idade <= 40)
                    {
                        fator += 0.25;
                    }
                    else if (Idade > 40)
                    {
                        fator += 0.15;
                    }
                }
                else if(EstadoCivil == 1)
                {
                    if (Idade > 17 && Idade <= 20)
                    {
                        fator += 0.45;
                    }
                    else if (Idade > 20 && Idade <= 25)
                    {
                        fator += 0.35;
                    }
                    else if (Idade > 25 && Idade <= 30)
                    {
                        fator += 0.25;
                    }
                    else if (Idade > 30 && Idade <= 40)
                    {
                        fator += 0.15;
                    }
                    else if (Idade > 40)
                    {
                        fator += 0.05;
                    }
                }
            }
            else if (Sexo == 1)
            {
                if(EstadoCivil == 0)
                {
                    if (Idade > 17 && Idade <= 20)
                    {
                        fator += 0.45;
                    }
                    else if (Idade > 20 && Idade <= 25)
                    {
                        fator += 0.35;
                    }
                    else if (Idade > 25 && Idade <= 30)
                    {
                        fator += 0.25;
                    }
                    else if (Idade > 30 && Idade <= 40)
                    {
                        fator += 0.15;
                    }
                    else if (Idade > 40)
                    {
                        fator += 0.05;
                    }
                }
                else if(EstadoCivil == 1)
                {
                    if (Idade > 17 && Idade <= 20)
                    {
                        fator += 0.35;
                    }
                    else if (Idade > 20 && Idade <= 25)
                    {
                        fator += 0.25;
                    }
                    else if (Idade > 25 && Idade <= 30)
                    {
                        fator += 0.15;
                    }
                    else if (Idade > 30 && Idade <= 40)
                    {
                        fator += 0.05;
                    }
                    else if (Idade > 40)
                    {
                        fator += 0.02;
                    }
                }
               
            }
            if (Valor > 0 && Valor <= 10000)
            {
                fator += 0.1;
            }
            else if (Valor > 10000 && Valor <= 30000)
            {
                fator += 0.2;
            }
            else if (Valor > 30000 && Valor <= 80000)
            {
                fator += 0.3;
            }
            else if (Valor > 80000)
            {
                fator += 0.4;
            }
            if (Historico == 1)
            {
                fator += 0.2;
            }
            else if (Historico > 1)
            {
                fator += 0.5;
            }
            if (Garagem)
            {
                fator += 0.2;
            }
            else
            {
                if (ItensSeguranca)
                {
                    fator += 0.4;
                }
                else
                {
                    fator += 0.8;
                }                
            }
            HttpClient hc = new HttpClient();            
            HttpResponseMessage response = await hc.GetAsync(string.Format("https://viacep.com.br/ws/{0}/json/", CEP));
            string content = await response.Content.ReadAsStringAsync();   
            if(string.IsNullOrEmpty(content))
            {
                return 0;
            }
            JObject jo = JObject.Parse(content);
            string cidade = (string)jo["localidade"];
            if (cidade == "São Paulo")
            {
                fator += 0.3;
            }
            if (cidade == "Osasco")
            {
                fator += 0.6;
            }
            return 914.18 * fator;
        }

        #endregion
    }
}
