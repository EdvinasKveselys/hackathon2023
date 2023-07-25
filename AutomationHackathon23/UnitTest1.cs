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
            chrome.Navigate().GoToUrl("http://www.google1.com");

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
        }
    }
}