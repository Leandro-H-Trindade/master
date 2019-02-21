using CopaDeFilmesTeste.Base;
using NUnit.Framework;
using PackageFilmes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CopaDeFilmesTeste
{
    [TestFixture]
    public class OrdenacaoFimesTeste
    {
        private List<Filmes> filmes;

        [SetUp]
        public void Setup()
        {
            filmes = FilmesBase.CriaLista();
        }

        [Test]
        public void OrdenandoListadeFilmesPorTitulo()
        {
            OrdenarFilmes.OrdenarPorTitulos(ref filmes);

            Assert.IsTrue(filmes[0].Titulo.Equals("Deadpool 2"));
            Assert.IsTrue(filmes[1].Titulo.Equals("Han Solo: Uma História Star Wars"));
            Assert.IsTrue(filmes[2].Titulo.Equals("Hereditário"));
            Assert.IsTrue(filmes[3].Titulo.Equals("Jurassic World: Reino Ameaçado"));
            Assert.IsTrue(filmes[4].Titulo.Equals("Oito Mulheres e um Segredo"));
            Assert.IsTrue(filmes[5].Titulo.Equals("Os Incríveis 2"));
            Assert.IsTrue(filmes[6].Titulo.Equals("Thor: Ragnarok"));
            Assert.IsTrue(filmes[7].Titulo.Equals("Vingadores: Guerra Infinita"));
        }

        [Test]
        public void OrdenandoListadeFilmesPorNota()
        {
            OrdenarFilmes.OrdenarPorNota(ref filmes);
            
            Assert.IsTrue(filmes[0].Titulo.Equals("Vingadores: Guerra Infinita"));
        }
    }
}
