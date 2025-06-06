﻿using Moq;
using NUnit.Framework;
using WebStoryFroEveryting.Services.FilmsServer;
using WebStoryFroEveryting.Services.FilmsServices.Interface;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace WebStoryFroEverything.Test.Services
{
    public class FilmsTest
    {
        private Mock<IFilmsGeneratorServices> _mockservices;
        private FilmsGeneratorServices _generatorservices;

        [SetUp]
        public void SetUp()
        {
            _mockservices = new Mock<IFilmsGeneratorServices>();
            var nameObject = _mockservices.Object;
            _generatorservices = new FilmsGeneratorServices(nameObject);
        }

        [Test]
        public void NameGenerator_WhenProvidedValidFilmNames_ReturnsTrue()
        {
            //Arange 
            _mockservices.Setup(x => x.FilmsName)
                            .Returns(
                            [   "Атака титанов",
                                "Поднятие уровня в одиночку",
                                "Дикий робот"
                            ]);
            var nameFilms = new List<string>
                            {
                                "Атака титанов",
                                "Поднятие уровня в одиночку",
                                "Дикий робот"
                            };
            //Act
            var result = _generatorservices.NameGenerator(nameFilms);
            //Assert 
            Assert.That(result, Is.True);
        }

        [TestCase("rise of the machines")]
        public void NameGenerator_WhenListHasLessThanTwoElements_ReturnsFalse(string nameFilm)
        {
            //Act 
            var nameFilms = new List<string>();
            nameFilms.Add(nameFilm);
            //Asssert 
            Assert.Throws<ArgumentException>(() => _generatorservices.NameGenerator(nameFilms));
        }
        [Test]
        public void GenerateFilm_CheckThatWeUseNameGenerator()
        {

            //Arange 
            _mockservices.Setup(x => x.FilmsName).Returns(new List<string>
            {
                "Атака титанов",
                "Поднятие уровня в одиночку",
                "Дикий робот"
            });
            var inputFilm = new List<string>
                            {
                                "Атака титанов",
                                "Поднятие уровня в одиночку",
                                "Дикий робот"
                            };
            //Act 
            var answer = _mockservices.Object.NameGenerator(inputFilm);
            //Assert
            _mockservices.Verify(x => x.NameGenerator(It.IsAny<List<string>>()), Times.Once, "Film generator should use NameGenerator");
        }
    }
}
