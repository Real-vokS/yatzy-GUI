using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace yatzy_GUI
{
    class Score
    {
        private static List<Label> player1Scores = new List<Label>();

        private static bool player1Finished;

        public void SetScore(Label label, int v, MainWindow mw)
        {
            int score = 0;

            foreach (Dice dice in DiceController.Dices)
            {
                if (dice.Value == v)
                {
                    score += dice.Value;
                }
            }

            label.Content = score.ToString();
            label.Background = Brushes.LightGreen;
            label.IsEnabled = false;
            CheckPlayer1Sum(mw);
            DiceController.ResetDice(mw);
        }

        public void CheckPlayer1Sum(MainWindow mw)
        {
            int score = 0;
            int count = 0;

            foreach (Label lbl in Score.Player1Scores)
            {
                if (lbl.IsEnabled == false)
                {
                    score += Convert.ToInt32(lbl.Content);
                    count++;
                }
            }
            mw.sumLbl.Content = score.ToString();

            if (count == 6)
            {
                player1Finished = true;
            }
            GameState.Gameover(mw);
        }

        public static List<Label> Player1Scores
        {
            get => player1Scores;
            set => player1Scores = value;
        }

        public static bool Player1Finished
        {
            get => player1Finished;
            set => player1Finished = value;
        }

    }
}
