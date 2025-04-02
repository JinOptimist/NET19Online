using Enums.User;
using OpenQA.Selenium;

namespace WebStoryFroEverything.Test.E2E.Pages
{
    public class ProfilePage
    {
        public static By LocalSelectOption = By.CssSelector($"#newLocal");

        public static By ButtonSubmitLocal = By.CssSelector(".form-locale button[type=submit]");
    }
}
