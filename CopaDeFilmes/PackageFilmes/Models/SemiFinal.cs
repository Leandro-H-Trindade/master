using System.Collections.Generic;

namespace PackageFilmes.Models
{
    public class SemiFinal : Partida
    {
        public static List<Filmes> IniciarPartidas(List<Filmes> filmes)
        {
            return RealizarPartidas(filmes, 2);
        }
    }
}
