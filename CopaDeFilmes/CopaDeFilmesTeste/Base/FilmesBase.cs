using PackageFilmes.Models;
using System.Collections.Generic;

namespace CopaDeFilmesTeste.Base
{
    public class FilmesBase
    {
        public static List<Filmes> CriaLista()
        {
            return new List<Filmes>()
            {
                new Filmes("tt3606756","Os Incríveis 2",2018,8.5),
                new Filmes("tt4881806","Jurassic World: Reino Ameaçado",2018,6.7),
                new Filmes("tt5164214","Oito Mulheres e um Segredo",2018,6.3),
                new Filmes("tt7784604","Hereditário",2018,6.3),
                new Filmes("tt4154756","Vingadores: Guerra Infinita",2018,8.8),
                new Filmes("tt5463162","Deadpool 2",2018,8.1),
                new Filmes("tt3778644","Han Solo: Uma História Star Wars",2018,7.2),
                new Filmes("tt3501632","Thor: Ragnarok",2017,7.9),
            };
        }
    }
}
