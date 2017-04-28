using System;
using System.Collections.Generic;
using Lab_3._3.Books;
using Lab_3._3.Books.Fictions;
using Lab_3._3.Books.History;
using Lab_3._3.Loaders;
using Lab_3._3.Loaders.FictionsLoaders;
using Lab_3._3.Loaders.HistoryLoaders;

namespace Lab_3._3.Helpers
{
    class LoaderManager
    {
        private static Dictionary<string, BookLoader> loaderDict = new Dictionary<string, BookLoader>
        {
            { "Book", new BookLoader() },
            { "Encyclopedia", new EncyclopediaLoader() },
            { "Historical", new HistoricalLoader() },
            { "Art", new ArtLoader() },
            { "Biography", new BiographyLoader() },
            { "Fiction", new FictionLoader() },
            { "Travelling", new TravellingLoader() },
            { "FantasticTales", new FantasticTalesLoader() },
            { "ScienceFiction", new ScienceFictionLoader() },
            { "FairyTales", new FairyTalesLoader() }
        };

        public static List<string> resultList = new List<string>
        {
            "Encyclopedia",
            "Art",
            "Biography",
            "Travelling",
            "ScienceFiction",
            "FairyTales"
        };

        public static BookLoader GetLoader(string key)
        {
            return loaderDict[key];
        }
    }
}
