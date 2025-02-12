using StoreData.Models;
using WebStoryFroEveryting.Models.Jerseys;

namespace WebStoryFroEveryting.Services
{
    public class JerseyGenerator
    {
        public List<JerseyViewModel> GenerateData()
        {
            var data = new List<JerseyViewModel>
            {
                new JerseyViewModel
                {
                    Number = 13,
                    Club = "Arsenal London",
                    AthleteName = "Alexander Hleb",
                    Img = "https://www.classicfootballshirts.co.uk/cdn-cgi/image/fit=pad,q=70,f=webp//pub/media/catalog/product//8/e/8e30e917d15d511e7c56fe6324ec6747f82203d821561425a7e9d3bba8444533.jpeg"
                },
                new JerseyViewModel
                {
                    Number = 32,
                    Club = "Inter Milano",
                    AthleteName = "Christian Vieri",
                    Img = "https://mvps.com/wp-content/uploads/2024/08/VINICIUS-JR-10.png"
                },
                new JerseyViewModel
                {
                    Number = 8,
                    Club = "Chelsea",
                    AthleteName = "Frank Lampard",
                    Img = "https://m.teamzo.com/images/re-2000-2001-chelsea-home-shirt-lampard-8-1634121735.png"
                },
                new JerseyViewModel
                {
                    Number = 8,
                    Club = "Liverpool",
                    AthleteName = "Steven Gerrard",
                    Img = "https://static1.cdn-subsidesports.com/2/media/catalog/product/cache/abbf5437a995fd7cabd85bbbc7fdfb0f/6/e/6e69f2bc318389dc394c1c703c6b86e8a71ff9bfd7f668694811b958e2abe5af.jpeg"
                },
                new JerseyViewModel
                {
                    Number = 8,
                    Club = "San Antonio Spurs",
                    AthleteName = "Tim Dunkan",
                    Img = "https://fanatics.frgimages.com/san-antonio-spurs/mens-mitchell-and-ness-tim-duncan-white-san-antonio-spurs-1998/99-hardwood-classics-swingman-jersey_pi4380000_ff_4380764-a03c7aa111c6b00fcce5_full.jpg?_hv=2"
                }
            };
            return data;
        }
    }
}
