using WebStoryFroEveryting.Models.AnimeGirl;
using WebStoryFroEveryting.Models.Notebook;

namespace WebStoryFroEveryting.Services
{
    public class NotebookGenerator
    {
        private NameNotebookGenerator _nameNotebookGenerator;
        private Random _random = new();

        private List<string> Images = new()
        {
            "https://static.onlinetrade.ru/img/items/b/apple_noutbuk_macbook_12_i5_dual_1.3_8gb_512gb_ssd_hdg_615_mnyg2ru_a_space_gray_6.jpg",
            "https://www.notik.ru/img/catalog/91231/1_lenovoideapad3-1581we01eqrk.jpg",
            "https://digitik.ru/upload/iblock/679/679209ecba279b9b960d4283a47087b4.jpg"
        };       

        public NotebookGenerator(NameNotebookGenerator nameNotebookGenerator)
        {
            _nameNotebookGenerator = nameNotebookGenerator;
        }
        public List<NotebookViewModel> GenerateNotebook(int count)
        {
            var list = new List<NotebookViewModel>();

            for (int i = 0; i < count; i++)
            {
                var randomImagesIndex = _random.Next(Images.Count);
                var notebook = new NotebookViewModel
                {
                    Name = _nameNotebookGenerator.GetRandomNameNotebook(),
                    Src = Images[randomImagesIndex]
                };
                list.Add(notebook);
            }
            return list;
        }        
    }
}
      