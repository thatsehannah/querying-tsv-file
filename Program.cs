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
            //Console.WriteLine(languages.Count);

            var prettifiedLanguages = languages.Select(l => l);
            //PrintList(prettifiedLanguages);

            var csharpLanguages = languages.Where(l => l.Name == "C#" || l.Predecessors.Contains("C#"));
            //PrintList(csharpLanguages);

            var microsoftLanguages = languages.Where(l => l.ChiefDeveloper == "Microsoft");
            //PrintList(microsoftLanguages);

            var lispDescendants = languages.Where(l => l.Predecessors.Contains("Lisp"));
            //PrintList(lispDescendants);

            var scriptLangauges = languages.Where(l => l.Name.Contains("Script"));
            //PrintList(scriptLangauges);

            var nearMillenniumLangugages = from l in languages
                                  where l.Year >= 1995 && l.Year <= 2005
                                  select $"{l.Name} was invented in {l.Year}";
            //Console.WriteLine(nearMillenniumLangugages.Count());
            //PrintList(nearMillenniumLangugages);

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
