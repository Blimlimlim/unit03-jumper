using unit03_jumper.Game;

namespace unit03_jumper
{
    class Program
    {
        /// <summary>
        /// Serves as the entry point to the program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Director director = new Director();
            director.StartGame();
        }
    }
}
