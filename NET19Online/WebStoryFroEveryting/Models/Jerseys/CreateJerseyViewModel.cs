﻿namespace WebStoryFroEveryting.Models.Jerseys
{
    public class CreateJerseyViewModel
    {
        public string Club { get; set; }
        public int Number { get; set; }
        public string AthleteName { get; set; }
        public string Img { get; set; }
        public int InStock { get; set; }
        public decimal Price { get; set; }
    }
}
