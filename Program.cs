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

            var prettifiedLanguages = languages.Select(l => l.Prettify());
            //foreach (var l in prettifiedLanguages)
            //{
            //    Console.WriteLine(l);
            //}

            var csharpLanguages = from l in languages
                                  where l.Name == "C#" || l.Predecessors.Contains("C#")
                                  select l.Prettify();
            //foreach (var l in csharpLanguages)
            //{
            //    Console.WriteLine(l);
            //}

            var microsoftLanguages = from l in languages
                                     where l.ChiefDeveloper == "Microsoft"
                                     select l.Prettify();
            foreach (var l in microsoftLanguages)
            {
                Console.WriteLine(l);
            }

        }
    }
}
