using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoryFroEverything.Test.E2E.Pages
{
    public class UnderwaterHunterPage
    {
        public readonly static By UnderwaterHunterLink 
            = By.CssSelector("a.underwaterHunterFirstButton");
        
        public readonly static By CommentAndTagLink 
            = By.CssSelector("a.leave-comment");
        
        public readonly static By NewTag
            = By.CssSelector(".tagForm input[type=search]");
       
        public readonly static By ButtonSubmitNewTag
            = By.CssSelector(".tagForm button[type=submit]");
        
        public readonly static By NewComment
            = By.CssSelector(".commentForm input[type=search]");
        
        public readonly static By ButtonSubmitNewComment
                = By.CssSelector(".commentForm button[type=submit]");
        
        public readonly static By MenuLink
                = By.CssSelector(".mainPage a.button-addNewHunter");
    }
}
