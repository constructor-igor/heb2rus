using System.IO;

namespace Hebrew2Russian
{
    class Program
    {
        static void Main(string[] args)
        {
            string textHebrewFileName = args[0];
            string textRussianFileName = args[1];

            Hebrew2RussianTranslit hebrew2RussianTranslit = new Hebrew2RussianTranslit();

            string[] hebrewTextContent = File.ReadAllLines(textHebrewFileName);
            string[] russianTextContent = hebrew2RussianTranslit.ConvertLines(hebrewTextContent);

            File.WriteAllLines(textRussianFileName, russianTextContent);
        }

    }
}
