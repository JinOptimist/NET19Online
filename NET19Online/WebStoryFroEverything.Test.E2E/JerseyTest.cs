using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoryFroEverything.Test.E2E.Pages;
using OpenQA.Selenium.Edge;
using System.Diagnostics;

namespace WebStoryFroEverything.Test.E2E
{
    public class JerseyTest
    {
        private IWebDriver _webDriver;

        public const string BASE_URL = "https://localhost:7055";

        [OneTimeSetUp]
        public void SetUp()
        {
            _webDriver = new ChromeDriver();
        }

        [Test]
        public void CheckUserCanClickToTags()
        {
            _webDriver.Url = String.Concat(BASE_URL , "/jerseys/");

            _webDriver
                .FindElements(JerseySelectors.Tags)
                .Where(x => x.Text == "arsenal")
                .First()
                .Click();

            var list = _webDriver
                .FindElements(JerseySelectors.PlayerName)
                .Where(x => x.Text == "Alexander Hleb")
                .ToList();
            Assert.That(list.Count == 1);
            
        }

        [Test]
        public void CheckAdminCanCreateJerseys()
        {
            
            _webDriver.Login("admin", "admin");
            _webDriver.Url = String.Concat(BASE_URL, "/jerseys/create/");

            _webDriver
                .FindElement(JerseySelectors.AthleteNameInput)
                .SendKeys("test");
            _webDriver
                .FindElement(JerseySelectors.ImgInput)
                .SendKeys("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRGjSzn324Hdc6dK-QTg8S4qc8F_ifUbi61-g&s");
            _webDriver
                .FindElement(JerseySelectors.SecondImgInput)
                .SendKeys("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRGjSzn324Hdc6dK-QTg8S4qc8F_ifUbi61-g&s");
            _webDriver
                .FindElement(JerseySelectors.NumberInput)
                .SendKeys("10");
            _webDriver
                .FindElement(JerseySelectors.ClubInput)
                .SendKeys("test club");
            _webDriver
                .FindElement(JerseySelectors.InStockInput)
                .SendKeys("12");
            _webDriver
                .FindElement(JerseySelectors.PriceInput)
                .SendKeys("11");
            _webDriver
                .FindElement(JerseySelectors.SubmitButton)
                .Click();
            
            _webDriver.Url = String.Concat(BASE_URL, "/jerseys/");

            var testJerseys = _webDriver
                .FindElements(JerseySelectors.Jersey)
                .SkipLast(2)
                .Where(x => x.FindElement(By.CssSelector(".name")).Text == "test")
                .ToList();

            
            Assert.That(testJerseys.Count == 1);

            foreach(var testJersey in testJerseys)
            {
                testJersey
                    .FindElement(JerseySelectors.DeleteJerseyButton)
                    .Click();
            }
        }
        [OneTimeTearDown]
        public void Down()
        {
            _webDriver.Quit();
        }
    }
}
