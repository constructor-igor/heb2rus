using System.Collections.Generic;

namespace Hebrew2Russian
{
    public class HebrewAlphabet
    {        
        public const char Alef = '\u05d0';
        public const char Bet = '\u05d1';
        public const char Gimel = '\u05d2';
        public const char Dalet = '\u05d3';
        public const char He = '\u05d4';
        public const char Vav = '\u05d5';
        public const char Zayin = '\u05d6';
        public const char Het = '\u05d7';
        public const char Tet = '\u05d8';
        public const char Yod = '\u05d9';
        public const char Kaf = '\u05db';
        public const char FinalKaf = '\u05da';
        public const char Lamed = '\u05dc';
        public const char Mem = '\u05de';
        public const char FinalMem = '\u05dd';
        public const char Nun = '\u05e0';
        public const char FinalNun = '\u05df';
        public const char Samekh = '\u05e1';
        public const char Ayin = '\u05e2';
        public const char Pe = '\u05e4';
        public const char FinalPe = '\u05e3';
        public const char Tsadi = '\u05e6';
        public const char FinalTsadi = '\u05e5'; 
        public const char Qof = '\u05e7';
        public const char Resh = '\u05e8';
        public const char Shin = '\u05e9';
        public const char Tav = '\u05ea';
    }

    public class RussianAlphabet
    {
        public const char a = '\u0430';
        public const char b = '\u0431';
    }

    public class Hebrew2RussianCharTranslit
    {
        public char HebrewChar { get; private set; }
        public char RussianChar { get; private set; }
        public Hebrew2RussianCharTranslit(char hebrewChar, char russianChar)
        {
            HebrewChar = hebrewChar;
            RussianChar = russianChar;
        }
    }
    public class Hebrew2RussianTranslit
    {
        readonly IList<Hebrew2RussianCharTranslit> rules = new List<Hebrew2RussianCharTranslit>();

        public Hebrew2RussianTranslit()
        {
            rules.Add(new Hebrew2RussianCharTranslit(HebrewAlphabet.Alef, RussianAlphabet.a));
            rules.Add(new Hebrew2RussianCharTranslit(HebrewAlphabet.Bet, RussianAlphabet.b));   
        }
        public string[] ConvertLines(string[] hebrewTextContent)
        {
            string[] russianTextContent = new string[hebrewTextContent.Length];
            for (int i = 0; i < hebrewTextContent.Length; i++)
            {
                string hebrewLineContent = hebrewTextContent[i];
                string russianLineContent = ConvertLine(hebrewLineContent);
                russianTextContent[i] = russianLineContent;
            }
            return russianTextContent;
        }

        public string ConvertLine(string hebrewLineContent)
        {
            string russianLineContent = "";
            for (int j = 0; j < hebrewLineContent.Length; j++)
            {
                char hebrewTextChar = hebrewLineContent[j];
                Hebrew2RussianCharTranslit foundRule = FindRule(hebrewTextChar);
                russianLineContent += foundRule.RussianChar;
            }
            return russianLineContent;
        }

        Hebrew2RussianCharTranslit FindRule(char hebrewTextChar)
        {
            foreach (Hebrew2RussianCharTranslit rule in rules)
            {
                if (rule.HebrewChar == hebrewTextChar)
                    return rule;
            }
            return new Hebrew2RussianCharTranslit(hebrewTextChar, hebrewTextChar);
        }
    }
}
