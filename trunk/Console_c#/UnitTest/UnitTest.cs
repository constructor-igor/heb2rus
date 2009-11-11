using Hebrew2Russian;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest
    {
        TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestCreation()
        {
            Hebrew2RussianTranslit translit = new Hebrew2RussianTranslit();
            Assert.IsNotNull(translit);
        }
        
        [TestMethod]
        public void TestHebrewAlphaBet()
        {
            Assert.AreEqual('א', HebrewAlphabet.Alef);
            Assert.AreEqual('ב', HebrewAlphabet.Bet);
            Assert.AreEqual('ג', HebrewAlphabet.Gimel);
            Assert.AreEqual('ד', HebrewAlphabet.Dalet);
            Assert.AreEqual('ה', HebrewAlphabet.He);
            Assert.AreEqual('ו', HebrewAlphabet.Vav);
            Assert.AreEqual('ז', HebrewAlphabet.Zayin);
            Assert.AreEqual('ח', HebrewAlphabet.Het);
            Assert.AreEqual('ט', HebrewAlphabet.Tet);
            Assert.AreEqual('י', HebrewAlphabet.Yod);
            Assert.AreEqual('כ', HebrewAlphabet.Kaf);
            Assert.AreEqual('ך', HebrewAlphabet.FinalKaf);
            Assert.AreEqual('ל', HebrewAlphabet.Lamed);
            Assert.AreEqual('מ', HebrewAlphabet.Mem);
            Assert.AreEqual('ם', HebrewAlphabet.FinalMem);
            Assert.AreEqual('נ', HebrewAlphabet.Nun);
            Assert.AreEqual('ן', HebrewAlphabet.FinalNun);
            Assert.AreEqual('ס', HebrewAlphabet.Samekh);
            Assert.AreEqual('ע', HebrewAlphabet.Ayin);
            Assert.AreEqual('פ', HebrewAlphabet.Pe);
            Assert.AreEqual('ף', HebrewAlphabet.FinalPe);
            Assert.AreEqual('צ', HebrewAlphabet.Tsadi);
            Assert.AreEqual('ץ', HebrewAlphabet.FinalTsadi);
            Assert.AreEqual('ק', HebrewAlphabet.Qof);
            Assert.AreEqual('ר', HebrewAlphabet.Resh);
            Assert.AreEqual('ש', HebrewAlphabet.Shin);
            Assert.AreEqual('ת', HebrewAlphabet.Tav);
        }

        [TestMethod]
        public void TestRussianAlphaBet()
        {
            // http://en.wikipedia.org/wiki/Russian_alphabet
            Assert.AreEqual('а', RussianAlphabet.a);
            Assert.AreEqual('б', RussianAlphabet.b);
            Assert.AreEqual('в', RussianAlphabet.ve);
            Assert.AreEqual('г', RussianAlphabet.g);
            Assert.AreEqual('д', RussianAlphabet.d);
            Assert.AreEqual('е', RussianAlphabet.e);
            Assert.AreEqual('ж', RussianAlphabet.j);
            Assert.AreEqual('з', RussianAlphabet.z);
            Assert.AreEqual('и', RussianAlphabet.i);
            Assert.AreEqual('й', RussianAlphabet.i_kratkoe);
            Assert.AreEqual('к', RussianAlphabet.k);
            Assert.AreEqual('л', RussianAlphabet.l);
            Assert.AreEqual('м', RussianAlphabet.m);
            Assert.AreEqual('н', RussianAlphabet.n);
            Assert.AreEqual('о', RussianAlphabet.o);
            Assert.AreEqual('п', RussianAlphabet.p);
            Assert.AreEqual('р', RussianAlphabet.r);
            Assert.AreEqual('с', RussianAlphabet.s);
            Assert.AreEqual('т', RussianAlphabet.t);
            Assert.AreEqual('у', RussianAlphabet.y);
            Assert.AreEqual('ф', RussianAlphabet.fe);
            Assert.AreEqual('х', RussianAlphabet.xe);
            Assert.AreEqual('ц', RussianAlphabet.tz);
            Assert.AreEqual('ч', RussianAlphabet.che);
            Assert.AreEqual('ш', RussianAlphabet.she);
            Assert.AreEqual('щ', RussianAlphabet.sche);
            Assert.AreEqual('ъ', RussianAlphabet.tverdyi_znak);
            Assert.AreEqual('ы', RussianAlphabet.yy);
            Assert.AreEqual('ь', RussianAlphabet.myagkyi_znak);
            Assert.AreEqual('э', RussianAlphabet.eee);
            Assert.AreEqual('ю', RussianAlphabet.u);
            Assert.AreEqual('я', RussianAlphabet.ya);
        }

        [TestMethod]
        public void TestSample_r5gor()
        {
            const string hebrewInput = "יִתְגַּדַּל וְיִתְקַדַּשׁ שְׁמֵהּ רַבָּא";
            const string expectedRussianResult = "йитгадал вейиткадаш шемэ раба";
            Hebrew2RussianTranslit translit = new Hebrew2RussianTranslit();
            string actualRussianResult = translit.ConvertLine(hebrewInput);
            Assert.AreSame(expectedRussianResult, actualRussianResult);
        }
    }
}
