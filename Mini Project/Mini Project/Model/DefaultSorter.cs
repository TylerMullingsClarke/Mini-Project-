namespace Mini_Project.Model
{
    public class DefaultSorter : AbsSorter
    {
        public override string SortName { get; } = "Default Sort";

        public override int[] Sort(int[] nums) {
            // This method apparently chooses different sorting algorithms depending on the size of
            // the array.
            Array.Sort(nums);
            return nums;
        }
    }
}