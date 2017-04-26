using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_3._3.Loaders;

namespace Lab_3._3.Helpers
{
    class LoaderManager
    {
        private static Dictionary<string, BookLoader> loaderDict = new Dictionary<string, BookLoader>
        {
            { "Book", new BookLoader() }/*,
            { "Encyclopedia", new EncyclopediaLoader() },
            { "Historical", new HistoricalLoader() },
            { "Art", new ArtLoader() },
            { "Biography", new BiographyLoader() },
            { "Fiction", new FictionLoader() },
            { "Travelling", new TravellingLoader() },
            { "FantasticTales", new FantasticTalesLoader() },
            { "ScienceFiction", new ScienceFictionLoader() },
            { "FairyTales", new FairyTalesLoader() }*/
        };

        public static BookLoader GetLoader(string key)
        {
            return loaderDict[key];
        }
    }
}
