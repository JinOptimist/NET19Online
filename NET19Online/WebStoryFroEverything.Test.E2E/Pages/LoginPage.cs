using OpenQA.Selenium;

namespace WebStoryFroEverything.Test.E2E.Pages
{
    public class LoginPage
    {
        public readonly static By UserName = By.CssSelector("#UserName");

        public readonly static By Password = By.CssSelector("#Password");

        public readonly static By ButtonSubmit = By.CssSelector("button[type=submit]");
    }
}
