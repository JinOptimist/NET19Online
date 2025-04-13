using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoryFroEverything.Test.E2E.Pages
{
    public class FilmSelector
    {
        public static readonly By CreateFilmLink = By.CssSelector("a.Film");
        public static readonly By CreateNewFilmLink = By.CssSelector("a.createfilms");
        public static readonly By InputNameNewFilm = By.CssSelector("input[name='Name']");
        public static readonly By InputNewSrcFilm = By.CssSelector("input[name='Src']");
        public static readonly By CrateFilmButton = By.CssSelector("button[type=submit]");
    }
}
