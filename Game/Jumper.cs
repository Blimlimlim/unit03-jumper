using System;
using System.Collections.Generic;


namespace unit03_jumper.Game
{
    /// <summary>
    /// The jumper creates the parachute and skydiver and can remove layers of the parachute.
    /// </summary>
    public class Jumper
    {
        public List<string> parachute = new List<string>();
        public List<string> skydiver = new List<string>();

        /// <summary>
        /// Constructs a new instance of Jumper. 
        /// </summary>
        public Jumper()
        {
            parachute.Add(" ___");
            parachute.Add(@"/___\");
            parachute.Add(@"\   /");
            parachute.Add(@" \ /");
            skydiver.Add("  O");
            skydiver.Add(@" /|\");
            skydiver.Add(@" / \");
        }

        /// <summary>
        /// Removes the top layer of the parachute. Intended to be used when the player guesses wrong.
        /// </summary>
        public void RemoveLayer()
        {
            parachute.RemoveAt(0);
        }
        
    }
}