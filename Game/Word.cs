using System;
using System.IO;
using System.Collections.Generic;


namespace unit03_jumper.Game
{
    /// <summary>
    /// The word is responsible for choosing a word and making the blanks. It fills in correct guesses and keeps track of whether the word has been solved yet.
    /// </summary>
        public class Word
        {
            private string _word;
            public List<char> wordspace = new List<char>();
            private List<char> letters = new List<char>();
            public bool containsMatch;
            private bool wordComplete;
            
            /// <summary>
            /// Constructs a new instance of Word.
            /// </summary>
            public Word()
            {
                _word = "";
                containsMatch = false;
                wordComplete = true;
            }

            /// <summary>
            /// Gets a word from the text file and assigns it to _word
            /// </summary>
            public void SelectWord()
            {
                string[] wordArray = File.ReadAllLines("words.txt");
                Random random = new Random();
                int wordIndex = random.Next(9894);
                _word = wordArray[wordIndex];
                GenerateWordspace();
            }

            /// <summary>
            /// Method used by sister method "Selectword()" to create the series of underscores representing the hidden word.
            /// </summary>
            private void GenerateWordspace()
            {
                foreach (char item in _word)
                {
                    wordspace.Add('_');
                    letters.Add(item);
                }
            }

            /// <summary>
            /// Takes the player's guess and checks the letters in the word for any matches. Underscores in the wordspace are replaced by matching letters. Also returns true or false.
            /// </summary>
            /// <param name="guess">The character that the word is checked for</param>
            public bool ReplaceWordspace(char guess)
            {
                int index = 0;
                index = 0;
                containsMatch = CheckForMatches(guess);
                if (containsMatch == true)
                {
                    foreach (char letter in letters)
                    {
                        if (guess == letter)
                        {
                            wordspace[index] = letter;
                        }
                        index++;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
            /// <summary>
            /// Checks for any matching characters in the word. Meant to be called by "ReplaceWord()" Method.
            /// </summary>
            private bool CheckForMatches(char guess)
            {
                bool isMatch = false;
                isMatch = false;
                foreach (char letter in letters)
                {
                    if (guess == letter)
                    {
                        isMatch = true;
                    }
                    else
                    {
                    }
                }
                return isMatch;
            }

            /// <summary>
            /// Checks to see if the word has been solved.
            /// </summary>
            /// <returns>true if yes or false if no</returns>
            public bool CheckForCompletion()
            {
                wordComplete = true;
                foreach (char item in wordspace)
                {
                    if (item == '_')
                    {
                        wordComplete = false;
                    }
                }
                return wordComplete;
            }

        }
    
}