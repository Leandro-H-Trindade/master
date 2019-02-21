using NUnit.Framework;
using PackageFilmes.Models;
using CopaDeFilmesTeste.Base;
using System.Collections.Generic;

namespace CopaDeFilmesTeste
{
    [TestFixture]
    public class EliminatoriasTeste
    {
        private List<Filmes> filmes;
        private Filmes filme;

        [SetUp]
        public void Setup()
        {
            filme = new Filmes();
            filmes = FilmesBase.CriaLista();
        }

        [Test]
        public void RetornandoprimeiroESegundoLugar()
        {
            OrdenarFilmes.OrdenarPorTitulos(ref filmes);

            var retorno = filme.IniciarCopadeFilmes(filmes);

            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno[0].Titulo.Equals("Vingadores: Guerra Infinita"));
            Assert.IsTrue(retorno[1].Titulo.Equals("Os Incríveis 2"));
        }

        [Test]
        public void VencedorPorEmpate()
        {
            OrdenarFilmes.OrdenarPorTitulos(ref filmes);

            filmes[0].Nota = 8.8;

            var retorno = filme.IniciarCopadeFilmes(filmes);

            Assert.IsNotNull(retorno);
            Assert.IsTrue(retorno[0].Titulo.Equals("Deadpool 2"));
            Assert.IsTrue(retorno[1].Titulo.Equals("Os Incríveis 2"));
        }

    }
}
