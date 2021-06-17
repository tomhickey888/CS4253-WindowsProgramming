using System;
using System.Collections.Generic;
using System.IO;

namespace HW3HickeyThomas
{
    class FileOperations
    {
        //Path to file to be read or written to
        public string inputFileName = "C:\\temp\\medalsInput.txt";
        public string outputFileName = "C:\\temp\\medalsOutput.txt";

        //Method to read a file into the patient list
        public void ReadFile(List<Game> GameList)
        {
            GameList.Clear();
            GameList.Add(new Game());

            StreamReader file = new StreamReader(inputFileName);

            //Read line from file for number of games
            string n = file.ReadLine();
            int numGames = Convert.ToInt32(n);

            //Variable for each line from file
            string person;
            int i = 1;

            //Read each line until you reach null 
            while ((person = file.ReadLine()) != null)
            {
                string[] words = person.Split(' ');

                //Check if the line splits into the correct number of fields
                if (words.Length == 6)
                {
                    GameList.Add(new Game(Convert.ToInt32(words[0]), Convert.ToInt32(words[1]), Convert.ToInt32(words[2]), Convert.ToInt32(words[3]), Convert.ToInt32(words[4]), Convert.ToInt32(words[5])));
                    GameList[i].CalculateWinners();
                    i++;

                }
            }
            file.Close();
        }

        //Method to write a new patient in the patient list to a text file
        public void WriteListToFile(List<Game> gameList)
        {
            StreamWriter fileWrite = new StreamWriter(outputFileName);

            for(int i = 1; i < gameList.Count; i++)
            {
                fileWrite.WriteLine(string.Format($"USA Scores: {gameList[i].USAGold.ToString()} {gameList[i].USASilver.ToString()} {gameList[i].USABronze.ToString()}  Russia Scores: {gameList[i].RUSGold.ToString()} {gameList[i].RUSSilver.ToString()} {gameList[i].RUSBronze.ToString()}"));
                fileWrite.WriteLine(string.Format($"It was a {gameList[i].countWinner} victory based on the medal count, and a {gameList[i].colorWinner} victory based on the medal colors."));
                fileWrite.WriteLine(string.Format($""));
            }
            fileWrite.Close();
        }
    }
}
