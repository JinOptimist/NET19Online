using Moq;
using NUnit.Framework;
using WebStoryFroEveryting.Services;

namespace WebStoryFroEverything.Test.Services
{
    public class IdolGeneratorTest
    {
        private Mock<INameGenerator> _nameGeneratorMock;
        private IdolGenerator _idolGenerator;

        [SetUp]
        public void SetUp()
        {
            _nameGeneratorMock = new Mock<INameGenerator>();
            var nameGenerator = _nameGeneratorMock.Object;
            _idolGenerator = new IdolGenerator(nameGenerator);
        }

        [Test]
        public void GenerateIdols_CheckThatWeUseNameGenerator()
        {
            // Prepare

            // Act
            var answer = _idolGenerator.GenerateIdols(1);

            // Asser
            _nameGeneratorMock.Verify(x => x.GetRandomName(It.IsAny<int?>()), Times.Once, "Idol generator should use NameGenerator");
            Assert.Pass();
        }

        [TestCase(1)]
        [TestCase(5)]
        public void GenerateIdols_CheckCountOfGeneratedItems(int count)
        {
            // Prepare

            // Act
            var answer = _idolGenerator.GenerateIdols(count);

            // Asser
            Assert.That(answer.Count == count, "Wrong generated items count");
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void GenerateIdols_CheckThrowExceptionWithWrongCount(int count)
        {
            // Prepare

            // Act
            // Asser
            Assert.Throws<ArgumentException>(() => _idolGenerator.GenerateIdols(count));
        }
    }
}
