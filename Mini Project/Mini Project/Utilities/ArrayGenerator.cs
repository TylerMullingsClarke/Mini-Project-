namespace Mini_Project.Utilities
{
    public static class ArrayGenerator
    {
        public static int[] NewRandom(int length) {
            var arr = new int[length];
            var rand = new Random();
            for (int i = 0; i < length; i++) {
                arr[i] = rand.Next(0, 1000);
            }
            return arr;
        }
    }
}