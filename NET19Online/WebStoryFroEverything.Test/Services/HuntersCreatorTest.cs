using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoryFroEveryting.Services.UnderwaterHunterServices;
using WebStoryFroEveryting.Services.UnderwaterHunterServices.Interfaces;

namespace WebStoryFroEverything.Test.Services
{
    internal class HuntersCreatorTest
    {
        private HunterCreator _hunterCreator;
        private Mock<IHuntersNumber> _minHuntersNumberMock;

        [SetUp]
        public void SetUp()
        {
            _minHuntersNumberMock = new Mock<IHuntersNumber>();
            var minHuntersNumber = _minHuntersNumberMock.Object;
            _hunterCreator = new HunterCreator(minHuntersNumber);
        }

        [Test]
        public void CreateHunter_CheckGetMinHuntersNumberMethod()
        {
            var numberOfHunters = 2;
            SetMinNumberOfHunters(numberOfHunters);

            _hunterCreator.CreateHunter();

            _minHuntersNumberMock.Verify(x => x.GetMinHuntersNumber(), Times.Once);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void CreateHunter_CheckThrowException(int numberOfHunters)
        {
            SetMinNumberOfHunters(numberOfHunters);

            Assert.Throws<ArgumentException>(() => _hunterCreator.CreateHunter());
        }

        [Test]
        [TestCase("Pedro Carbonell")]
        public void CreateHunter_CheckCorrectValueOfFieldNameHunter(string name)
        {
            var numberOfHunters = 2;
            SetMinNumberOfHunters(numberOfHunters);

            var hunters = _hunterCreator.CreateHunter();
            var names = hunters
                .Select(x => x.NameHunter)
                .ToList();

            Assert.That(names[0] == name);
        }

        private void SetMinNumberOfHunters(int numberOfHunters)
        {
            _minHuntersNumberMock
                .Setup(x => x.GetMinHuntersNumber())
                .Returns(numberOfHunters);
        }
    }
}
