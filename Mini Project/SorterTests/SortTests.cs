using Mini_Project;
using Mini_Project.Model;
using Mini_Project.Utilities;
using Mini_Project.Controller;
using Mini_Project.View;

namespace SorterTests
{
    public class SortTests
    {
        int[] array = new int[5] { 6, 3, 7, 2, 1 };
        int[] sorted = new int[5] { 1, 2, 3, 6, 7 };

        [TestCase(0, "Bubble Sort")]
        [TestCase(1, "Merge Sort")]
        [TestCase(2, "Default Sort")]
        [Category("Sort Input Tests")]
        public void GivenSortTypeInput_SorterController_RunsCorrectSort(int sortType, string sort)
        {
            ISorter sorter = SorterController.SelectSorter(sortType);
            Assert.That(sorter.SortName, Is.EqualTo(sort));
        }

        
        [TestCase(10)]
        [Category("Sort Input Tests")]
        public void GivenInvalidSortTypeInput_ExceptionThrown(int input)
        {
            Assert.That(() =>
            {
                return SorterController.SelectSorter(input);
            }, Throws.TypeOf<ArgumentException>());
        }
        
        [Test]
        [Category("BubbleSorter Tests")]
        public void GivenArray_BubbleSort_ReturnsSortedArray()
        {
            var bubbleSort = new BubbleSorter();
            Assert.That(sorted, Is.EqualTo(bubbleSort.Sort(array)));
        }

        [Test]
        [Category("DefaultSorter Tests")]
        public void GivenArray_DefaultSorter_ReturnsSortedArray()
        {
            var defaultSort = new DefaultSorter();
            Assert.That(sorted, Is.EqualTo(defaultSort.Sort(array)));
        }

        [Test]
        [Category("MergeSorter Tests")]
        public void GivenArray_MergeSorter_ReturnsSortedArray()
        {
            var MergeSort = new MergeSorter();
            Assert.That(sorted, Is.EqualTo(MergeSort.Sort(array)));
        }
    }
}