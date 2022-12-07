namespace Mini_Project.Model
{
    public class BubbleSorter : AbsSorter
    {
        public override string SortName { get; } = "Bubble Sort";

        public override int[] Sort(int[] nums) {
            for (int i = 0; i < nums.Length - 1; i++) //set a starting point at the start of the arrays length,
                                                      //then to go to i minus one so we dont go outside the boundaries of the array
            {
                for (int j = 0; j < nums.Length - 1; j++) {
                    if (nums[j] > nums[j + 1]) {
                        int tmp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = tmp;
                    }
                }
            }
            return nums;
        }
    }
}