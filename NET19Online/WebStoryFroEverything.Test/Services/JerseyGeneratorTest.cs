using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoryFroEveryting.Services.JerseyServices;

namespace WebStoryFroEverything.Test.Services
{
    public class JerseyGeneratorTest
    {
        private JerseyGenerator _jerseyGenerator;

        [SetUp]
        public void SetUp()
        {
            _jerseyGenerator = new JerseyGenerator();
        }
        [Test]
        public void TestGenerateDataForNotNullCount()
        {
            var outputList = _jerseyGenerator.GenerateData();
            Assert.That(outputList.Any());
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public void TestGenerateSomeNumberOfJerseysWithPositiveArguments(int count)
        {
            var outputList = _jerseyGenerator.GenerateSomeNumberOfJerseys(count);
            Assert.That(outputList.Count == count);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-121212412)]
        public void TestArgumentExceptionGenerateSomeNumberOfJerseys(int count)
        {
            Assert.Throws<ArgumentException>(() => _jerseyGenerator.GenerateSomeNumberOfJerseys(count));
        }
    }
}
