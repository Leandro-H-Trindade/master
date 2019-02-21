using System.Collections.Generic;

namespace PackageFilmes.Models
{
    public class Filmes
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public double Nota { get; set; }

        public Filmes(string id, string titulo, int ano, double nota)
        {
            Id = id;
            Ano = ano;
            Nota = nota;
            Titulo = titulo;
        }

        public Filmes()
        {
        }

        public List<Filmes> IniciarCopadeFilmes(List<Filmes> filmes)
        {
            return Final.IniciarPartidas(SemiFinal.IniciarPartidas(QuatasDeFinal.IniciarPartidas(filmes)));
        }
    }
}
