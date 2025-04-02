using OpenQA.Selenium;

namespace WebStoryFroEverything.Test.E2E.Pages
{
    public class LayoutSelectors
    {
        public static By ProfileLink = By.CssSelector("a.profile");
        public static By LoginLink = By.CssSelector("a.login");

        public static By LogoutLink = By.CssSelector("a.logout");
    }
}
