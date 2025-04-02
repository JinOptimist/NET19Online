using Enums.User;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebStoryFroEverything.Test.E2E.Pages;

namespace WebStoryFroEverything.Test.E2E
{
    public class LoginTest
    {
        private IWebDriver _webDriver;

        public const string BASE_URL = "https://localhost:7055";

        [OneTimeSetUp]
        public void SetUp()
        {
            _webDriver = new ChromeDriver();
        }

        [Test]
        public void CheckThatAdminCanLongin()
        {
            // Home page as a guest
            _webDriver.Url = BASE_URL;

            _webDriver
                .FindElement(LayoutSelectors.LoginLink)
                .Click();

            // Login page
            _webDriver
                .FindElement(LoginPage.UserName)
                .SendKeys("admin");

            _webDriver
                .FindElement(LoginPage.Password)
                .SendKeys("admin");

            _webDriver
                .FindElement(LoginPage.ButtonSubmit)
                .Click();

            // Home page but logged in
            _webDriver
                .FindElement(LayoutSelectors.ProfileLink)
                .Click();

            _webDriver.Logout();

            Assert.Pass();
        }

        [TestCase(UserLocale.Russian, "Выйти")]
        [TestCase(UserLocale.English, "Logout")]
        public void CheckThatUserCanSwitchLocale(UserLocale locale, string logoutText)
        {
            _webDriver.Login("admin", "admin");
            _webDriver.Url = BASE_URL + "/Home/Profile";

            var waiter = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(3));

            waiter
                .Until(x => x.FindElement(ProfilePage.LocalSelectOption))
                .Click();

            var serlectForLocale = waiter
                    .Until(x => x.FindElement(ProfilePage.LocalSelectOption));
            var localSelect = new SelectElement(serlectForLocale);
            localSelect.SelectByValue(((int)locale).ToString());

            _webDriver
                .FindElement(ProfilePage.ButtonSubmitLocal)
                .Click();

            var actualLogoutLinkText = _webDriver
                .FindElement(LayoutSelectors.LogoutLink)
                .Text;

            Assert.That(actualLogoutLinkText == logoutText);

            _webDriver.Logout();
        }

        [OneTimeTearDown]
        public void Down()
        {
            _webDriver.Close();
        }
    }
}
