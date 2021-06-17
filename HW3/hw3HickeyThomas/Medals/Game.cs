using System;
using System.Collections.Generic;
using System.Text;

namespace HW3HickeyThomas
{
    class Game
    {
        //Initial Attributes
        public int USAGold { get; set; }
        public int USASilver { get; set; }
        public int USABronze { get; set; }
        public int RUSGold { get; set; }
        public int RUSSilver { get; set; }
        public int RUSBronze { get; set; }

        //Calculated Attributes
        public int USATotal { get; set; }
        public int RUSTotal { get; set; }
        public int winnerCount { get; set; }
        public string countWinner { get; set; }
        public string winnerColor { get; set; }
        public string colorWinner { get; set; }
        public int winnerColorCount { get; set; }

        public Game()
        {
            USAGold = 0;
            USASilver = 0;
            USABronze = 0;
            RUSGold = 0;
            RUSSilver = 0;
            RUSBronze = 0;
            USATotal = 0;
            RUSTotal = 0;
            winnerCount = 0;
            countWinner = "";
            winnerColor = "";
            colorWinner = "";
            winnerColorCount = 0;
        }

        public Game(int USAgold, int USAsilver, int USAbronze, int RUSgold, int RUSsilver, int RUSbronze)
        {
            USAGold = USAgold;
            USASilver = USAsilver;
            USABronze = USAbronze;
            RUSGold = RUSgold;
            RUSSilver = RUSsilver;
            RUSBronze = RUSbronze;

            USATotal = USAGold + USASilver + USABronze;
            RUSTotal = RUSGold + RUSSilver + RUSBronze;

            if (USATotal > RUSTotal) countWinner = "USA";
            else if (RUSTotal > USATotal) countWinner = "RUS";
            else countWinner = "Tie";

            if (USAGold > RUSGold) colorWinner = "USA";
            else if (RUSGold > USAGold) colorWinner = "RUS";
            else
            {
                if (USASilver > RUSSilver) colorWinner = "USA";
                else if (RUSSilver > USASilver) colorWinner = "RUS";
                else
                {
                    if (USABronze > RUSBronze) colorWinner = "USA";
                    else if (RUSBronze > USABronze) colorWinner = "RUS";
                    else colorWinner = "Tie";
                }
            }
        }

        public void CalculateWinners()
        {
            //Calculate total medals for each country
            USATotal = USAGold + USASilver + USABronze;
            RUSTotal = RUSGold + RUSSilver + RUSBronze;

            //Calculate the winner by medal count and number
            if (USATotal > RUSTotal)
            {
                winnerCount = USATotal;
                countWinner = "USA";
            }
            else if (RUSTotal > USATotal)
            {
                winnerCount = RUSTotal;
                countWinner = "RUS";
            }

            else
            {
                winnerCount = USATotal;
                countWinner = "Tie";
            }

            //Calculate the winner by medal color and color used and number of that color
            if (USAGold > RUSGold)
            {
                winnerColor = "Gold";
                colorWinner = "USA";
                winnerColorCount = USAGold;
            }
            else if (RUSGold > USAGold)
            {
                winnerColor = "Gold";
                colorWinner = "RUS";
                winnerColorCount = RUSGold;
            }
            else
            {
                if (USASilver > RUSSilver)
                {
                    winnerColor = "Silver";
                    colorWinner = "USA";
                    winnerColorCount = USASilver;
                }
                else if (RUSSilver > USASilver)
                {
                    winnerColor = "Silver";
                    colorWinner = "RUS";
                    winnerColorCount = RUSSilver;
                }
                else
                {
                    if (USABronze > RUSBronze)
                    {
                        winnerColor = "Bronze";
                        colorWinner = "USA";
                        winnerColorCount = USABronze;
                    }
                    else if (RUSBronze > USABronze)
                    {
                        winnerColor = "Bronze";
                        colorWinner = "RUS";
                        winnerColorCount = RUSBronze;
                    }
                    else
                    {
                        winnerColor = "Bronze";
                        colorWinner = "Tie";
                        winnerColorCount = USABronze;
                    }
                }
            }
        }
    }
}
