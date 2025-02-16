using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStoryFroEveryting.Models.Singers;

namespace WebStoryFroEveryting.Controllers
{
    public class SingerController : Controller
    {
        public IActionResult Index()
        {
        var Singers = new List<SingerViewModel>
        {
              new()
        {
Pseudonym="Bruno Mars",
Src="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Bruno_Mars_Doowops.jpg/640px-Bruno_Mars_Doowops.jpg",
Style="Поп"
        },
              new ()
              {
                  Pseudonym="Rammstein",
                  Src="https://avatars.dzeninfra.ru/get-zen_doc/751940/pub_5aed0f7a9e29a23794d92d37_5aed1002fd96b16361b92f28/scale_1200",
                  Style="Метал"
              },
              new ()
            {
                  Pseudonym="Родион Газманов",
                  Src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRyxyvvJv7_NIVSFs5Uw0RVNqp27bmtBgaS7A&s",
                  Style="Эстрада"

              }
        };



        // GET: SingerController
        
             return View(Singers);
        }
    }
}
