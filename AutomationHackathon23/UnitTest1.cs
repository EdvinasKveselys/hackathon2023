using NUnit.Framework.Constraints;

namespace AutomationHackathon23
{
    public class Tests
    {
        ChromeDriver chrome { get; set; }

        [SetUp]
        public void Setup()
        {
            chrome = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            chrome.Quit();
            chrome.Dispose();
        }

        [Test]
        public void Test1()
        {
            chrome.Navigate().GoToUrl("http://www.google.com");

            var acceptButton = chrome.FindElement(By.XPath(".//button[.//div[normalize-space()='Priimti viską']]"));
            acceptButton.Click();

            var searchInput = chrome.FindElement(By.Name("q"));
            searchInput.SendKeys("devbridge");
            Thread.Sleep(500);
            searchInput.SendKeys(Keys.Enter);
            Thread.Sleep(500);

            var searchResults = chrome.FindElements(By.XPath(".//div[@class='g']"));
            var searchResult = searchResults[0];
            var link = searchResult.FindElement(By.CssSelector("a"));

            Assert.True(link.GetAttribute("href").Contains("devbridge.com"));
        }

        [Test]
        public void Task1()
        {
        }

        [Test]
        public void Task2()
        {
        }

        [Test]
        public void Task3()
        {
        }

        [Test]
        public void Task4()
        {
        }

        [Test]
        public void Task5()
        {
        }

        [Test]
        public void Task6()
        {
        }

        [Test]
        public void Task7()
        {
            chrome.Navigate().GoToUrl("https://ttt-gediminas.onrender.com/local-game");

            var diff = chrome.FindElement(By.Id("difficulty"));
            diff.Click();
            chrome.WaitForAndReturn(By.XPath(".//option[@value=1]")).Click();
            chrome.FindElement(By.Id("new-game")).Click();

            while (!chrome.FindElement(By.XPath(".//h1[@id='game-caption']")).Text.Contains("wins"))
            {
                var history = chrome.FindElements(By.XPath(".//*[@id='history-table']/tbody/tr"));
                if (history.Count >= 0 && history.Count%2 != 1)
                {
                    var cells = chrome.WaitForAndReturnElements(
                        By.XPath(".//td[starts-with(@class, 'cell')][contains(@class, 'enabled')]"));
                    var random = new Random();
                    var lol = random.Next(cells.Count);
                    cells[lol].Click();
                }
            }

            Thread.Sleep(5000);
        }
    }
// pyrst
}