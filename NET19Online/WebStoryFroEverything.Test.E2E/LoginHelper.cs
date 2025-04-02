using OpenQA.Selenium;
using WebStoryFroEverything.Test.E2E.Pages;

namespace WebStoryFroEverything.Test.E2E
{
    public static class LoginHelper
    {
        public static void Login(this IWebDriver webDriver, string userName, string password)
        {
            webDriver.Url = LoginTest.BASE_URL + "/Auth/Login";

            // Login page
            webDriver
                .FindElement(LoginPage.UserName)
                .SendKeys(userName);

            webDriver
                .FindElement(LoginPage.Password)
                .SendKeys(password);

            webDriver
                .FindElement(LoginPage.ButtonSubmit)
                .Click();
        }

        public static void Logout(this IWebDriver webDriver)
        {
            webDriver
                .FindElement(LayoutSelectors.LogoutLink)
                .Click();
        }
    }
}
