using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStoryFroEveryting.Models.Singers;
using StoreData.Repostiroties;
using StoreData.Models;

namespace WebStoryFroEveryting.Controllers
{
    public class SingerController : Controller
    {
        private SingerRepository _singerRepository;
        public SingerController(SingerRepository singerRepository)
        {
            _singerRepository = singerRepository;
        }
        public IActionResult Index()
        {
            var singers = _singerRepository.GetSingers();
            var viewsModelSinger = singers.Select(s => new SingerViewModel()
            {
                Id = s.Id,
                Pseudonym = s.Pseudonym,
                Src = s.Src,
                Style = s.Style
            }).ToList();

            if (!singers.Any())
            {
                var errorMessage = "Нет доступных исполнителей.";
                viewsModelSinger.Add(new SingerViewModel { ErrorMessage = errorMessage });
            }


            return View(viewsModelSinger);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SingerViewModel singer)
        {
            var newSinger = new SingerData()
            {
                Pseudonym = singer.Pseudonym,
                Src = singer.Src,
                Style = singer.Style
            };

            _singerRepository.Add(newSinger);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var singer = _singerRepository.Get(id);
            if (singer == null)
            {
                return NotFound();
            }

            var singerViewModel = new SingerViewModel()
            {
                Id = singer.Id,
                Pseudonym = singer.Pseudonym,
                Src = singer.Src,
                Style = singer.Style
            };

            return View(singerViewModel);
        }

        [HttpPost]
        public IActionResult Update(SingerViewModel singer)
        {
            _singerRepository.UpdateSinger(singer.Id, singer.Pseudonym, singer.Style);
            return RedirectToAction(nameof(Index));
        }
        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var singer = _singerRepository.Get(id);
            if (singer.Id == null)
            {
                return NotFound();
            }
            _singerRepository.Remove(id); 
            return Ok(); 
        }
    }

}


