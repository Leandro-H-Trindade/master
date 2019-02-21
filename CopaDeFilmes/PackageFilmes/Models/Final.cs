using System.Collections.Generic;

namespace PackageFilmes.Models
{
    public class Final : Partida
    {
        public static List<Filmes> IniciarPartidas(List<Filmes> filmes)
        {
            OrdenarFilmes.OrdenarPorNota(ref filmes);

            return filmes;
        }
    }
}
