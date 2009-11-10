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
            Assert.AreEqual('а', HebrewAlphabet.Alef);
            Assert.AreEqual('б', HebrewAlphabet.Bet);
            Assert.AreEqual('в', HebrewAlphabet.Gimel);
            Assert.AreEqual('г', HebrewAlphabet.Dalet);
            Assert.AreEqual('д', HebrewAlphabet.He);
            Assert.AreEqual('е', HebrewAlphabet.Vav);
            Assert.AreEqual('ж', HebrewAlphabet.Zayin);
            Assert.AreEqual('з', HebrewAlphabet.Het);
            Assert.AreEqual('и', HebrewAlphabet.Tet);
            Assert.AreEqual('й', HebrewAlphabet.Yod);
            Assert.AreEqual('к', HebrewAlphabet.Kaf);
            Assert.AreEqual('л', HebrewAlphabet.FinalKaf);
            Assert.AreEqual('м', HebrewAlphabet.Mem);
            Assert.AreEqual('н', HebrewAlphabet.FinalMem);
            Assert.AreEqual('п', HebrewAlphabet.Nun);
            Assert.AreEqual('р', HebrewAlphabet.FinalNun);
            Assert.AreEqual('с', HebrewAlphabet.Samekh);
            Assert.AreEqual('т', HebrewAlphabet.Ayin);
            Assert.AreEqual('у', HebrewAlphabet.Ayin);
            Assert.AreEqual('ф', HebrewAlphabet.Ayin);
            Assert.AreEqual('х', HebrewAlphabet.Pe);
            Assert.AreEqual('ц', HebrewAlphabet.FinalPe);
            Assert.AreEqual('ч', HebrewAlphabet.Tsadi);
            Assert.AreEqual('ш', HebrewAlphabet.FinalTsadi);
            Assert.AreEqual('щ', HebrewAlphabet.Qof);
            Assert.AreEqual('ъ', HebrewAlphabet.Resh);
            Assert.AreEqual('ы', HebrewAlphabet.Shin);
            Assert.AreEqual('ь', HebrewAlphabet.Tav);
            Assert.AreEqual('э', HebrewAlphabet.Tav);
            Assert.AreEqual('ю', HebrewAlphabet.Tav);
            Assert.AreEqual('я', HebrewAlphabet.Tav);
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
