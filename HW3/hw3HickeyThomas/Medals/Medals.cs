using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HW3HickeyThomas
{
    public partial class Medals : Form
    {
        List<Game> GameList = new List<Game>();
        int listIndex = 1;

        public Medals()
        {
            GameList.Add(new Game());
            InitializeComponent();
            ListReader.Text = $"{listIndex - 1}/{GameList.Count - 1}";
        }

        void ListViewer()
        {
            if (listIndex >= 1 && listIndex < GameList.Count)
            {
                ListReader.Text = $"{listIndex}/{GameList.Count - 1}";

                USAGold.Text = GameList[listIndex].USAGold.ToString();
                USAGold.Visible = true;
                USASilver.Text = GameList[listIndex].USASilver.ToString();
                USASilver.Visible = true;
                USABronze.Text = GameList[listIndex].USABronze.ToString();
                USABronze.Visible = true;
                RUSGold.Text = GameList[listIndex].RUSGold.ToString();
                RUSGold.Visible = true;
                RUSSilver.Text = GameList[listIndex].RUSSilver.ToString();
                RUSSilver.Visible = true;
                RUSBronze.Text = GameList[listIndex].RUSBronze.ToString();
                RUSBronze.Visible = true;

                CountWinner.Text = $"{GameList[listIndex].countWinner} with {GameList[listIndex].winnerCount.ToString()} medals";
                if (GameList[listIndex].countWinner == "USA")
                {
                    USACountFlag.Visible = true;
                    RUSCountFlag.Visible = false;
                }
                else if (GameList[listIndex].countWinner == "RUS")
                {
                    RUSCountFlag.Visible = true;
                    USACountFlag.Visible = false;
                }
                else
                {
                    USACountFlag.Visible = true;
                    RUSCountFlag.Visible = true;
                }

                ColorWinner.Text = $"{GameList[listIndex].colorWinner} with {GameList[listIndex].winnerColorCount.ToString()} {GameList[listIndex].winnerColor} medals";
                if (GameList[listIndex].colorWinner == "USA")
                {
                    USAColorFlag.Visible = true;
                    RUSColorFlag.Visible = false;
                }
                else if (GameList[listIndex].colorWinner == "RUS")
                {
                    RUSColorFlag.Visible = true;
                    USAColorFlag.Visible = false;
                }
                else
                {
                    USAColorFlag.Visible = true;
                    RUSColorFlag.Visible = true;
                }

                ResultsBox.Visible = true;
            }

            //If patient list is currently empty reset labels
            else
            {
                USAGold.Text = "";
                USAGold.Visible = false;
                USASilver.Text = "";
                USASilver.Visible = false;
                USABronze.Text = "";
                USABronze.Visible = false;
                RUSGold.Text = "";
                RUSGold.Visible = false;
                RUSSilver.Text = "";
                RUSSilver.Visible = false;
                RUSBronze.Text = "";
                RUSBronze.Visible = false;

                CountWinner.Text = $"";
                USACountFlag.Visible = false;
                RUSCountFlag.Visible = false;
                ColorWinner.Text = $"";
                USAColorFlag.Visible = false;
                USACountFlag.Visible = false;
                ResultsBox.Visible = false;

                listIndex = 1;
                ListReader.Text = $"{listIndex - 1}/{GameList.Count - 1}";
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            GameList.Clear();
            GameList.Add(new Game());
            listIndex = 0;
            ListViewer();
        }

        private void ImportGames_Click(object sender, EventArgs e)
        {
            listIndex = 0;
            ListViewer();

            FileOperations FO = new FileOperations();
            FO.ReadFile(GameList);

            listIndex = 1;
            ListViewer();
        }

        private void ExportGames_Click(object sender, EventArgs e)
        {
            FileOperations FO = new FileOperations();
            FO.WriteListToFile(GameList);

            listIndex = 1;
            ListViewer();
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if (listIndex > 1)
            {
                listIndex--;
                ListViewer();
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (listIndex < GameList.Count - 1)
            {
                listIndex++;
                ListViewer();
            }
        }
    }
}
