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
                var retorno = vmfilmes.FiltraLista(GetSession("Filmes"), filmesids);
                FilmesList = vmfilmes.Iniciar(retorno);
                CriarSession(FilmesList, "Ganhadores");

                //return FilmesList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Resultado()
        {
            return View("Resultado", GetSession("Ganhadores"));
        }

        private void CriarSession(List<Filmes> filmes, string name)
        {
            HttpContext.Session.Remove(name);
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
    }
}