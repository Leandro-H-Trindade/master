using System;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using PackageFilmes.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace CopaDeFilmes.Models
{
    public class VmFilmes
    {
        private string Uri { get; set; }

        public VmFilmes(IConfiguration config)
        {
            Uri = config["ApiRepos"];
        }

        public VmFilmes() { }

        public async Task<List<Filmes>> GetListaDeFilmes()
        {
            try
            {
                using (var client = new HttpClient())
                using (var response = client.GetAsync(Uri).Result)
                {
                    if (response.IsSuccessStatusCode)
                        return JsonConvert.DeserializeObject<List<Filmes>>(await response.Content.ReadAsStringAsync());
                    else
                        throw new Exception("Erro ao converter a lista de filmes.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }

        public List<Filmes> Iniciar(List<Filmes> filmes)
        {
            OrdenarFilmes.OrdenarPorTitulos(ref filmes);

            return new Filmes().IniciarCopadeFilmes(filmes);
        }

        public List<Filmes> FiltraLista(List<Filmes> filmes, List<string> Filmesids)
        {
            var aux = new List<Filmes>();

            for (int i = 0; i < Filmesids.Count; i++)
            {
                var filme = filmes.Where(f => f.Id.Equals(Filmesids[i])).FirstOrDefault();
                aux.Add(filme);
            }

            return aux;
        }
    }
}
