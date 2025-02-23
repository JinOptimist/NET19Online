using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebStoryFroEveryting.Models.AnimeGirl;
using WebStoryFroEveryting.Models.Aromatherapy;

namespace WebStoryFroEveryting.Controllers
{
    public class AromatherapyController : Controller
    {


        public IActionResult AromatherapyIndex()
        {
            var viewModels = new List<AromaticObjectViewModel>
            {
                new AromaticObjectViewModel
                {
                    Id = 1,
                    Name = "Stella Fragrance TONKA+MACADAMIA",
                    ObjectType = "Свеча",
                    Description = "Свеча с нежным сочетанием ароматов сахарной пудры, ванили, гиацинтов, макадамии, бобов тонка и мускуса",
                    Price = 13.88,
                    Src = "https://pcdn.goldapple.ru/p/p/19000008017/web/696d674d61696e5f66363463336465393265626334613534616162653532393562323662653434398dcfe7407a27e86fullhd.webp"
                },
                new AromaticObjectViewModel
                {
                    Id = 2,
                    Name = "Stella Fragrance SALT CARAMEL",
                    ObjectType = "Свеча",
                    Description = "Свеча с сочетанием ароматов карамели, пралине, лакрицы, лимона, ванили и дубового мха",
                    Price = 13.88,
                    Src = "https://pcdn.goldapple.ru/p/p/19000349011/web/696d674d61696e5f62313830303037656564613934646361613763363263623336643137636265308dd194ea575dc2ffullhd.webp"
                },
                new AromaticObjectViewModel
                {
                    Id = 3,
                    Name = "Aroma harmony Wind flower",
                    ObjectType = "Аромадиффузор",
                    Description = "Сочетание освежающих аккордов с легкими цветочными нюансами, переходящих к нежному аромату тюльпана и фрезии, завершаются оттенками розы и нежным гиацинтом",
                    Price = 21.69,
                    Src = "https://pcdn.goldapple.ru/p/p/19000268044/web/696d674d61696e8dc841045e9e10bfullhd.webp"
                },
                new AromaticObjectViewModel
                {
                    Id = 4,
                    Name = "Aroma harmony Euphoria",
                    ObjectType = "Аромадиффузор",
                    Description = "Аромат с нотами зелени, инжира, с древесными нотами, мускусом и молоком",
                    Price = 17.75,
                    Src = "https://pcdn.goldapple.ru/p/p/19000268018/web/696d674d61696e8dc8410438da0bafullhd.webp"
                },
                
            };

            return View(viewModels);
        }
    }
}
