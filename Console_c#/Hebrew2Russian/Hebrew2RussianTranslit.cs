using System;
using System.Collections.Generic;

namespace Hebrew2Russian
{
    public class HebrewChar
    {
        public char Character { get; private set; }
        public HebrewChar(char character)
        {
            Character = character;
        }
    }
    public class Hebrew2RussianCharTranslit
    {
        public HebrewChar HebrewChar { get; private set; }
        public String RussianCharSet { get; private set; }
        public Hebrew2RussianCharTranslit(char hebrewChar, char russianChar): this(hebrewChar, new string(russianChar, 1))
        {            
        }
        public Hebrew2RussianCharTranslit(char hebrewChar, char[] russianCharSet): this(hebrewChar, new string(russianCharSet))
        {
        }
        public Hebrew2RussianCharTranslit(char hebrewChar, string russianCharSet)
        {
            HebrewChar = new HebrewChar(hebrewChar);
            RussianCharSet = russianCharSet;
        }
    }
    public class Hebrew2RussianTranslit
    {
        readonly IList<Hebrew2RussianCharTranslit> rules = new List<Hebrew2RussianCharTranslit>();

        public Hebrew2RussianTranslit()
        {
            AddRule(HebrewAlphabet.Alef, "");
            AddRule(HebrewAlphabet.Bet, RussianAlphabet.b);
            AddRule(HebrewAlphabet.Gimel, RussianAlphabet.g);
            AddRule(HebrewAlphabet.Dalet, RussianAlphabet.d);
            //AddRule(HebrewAlphabet.He, new char[] {RussianAlphabet.xe, RussianAlphabet.eee, RussianAlphabet.i_kratkoe});
            AddRule(HebrewAlphabet.He, "");
            AddRule(HebrewAlphabet.Vav, RussianAlphabet.ve);
            AddRule(HebrewAlphabet.Zayin, RussianAlphabet.z);
            AddRule(HebrewAlphabet.Het, RussianAlphabet.xe);
            AddRule(HebrewAlphabet.Tet, RussianAlphabet.t);
            AddRule(HebrewAlphabet.Yod, RussianAlphabet.i_kratkoe);
            AddRule(HebrewAlphabet.Kaf, RussianAlphabet.k);
            AddRule(HebrewAlphabet.FinalKaf, RussianAlphabet.k);
            AddRule(HebrewAlphabet.Lamed, RussianAlphabet.l);
            AddRule(HebrewAlphabet.Mem, RussianAlphabet.m);
            AddRule(HebrewAlphabet.FinalMem, RussianAlphabet.m);
            AddRule(HebrewAlphabet.Nun, RussianAlphabet.n);
            AddRule(HebrewAlphabet.FinalNun, RussianAlphabet.n);
            AddRule(HebrewAlphabet.Samekh, RussianAlphabet.s);
            AddRule(HebrewAlphabet.Ayin, RussianAlphabet.a);
            AddRule(HebrewAlphabet.Pe, RussianAlphabet.p);
            AddRule(HebrewAlphabet.FinalPe, RussianAlphabet.p);
            AddRule(HebrewAlphabet.Tsadi, RussianAlphabet.tz);
            AddRule(HebrewAlphabet.FinalTsadi, RussianAlphabet.tz);
            AddRule(HebrewAlphabet.Qof, RussianAlphabet.k);
            AddRule(HebrewAlphabet.Resh, RussianAlphabet.r);
            AddRule(HebrewAlphabet.Shin, RussianAlphabet.she);
            AddRule(HebrewAlphabet.Tav, RussianAlphabet.t);
        }
        void AddRule(char hebrewChar, string russianChar)
        {
            rules.Add(new Hebrew2RussianCharTranslit(hebrewChar, russianChar));
        }
        void AddRule(char hebrewChar, char russianChar)
        {
            rules.Add(new Hebrew2RussianCharTranslit(hebrewChar, russianChar));
        }
        void AddRule(char hebrewChar, char[] russianCharSet)
        {
            rules.Add(new Hebrew2RussianCharTranslit(hebrewChar, russianCharSet));
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

            int position = 0;
            while (position < hebrewLineContent.Length)
            {
                char currentTextChar = hebrewLineContent[position++];
                bool isHebrewCharacter = currentTextChar>=HebrewAlphabet.Alef && currentTextChar <= HebrewAlphabet.Tav;
                if (isHebrewCharacter)
                {
                    HebrewChar currentChar = new HebrewChar(currentTextChar);
                    Hebrew2RussianCharTranslit foundRule = FindRule(currentChar.Character);
                    russianLineContent += foundRule.RussianCharSet;
                } else
                {
                    string resultChar;
                    switch (currentTextChar)
                    {
                        case Niqqud.Shva:
                        case Niqqud.ReducedSegol:
                        case Niqqud.Segol:
                        case Niqqud.SinDot_left:
                        case Niqqud.Dagesh:
                        case Niqqud.SinDot_right:
                            resultChar = "";
                            break;
                        case Niqqud.Hiriq:
                            resultChar = new string(new char[] {RussianAlphabet.i});
                            break;
                        case Niqqud.ReducedPatach:
                        case Niqqud.ReducedKamatz:
                        case Niqqud.Patach:
                        case Niqqud.Kamatz:
                            resultChar = new string(new char[] {RussianAlphabet.a});
                            break;
                        case Niqqud.Zeire:
                            resultChar = new string(new char[] {RussianAlphabet.e});
                            break;
                        case Niqqud.Kubutz:
                            resultChar = new string(new char[] {RussianAlphabet.y});
                            break;
                        default:
                            resultChar = new string(new char[] { currentTextChar });
                            break;
                    }
                    russianLineContent += resultChar;
                }
            }
            return russianLineContent;
        }

        Hebrew2RussianCharTranslit FindRule(char hebrewTextChar)
        {
            foreach (Hebrew2RussianCharTranslit rule in rules)
            {
                if (rule.HebrewChar.Character == hebrewTextChar)
                    return rule;
            }
            return new Hebrew2RussianCharTranslit(hebrewTextChar, hebrewTextChar);
        }
    }
}
