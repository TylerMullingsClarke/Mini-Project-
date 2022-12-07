namespace Mini_Project.Model
{
    public class SelectionSorter : AbsSorter
    {
        public override string SortName { get; } = "Selection Sort";

        public override int[] Sort(int[] nums) {
            int jmin;
            int tmp;
            for (int i = 0; i < nums.Length - 1; i++) {
                jmin = i;
                for (int j = i + 1; j < nums.Length; j++) {
                    if (nums[j] < nums[jmin]) {
                        jmin = j;
                    }
                }
                if (jmin != i) {
                    tmp = nums[i];
                    nums[i] = nums[jmin];
                    nums[jmin] = tmp;
                }
            }
            return nums;
        }
    }
}