using Microsoft.Extensions.Configuration;
using PackageConversao.Model;
using System.Collections.Generic;

namespace WebConversao.Models
{
    public class ConfigViewModel
    {
        private string Url { get; set; }
        public IList<Moeda> Moedas { get; private set; }

        public ConfigViewModel()
        {
            Url = string.Empty;
            Moedas = new List<Moeda>();
        }

        public string Uri(IConfiguration _config)
        {
            Url += _config["ConfigWebApi:ApiUri"];
            Url += _config["ConfigWebApi:Endpoint"];
            Url += $"?access_key={_config["ConfigWebApi:AccessKey"]}";

            return Url;
        }

        public IList<Moeda> CotacoesDados(string json)
        {
            var lista = json.Split(",");

            var aux = lista[5].Split("{")[1].Replace(@"\", "").Split(":");
            AddLista(aux);

            for (int i = 6; i < 15; i++)
            {
                var aux1 = lista[i].Replace(@"\", "").Split(":");
                AddLista(aux1);
            }

            return Moedas;
        }

        private void AddLista(string[] aux)
        {
            Moedas.Add(new Moeda(aux[0], 0, double.Parse(aux[1])));
        }
    }
}