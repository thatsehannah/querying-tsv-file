namespace QueryingTsvFile
{
    public class Language
    {
        public static Language FromTsv(string tsvLine)
        {
            string[] values = tsvLine.Split('\t');
            Language lang = new Language(
              Convert.ToInt32(values[0]),
              Convert.ToString(values[1]),
              Convert.ToString(values[2]),
              Convert.ToString(values[3]));
            return lang;
        }

        //When the language was invented
        public int Year
        { get; set; }

        //The name of the language
        public string Name
        { get; set; }

        //The head developer and/or company responsible for making the language
        public string ChiefDeveloper
        { get; set; }

        //The other programming languages taht this language is based on
        public string Predecessors
        { get; set; }

        //Constructor
        public Language(int year, string name, string chiefDeveloper, string predecessors)
        {
            Year = year;
            Name = name;
            ChiefDeveloper = chiefDeveloper;
            Predecessors = predecessors;
        }

        //Returns a nicely formatted string version of the object
        public string Prettify()
        {
            return $"{Year}, {Name}, {ChiefDeveloper}, {Predecessors}";
        }
    }
}