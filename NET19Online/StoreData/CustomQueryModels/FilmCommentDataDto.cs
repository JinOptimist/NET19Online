using StoreData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.CustomQueryModels
{
    public class FilmCommentDataDto
    {
        public int FilmId { get; set; }
        public int Cou { get; set; }
        public string UserName { get; set; }

    }
}
