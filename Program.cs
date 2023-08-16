using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace QueryingTsvFile
{
    class Program
    {
        static void Main()
        {
            List<Language> languages = File.ReadAllLines("./languages.tsv")
              .Skip(1)
              .Select(line => Language.FromTsv(line))
              .ToList();

            var prettifiedLanguages = languages.Select(l => l);
            //PrintList(prettifiedLanguages);

            var csharpLanguages = from l in languages
                                  where l.Name == "C#" || l.Predecessors.Contains("C#")
                                  select l;
            //PrintList(csharpLanguages);

            var microsoftLanguages = from l in languages
                                     where l.ChiefDeveloper == "Microsoft"
                                     select l;
            //PrintList(microsoftLanguages);

            var lispDescendants = from l in languages
                                  where l.Predecessors.Contains("Lisp")
                                  select l;
            //PrintList(lispDescendants);

            var scriptLangauges = from l in languages
                                  where l.Name.Contains("Script")
                                  select l;
            //PrintList(scriptLangauges);

            int languagesCount = languages.Count;
            Console.WriteLine(languagesCount);

            var nearMillenniumLangugages = from l in languages
                                  where l.Year >= 1995 && l.Year <= 2005
                                  select $"{l.Name} was invented in {l.Year}";
            int nearMillenniumCount = nearMillenniumLangugages.Count();
            Console.WriteLine(nearMillenniumCount);
            PrintList(nearMillenniumLangugages);

        }

        static void PrintList(IEnumerable<Language> list)
        {
            foreach (var l in list)
            {
                Console.WriteLine(l.Prettify());
            }
        }

        static void PrintList(IEnumerable<object> list)
        {
            foreach (var l in list)
            {
                Console.WriteLine(l);
            }
        }
    }
}
