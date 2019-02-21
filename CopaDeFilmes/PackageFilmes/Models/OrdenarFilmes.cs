using System;
using System.Linq;
using System.Collections.Generic;

namespace PackageFilmes.Models
{
    public class OrdenarFilmes
    {
        public static void OrdenarPorTitulos(ref List<Filmes> filmes)
        {
            try
            {
                filmes = filmes.OrderBy(f => f.Titulo).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível retornar a lista ordenada por título! \r\n Erro: {ex.InnerException.Message}");
            }
        }

        public static void OrdenarPorNota(ref List<Filmes> filmes)
        {
            try
            {
                filmes = filmes.OrderByDescending(f => f.Nota).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível retornar a lista ordenada por nota! \r\n Erro: {ex.InnerException.Message}");
            }
        }
    }
}
