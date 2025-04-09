using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoryFroEverything.Test.E2E.Pages
{
    class JerseySelectors
    {
        public readonly static By ReadMoreLink
            = By.CssSelector(".jersey a.button");
        public readonly static By Tags
            = By.CssSelector(".tag");
        public readonly static By PlayerName
            = By.CssSelector(".jersey .name");
        public readonly static By Jersey
            = By.CssSelector(".jersey");
        public readonly static By DeleteJerseyButton
            = By.CssSelector(".button.red");

        //create jersey form
        public readonly static By AthleteNameInput
            = By.CssSelector("#AthleteName");
        public readonly static By ImgInput
            = By.CssSelector("#Img");
        public readonly static By SecondImgInput
            = By.CssSelector("#SecondImg");
        public readonly static By NumberInput
            = By.CssSelector("#Number");
        public readonly static By ClubInput
            = By.CssSelector("#Club");
        public readonly static By InStockInput
            = By.CssSelector("#InStock");
        public readonly static By PriceInput
            = By.CssSelector("#Price");
        public readonly static By SubmitButton
           = By.CssSelector("#content button");
    }
}
