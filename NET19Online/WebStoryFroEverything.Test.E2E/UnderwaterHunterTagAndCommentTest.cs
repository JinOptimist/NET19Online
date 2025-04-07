using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoryFroEverything.Test.E2E.Pages;

namespace WebStoryFroEverything.Test.E2E
{
    public class UnderwaterHunterTagAndCommentTest
    {
        ChromeDriver _webDriver;

        [OneTimeSetUp]
        public void SetUp()
        {
            _webDriver = new ChromeDriver();
        }

        [Test]
        public void CheckThatRegisteredUserCanLeaveCommentAndTag()
        {
            _webDriver.Login("admin", "admin");

            _webDriver
                .FindElement(UnderwaterHunterPage.UnderwaterHunterLink)
                .Click();

            _webDriver
                .FindElement(UnderwaterHunterPage.CommentAndTagLink)
                .Click();

            _webDriver
                .FindElement(UnderwaterHunterPage.NewTag)
                .SendKeys("The best hunter");

            _webDriver
                .FindElement(UnderwaterHunterPage.ButtonSubmitNewTag)
                .Click();

            _webDriver 
                 .FindElement(UnderwaterHunterPage.NewComment)
                 .SendKeys("Cool");

            _webDriver
                .FindElement(UnderwaterHunterPage.ButtonSubmitNewComment)
                .Click();

            _webDriver
                .FindElement(UnderwaterHunterPage.MenuLink)
                .Click();

            Assert.Pass();
        }
    }
}
