using System.Diagnostics;

namespace MoviePicker.Services
{
    public class AnimationService
    {
        public static void RollingAnimation(List<object> data)
        {
            var counter = 0;
            var delay = 60;
            var elapsed = 0;
            Stopwatch timer = new();
            timer.Start();
            while (timer.Elapsed.TotalSeconds < 10)
            {
                if (timer.Elapsed.TotalSeconds > elapsed + 0.5)
                {
                    delay += 20;
                    elapsed++;
                }
                Turn(counter, delay, data);
                counter++;
            }
        }

        public static void Turn(int counter, int delay = 100, List<object> data = null)
        {
            Thread.Sleep(delay);
            int counterValue = counter % data.Count;
            string fullMessage = data[counterValue].ToString();
            Console.Clear();
            Console.Write(fullMessage);
        }
    }
}