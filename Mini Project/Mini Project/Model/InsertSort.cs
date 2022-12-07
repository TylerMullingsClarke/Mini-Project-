namespace Mini_Project.Model
{
    public class InsertSort : AbsSorter
    {
        public override string SortName { get; } = "Insert Sort";

        public override int[] Sort(int[] nums) {
            int tmp;
            int j;
            for (int i = 0; i < nums.Length - 1; i++) {
                if (nums[i] > nums[i + 1]) {
                    tmp = nums[i];
                    nums[i] = nums[i + 1];
                    nums[i + 1] = tmp;
                }
                j = i;
                while (j > 0 && nums[j - 1] > nums[j]) {
                    tmp = nums[j];
                    nums[j] = nums[j - 1];
                    nums[j - 1] = tmp;
                    j--;
                }
            }
            return nums;
        }
    }
}