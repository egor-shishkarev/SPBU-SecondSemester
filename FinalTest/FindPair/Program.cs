namespace FindPair
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                throw new ArgumentException("Not enough arguments!");
            }
            if (!int.TryParse(args[0], out int numberOfPairs))
            {
                throw new ArgumentException("Not a number!");
            }
            if (numberOfPairs % 2 != 0)
            {
                throw new ArgumentException("It is necessary to enter only even numbers!");
            }
            if (numberOfPairs >= 20)
            {
                throw new ArgumentException("Too much elements!");
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(numberOfPairs));
        }
    }
}