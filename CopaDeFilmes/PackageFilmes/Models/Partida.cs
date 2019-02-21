using System;
using System.Collections.Generic;

namespace PackageFilmes.Models
{
    public class Partida
    {
        public static List<Filmes> RealizarPartidas(List<Filmes> filmes, int rodada)
        {
            var ListaAux = new List<Filmes>();

            for (int i = 0; i < rodada; i++)
            {
                var vencedor = Confrontos(filmes[i], filmes[(filmes.Count - 1) - i]);
                ListaAux.Add(vencedor);
            }

            return ListaAux;
        }

        private static Filmes Confrontos(Filmes a, Filmes b)
        {
            try
            {
                if (a.Nota >= b.Nota)
                    return a;
                else
                    return b;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao realizar o confronto: {ex.InnerException.Message}");
            }
        }
    }
}
