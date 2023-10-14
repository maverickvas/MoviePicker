namespace MoviePicker.DTO
{
    public class MovieChoice
    {
        public bool Confirmed { get; set; }
        public int Index { get; set; }
    }

    public class ConsoleSpinner
    {
        public int Delay { get; set; } = 20;
        int counter;

        public ConsoleSpinner()
        {
            counter = 0;
        }
    }
}
