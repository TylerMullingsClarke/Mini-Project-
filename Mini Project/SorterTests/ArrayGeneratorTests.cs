using Mini_Project.Controller;
using Mini_Project.Utilities;
using Mini_Project.View;

namespace SorterTests
{
    public class ArrayGeneratorTests
    {
        [TestCase(1)]
        [TestCase(15)]
        [Category("Length Input Test")]
        public void GivenLength_ReturnsArrayWithCorrectSize(int length)
        {
            var array = ArrayGenerator.NewRandom(length);
            Assert.That(array, Has.Length.EqualTo(length));
        }

        [TestCase(2)]
        [TestCase(10)]
        [Category("Random Array Test")]
        public void Given2ArraysOfSameLength_ArraysAreNotTheSame(int length)
        {
            var array1 = ArrayGenerator.NewRandom(length);
            var array2 = ArrayGenerator.NewRandom(length);
            Assert.That(!array1.Equals(array2));
        }
    }
}
