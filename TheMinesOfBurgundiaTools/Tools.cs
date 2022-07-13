namespace TheMinesOfBurgundiaTools
{
    public static class Tools
    {
        public static int ParseToInteger(string num, int defaultIntegerValue)
        {
            int resultNum = 0;

            if (num == "" || num == null) { return defaultIntegerValue; }

            bool isPasreable = Int32.TryParse(num, out resultNum);

            if (isPasreable) { return resultNum; }
            else { return defaultIntegerValue; }
        }

        public static int LimitInteger(int value, int lowerLimit, int higherLimit)
        {
            if (value < lowerLimit) { return lowerLimit; }
            else if (value > higherLimit) { return higherLimit; }
            else { return value; }
        }

        public static void Print(string s, int speed = 30)
        {
            foreach (char c in s)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);

            }
            Console.WriteLine();
        }
    }
}