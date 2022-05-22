using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace yatzy_GUI
{
    class GameState
    {
        public void ResetGame(MainWindow mw)
        {
            foreach (Label lbl in Score.Player1Scores)
            {
                lbl.Background = Brushes.White;
                lbl.IsEnabled = true;
                lbl.Content = 0;
            }

            mw.sumLbl.Content = 0;

            mw.Play_Again.IsEnabled = false;
        }



        public static void Gameover(MainWindow mw)
        {
            if (Score.Player1Finished == true)
            {
                mw.Play_Again.IsEnabled = true;
            }
        }

        public void InitializeGame(MainWindow mw)
        {

            ImageManager.Images.Add(mw.dice1);
            ImageManager.Images.Add(mw.dice2);
            ImageManager.Images.Add(mw.dice3);
            ImageManager.Images.Add(mw.dice4);
            ImageManager.Images.Add(mw.dice5);

            HoldButton.HoldButtons.Add(mw.holdBtn1);
            HoldButton.HoldButtons.Add(mw.holdBtn2);
            HoldButton.HoldButtons.Add(mw.holdBtn3);
            HoldButton.HoldButtons.Add(mw.holdBtn4);
            HoldButton.HoldButtons.Add(mw.holdBtn5);

            foreach (Button b in HoldButton.HoldButtons)
            {
                b.IsEnabled = false;
            }

            Score.Player1Scores.Add(mw.onesLbl);
            Score.Player1Scores.Add(mw.twosLbl);
            Score.Player1Scores.Add(mw.threesLbl);
            Score.Player1Scores.Add(mw.foursLbl);
            Score.Player1Scores.Add(mw.fivesLbl);
            Score.Player1Scores.Add(mw.sixesLbl);

            mw.Play_Again.IsEnabled = false;

            mw.textBlock.Text = "To add points to your score, you will have to click at the points for the corresponding dice";
        }

    }
}
