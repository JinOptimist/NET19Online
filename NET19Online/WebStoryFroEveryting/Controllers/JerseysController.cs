using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStoryFroEveryting.Models.Jerseys;

namespace WebStoryFroEveryting.Controllers
{
    public class JerseysController : Controller
    {
        public static List<JerseyViewModel> ViewModels = new List<JerseyViewModel>
        {
            new JerseyViewModel
            {
                Id = 1,
                Number = 13,
                Club = "Arsenal London",
                AthleteName = "Alexander Hleb",
                Img = "https://www.classicfootballshirts.co.uk/cdn-cgi/image/fit=pad,q=70,f=webp//pub/media/catalog/product//8/e/8e30e917d15d511e7c56fe6324ec6747f82203d821561425a7e9d3bba8444533.jpeg"
            },
            new JerseyViewModel
            {
                Id = 2,
                Number = 32,
                Club = "Inter Milano",
                AthleteName = "Christian Vieri",
                Img = "https://mvps.com/wp-content/uploads/2024/08/VINICIUS-JR-10.png"
            },
            new JerseyViewModel
            {
                Id = 3,
                Number = 8,
                Club = "Chelsea",
                AthleteName = "Frank Lampard",
                Img = "https://m.teamzo.com/images/re-2000-2001-chelsea-home-shirt-lampard-8-1634121735.png"
            },
            new JerseyViewModel
            {
                Id = 4,
                Number = 8,
                Club = "Liverpool",
                AthleteName = "Steven Gerrard",
                Img = "https://static1.cdn-subsidesports.com/2/media/catalog/product/cache/abbf5437a995fd7cabd85bbbc7fdfb0f/6/e/6e69f2bc318389dc394c1c703c6b86e8a71ff9bfd7f668694811b958e2abe5af.jpeg"
            },
            new JerseyViewModel
            {
                Id = 5,
                Number = 8,
                Club = "San Antonio Spurs",
                AthleteName = "Tim Dunkan",
                Img = "https://fanatics.frgimages.com/san-antonio-spurs/mens-mitchell-and-ness-tim-duncan-white-san-antonio-spurs-1998/99-hardwood-classics-swingman-jersey_pi4380000_ff_4380764-a03c7aa111c6b00fcce5_full.jpg?_hv=2"
            },
            new JerseyViewModel
            {
                Id = 6,
                Number = 34,
                Club = "Los Angeles Lakers",
                AthleteName = "Shaquille O'neal",
                Img = "https://images.footballfanatics.com/los-angeles-lakers/los-angeles-lakers-shaquille-oneal-hardwood-classics-road-jersey-youth_ss4_p-13305040+u-5lj5tamkxlox9vv11mu2+v-ddca11f7cb1e4d31941ab939d70bf937.jpg?_hv=2"
            },
            new JerseyViewModel
            {
                Id = 7,
                Number = 84,
                Club = "Toronto Maple Leafs",
                AthleteName = "Mikhail Grabovski",
                Img = "https://vafloc02.s3.amazonaws.com/isyn/images/f143/img-142143-f.jpg"
            },
            new JerseyViewModel
            {
                Id = 8,
                Number = 10,
                Club = "Vancouver Canucks",
                AthleteName = "Pavel Bure",
                Img = "https://jerseyking.ca/cdn/shop/files/NHLPavelBureVancouverCanucks10Jerseyw.jpg?v=1697058048&width=1946"
            }
        };
        
        public ActionResult Index()
        {
            return View(ViewModels);
        }
        public ActionResult Detail(int id)
        {
            JerseyViewModel model = ViewModels.Where(j => j.Id == id).FirstOrDefault();
            return View(model);
        }
    }
}
