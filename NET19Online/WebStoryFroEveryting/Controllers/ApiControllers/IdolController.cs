using Microsoft.AspNetCore.Mvc;
using StoreData.Models;
using StoreData.Repostiroties;
using WebStoryFroEveryting.Models.AnimeGirl;
using WebStoryFroEveryting.Models.CustomValidationAttribute;

namespace WebStoryFroEveryting.Controllers.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IdolController : ControllerBase
    {
        private IdolRepository _idolRepository;

        public IdolController(IdolRepository idolRepository)
        {
            _idolRepository = idolRepository;
        }

        public bool UpdateName(int id, string newName)
        {
            _idolRepository.UpdateName(id, newName);
            return true;
        }

        public void Remove(int id)
        {
            _idolRepository.Remove(id);
        }

        public int Create([FromForm] CreateIdolViewModel viewModel)
        {
            var idol = new IdolData
            {
                Name = viewModel.Name,
                Src = viewModel.Src,
            };
            _idolRepository.Add(idol);

            return idol.Id;
        }

        public IdolViewModel Get(int id)
        {
            var idol = _idolRepository.Get(id);
            var viewModel = new IdolViewModel
            {
                Id = idol.Id,
                Name = idol.Name,
                Src = idol.Src,
            };
            return viewModel;
        }
    }
}
