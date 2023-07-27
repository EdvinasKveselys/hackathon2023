using NUnit.Framework.Constraints;
using OpenQA.Selenium.Interactions;

using System.Speech.Synthesis;

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
        public void Task1()
        {
        }

       [Test]
        public void Task2()
        {
            chrome.Navigate().GoToUrl("https://www.mathster.com/10secondsmaths/");

            var slider = chrome.FindElement(By.XPath(".//div[@class='tooltip']"));
            new Actions(chrome).ClickAndHold(slider).MoveByOffset(250, 0).Release().Build().Perform();

            var checkboxes = chrome.FindElements(By.XPath(".//input[@type='checkbox']"));
            for (int i = 1; i < checkboxes.Count; i++)
            {
                var checkbox = checkboxes[i];
                checkbox.Click();
            }
            
            try
            {
                while (!chrome.FindElement(By.XPath(".//div[@id='results']")).Displayed)
                {
                    if (chrome.FindElement(By.XPath(".//div[@id='results']")).Displayed)
                    {
                        break;
                    }

                    var question = chrome.FindElement(By.XPath(".//p[@id='question']"));
                    var questionText = question.Text;

                    string[] split;
                    double first;
                    double second;
                    double result = 0;

                    if (questionText.Contains("+"))
                    {
                        split = questionText.Split("+");
                        first = int.Parse(split[0]);
                        second = int.Parse(split[1]);
                        result = first + second;
                    }

                    if (questionText.Contains("-"))
                    {
                        split = questionText.Split("-");
                        first = int.Parse(split[0]);
                        second = int.Parse(split[1]);
                        result = first - second;
                    }

                    if (questionText.Contains("÷"))
                    {
                        split = questionText.Split("÷");
                        first = int.Parse(split[0]);
                        second = int.Parse(split[1]);
                        result = first / second;
                    }

                    if (questionText.Contains("×"))
                    {
                        split = questionText.Split("×");
                        first = int.Parse(split[0]);
                        second = int.Parse(split[1]);
                        result = first * second;
                    }

                    if (questionText.Contains("√"))
                    {
                        split = questionText.Split("√");
                        second = double.Parse(split[1]);
                        result = Math.Sqrt(second);
                    }

                    if (questionText.Contains("²"))
                    {
                        split = questionText.Split("²");
                        second = double.Parse(split[0]);
                        result = Math.Pow(second, 2);
                    }

                    if (questionText.Contains("³"))
                    {
                        split = questionText.Split("³");
                        second = double.Parse(split[0]);
                        result = Math.Pow(second, 3);
                    }

                    var answerBow = chrome.FindElement(By.XPath(".//input[@id='question-answer']"));
                    answerBow.SendKeys(result.ToString());
                }

            }
            catch (Exception e)
            {
                Thread.Sleep(5000);
            }
            
            Thread.Sleep(5000);
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
            
        string lyrics = "Yo we're here in Hackathon's scene\n" +
                       "Agota's smart Gintare coding queen\n" +
                       "Edvinas plans Veetoutas schemes\n" +
                       "A dream team fearless and keen\n" +
                       "In the hood we stand tall no doubt\n" +
                       "Obstacles vanish we route 'em out\n" +
                       "Gangsta coders on a mission true\n" +
                       "Bringing fire coding miracles we do\n" +
                       "The baddest we're quick none sicker\n" +
                       "Hackathon kings none's quicker\n" +
                       "Sucker don't mess we run the show\n" +
                       "Coding flow we steal the glow\n" +
                       "In coding dojo we raise the bar\n" +
                       "Agota's algorithms a guiding star\n" +
                       "Gintare's UIs like art they are\n" +
                       "Edvinas' tactics precision par\n" +
                       "Veetoutas hustles never rests\n" +
                       "Innovating we're the best\n" +
                       "No challenge big we're on the quest\n" +
                       "Arena skills put to test\n" +
                       "The baddest we're quick none sicker\n" +
                       "Hackathon kings none's quicker\n" +
                       "Sucker don't mess we run the show\n" +
                       "Coding flow we steal the glow\n" +
                       "Late-night brainstorm ignite\n" +
                       "Hand in hand expand with might\n" +
                       "Agota's insights shine so bright\n" +
                       "Gintare's designs pure delight\n" +
                       "Edvinas' strategies masterstroke\n" +
                       "Veetoutas' hustle never broke\n" +
                       "Collaboration our secret tool\n" +
                       "Together we rule break the rule\n" +
                       "The baddest we're quick none sicker\n" +
                       "Hackathon kings none's quicker\n" +
                       "Sucker don't mess we run the show\n" +
                       "Coding flow we steal the glow\n" +
                       "Agota Gintare Edvinas Veetoutas the crew\n" +
                       "Broke through Hackathon courage we drew\n" +
                       "Intelligence and might we grew\n" +
                       "Together conquer any height it's true.";
        
            string[] lines = lyrics.Split('\n');
            
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            int barTimeMilliseconds = 5;

            try
            {
                chrome.Navigate().GoToUrl("https://chordu.com/chords-tabs-50-cent-if-i-can-t-official-instrumental-hq-id_bwW7WY0rRXE");
                
                IWebElement hourglassPlayButton = chrome.FindElement(By.XPath("//*[@id='hourglass_play_btn']"));
                hourglassPlayButton.Click();

                System.Threading.Thread.Sleep(650);

                foreach (string line in lines)
                {
                    synthesizer.Speak(line);
                    Thread.Sleep(barTimeMilliseconds);
                }
                
                chrome.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                synthesizer.Dispose();
            }
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
}