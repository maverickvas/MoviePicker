namespace MoviePicker.Helpers
{
    public static class Helper
    {
        public static int GenerateRandomNumber(int max = 10)
        {
            Random rnd = new();
            return rnd.Next(max);
        }

        public static void AnimatedPrint(string text, int speed = 50, ConsoleColor colour = ConsoleColor.White)
        {
            Console.ForegroundColor = colour;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(speed);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

}
