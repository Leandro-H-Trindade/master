using System;
using Newtonsoft.Json;
using CopaDeFilmes.Models;
using PackageFilmes.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace CopaDeFilmes.Controllers
{
    public class FilmesController : Controller
    {
        private readonly IConfiguration _config;
        private List<Filmes> FilmesList;

        public FilmesController(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IActionResult> SelecionarFilmes()
        {
            try
            {
                RemoveSession("Ganhadores");
                FilmesList = GetSession("Filmes");

                if (FilmesList == null)
                {
                    FilmesList = await new VmFilmes(_config).GetListaDeFilmes();
                    CriarSession(FilmesList, "Filmes");
                }

                return View(FilmesList);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new ErrorViewModel { RequestId = $"{ex.Message}" });
            }
        }

        public void ResultaDoCampeonato(List<string> filmesids)
        {
            var vmfilmes = new VmFilmes();

            try
            {
                FilmesList = GetSession("Filmes");

                if (FilmesList != null)
                {
                    var retorno = vmfilmes.FiltraLista(FilmesList, filmesids);
                    FilmesList = vmfilmes.Iniciar(retorno);
                    CriarSession(FilmesList, "Ganhadores");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Resultado()
        {
            var lista = GetSession("Ganhadores");

            if (lista != null)
                return View("Resultado", lista);
            else
                return RedirectToAction("SelecionarFilmes", "Filmes");
        }

        private void CriarSession(List<Filmes> filmes, string name)
        {
            RemoveSession(name);
            HttpContext.Session.SetString(name, JsonConvert.SerializeObject(filmes));
        }

        private List<Filmes> GetSession(string name)
        {
            var session = HttpContext.Session.GetString(name);

            if (!String.IsNullOrEmpty(session))
                return JsonConvert.DeserializeObject<List<Filmes>>(session);
            else
                return null;
        }

        private void RemoveSession(string name)
        {
            HttpContext.Session.Remove(name);
        }
    }
}