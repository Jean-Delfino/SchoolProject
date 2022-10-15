namespace Utils
{
    public static class UtilInt
    {
        public static int CheckBound(ref int counter, int limit)
        {
            int toAdd = 0;

            while (counter > limit - 1)
            {
                counter -= limit;
                toAdd++;
            }

            return toAdd;
        }
    }
}
