namespace unit03_jumper.Game
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private Word word = new Word();
        private bool isPlaying = true;
        private Jumper jumper = new Jumper();
        private TerminalService terminalService = new TerminalService();
        private char guess = ' ';
        private bool gameSolved = false;

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            firstStep();
            while (isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }

        /// <summary>
        /// Output to display before any inputs have been made. Selects the word and prints the wordspace, parachute, and skydiver.
        /// </summary>
        private void firstStep()
        {
            word.SelectWord();
            foreach (char item in word.wordspace)
            {
                terminalService.WriteCollection(item.ToString());
            }
            terminalService.WriteText("");
            foreach (string layer in jumper.parachute)
            {
                terminalService.WriteText(layer);
            }
            foreach (string item in jumper.skydiver)
            {
                terminalService.WriteText(item);
            }
        }

        /// <summary>
        /// Prompts the user to guess a letter.
        /// </summary>
        private void GetInputs()
        {
            string inputGuess = terminalService.ReadText("Guess a lowercase letter: ");
            guess = char.Parse(inputGuess);
        }

        /// <summary>
        /// Replaces wordspace or removes a layer if guess is wrong.
        /// </summary>
        private void DoUpdates()
        {
            bool correctguess = word.ReplaceWordspace(guess);
            if (correctguess != true)
            {
                jumper.RemoveLayer();
            }
            else
            {
            }
            gameSolved = word.CheckForCompletion();
            if (gameSolved)
            {
                isPlaying = false;
            }
        }

        /// <summary>
        /// Displays the wordspace, parachute, and skydiver.
        /// </summary>
        private void DoOutputs()
        {
            foreach (char item in word.wordspace)
            {
                terminalService.WriteCollection(item.ToString());
            }
            terminalService.WriteText("");
            if (jumper.parachute.Count != 0)
            {
                foreach (string layer in jumper.parachute)
                {
                    terminalService.WriteText(layer);
                }
                foreach (string item in jumper.skydiver)
                {
                    terminalService.WriteText(item);
                }
                if (gameSolved)
                {
                    terminalService.WriteText("YOU WIN");
                }
            }
            else if (jumper.parachute.Count == 0)
            {
                isPlaying = false;
                foreach (string item in jumper.skydiver)
                {
                    terminalService.WriteText(item);
                }
                terminalService.WriteText("GAME OVER");
            }
            
        }
    }
}