﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Models
{
    public class UnderwaterHunterData
    {
        public int Id { get; set; }
        public string NameHunter { get; set; }
        public string Nationality { get; set; }
        /// <summary>
        /// meters
        /// </summary>
        public int MaxHuntingDepth { get; set; }
        public string Src { get; set; }
    }
}
