using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace yatzy_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IHold
    {

        ImageManager imgH = new ImageManager();

        public MainWindow()
        {
            InitializeComponent();
            InitializeGame();
        }

        private List<Dice> dice = new List<Dice>()
        {
            new Dice(),
            new Dice(),
            new Dice(),
            new Dice(),
            new Dice()
        };

        private List<Button> holdButtons = new List<Button>();
        private List<Image> images = new List<Image>();
        private List<Label> player1Scores = new List<Label>();
        private int numRolls;
        private Random rnd = new Random();
        private bool player1Finished;

        private void roll_Click(object sender, RoutedEventArgs e)
        {
            RollDice();

            numRolls++;

            if (numRolls == 1)
            {
                foreach (Button b in holdButtons)
                {
                    b.IsEnabled = true;
                }
            }

            if (numRolls == 3)
            {
                Roll_Button.IsEnabled = false;
            }
        }

        private void RollDice()
        {
            for (int i = 0; i < dice.Count; i++)
            {
                if (!dice[i].Hold)
                {
                    dice[i].Value = rnd.Next(1, 7);
                    imgH.setImage(dice[i].Value, images[i]);
                }
            }
        }

        public void ResetDice()
        {
            for (int i = 0; i < dice.Count; i++)
            {
                dice[i] = new Dice();
                images[i].Source = null;
                holdButtons[i].IsEnabled = false;
                holdButtons[i].Background = Brushes.LightGray;
            }

            Roll_Button.IsEnabled = true;
            numRolls = 0;
        }


        private void InitializeGame()
        {

            images.Add(dice1);
            images.Add(dice2);
            images.Add(dice3);
            images.Add(dice4);
            images.Add(dice5);

            holdButtons.Add(holdBtn1);
            holdButtons.Add(holdBtn2);
            holdButtons.Add(holdBtn3);
            holdButtons.Add(holdBtn4);
            holdButtons.Add(holdBtn5);

            foreach (Button b in holdButtons)
            {
                b.IsEnabled = false;
            }

            player1Scores.Add(onesLbl);
            player1Scores.Add(twosLbl);
            player1Scores.Add(threesLbl);
            player1Scores.Add(foursLbl);
            player1Scores.Add(fivesLbl);
            player1Scores.Add(sixesLbl);

            Play_Again.IsEnabled = false;

            textBlock.Text = "To add points to your score, you will have to click at the points for the corresponding dice";
        }

        
        public void HoldButton(Button holdBtn, int i)
        {
            if (!dice[i].Hold)
            {
                dice[i].Hold = true;
                holdBtn.Background = Brushes.Red;
            }
            else
            {
                dice[i].Hold = false;
                holdBtn.Background = Brushes.LightGray;
            }
        }

        private void SetScore(Label label, int v)
        {
            int score = 0;

            foreach (Dice dice in dice)
            {
                if (dice.Value == v)
                {
                    score += dice.Value;
                }
            }

            label.Content = score.ToString();
            label.Background = Brushes.LightGreen;
            label.IsEnabled = false;
            CheckPlayer1Sum();
            ResetDice();
        }

        public void CheckPlayer1Sum()
        {
            int score = 0;
            int count = 0;

            foreach (Label lbl in player1Scores)
            {
                if (lbl.IsEnabled == false)
                {
                    score += Convert.ToInt32(lbl.Content);
                    count++;
                }
            }
            sumLbl.Content = score.ToString();

            if (count == 6)
            {
                player1Finished = true;
            }
            Gameover();
        }

        private void ResetGame()
        {
            foreach(Label lbl in player1Scores)
            {
                lbl.Background = Brushes.White;
                lbl.IsEnabled = true;
                lbl.Content = 0;
            }

            sumLbl.Content = 0;

            Play_Again.IsEnabled = false;
        }

        private void Gameover()
        {
            if (player1Finished == true)
            {
                Play_Again.IsEnabled = true;
            }
        }

        private void onesLbl_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            SetScore(onesLbl, 1);
        }
        private void twosLbl_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            SetScore(twosLbl, 2);
        }
        private void threesLbl_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            SetScore(threesLbl, 3);
        }
        private void foursLbl_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            SetScore(foursLbl, 4);
        }
        private void fivesLbl_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            SetScore(fivesLbl, 5);
        }
        private void sixesLbl_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            SetScore(sixesLbl, 6);
        }

        private void holdBtn1_Click(object sender, RoutedEventArgs e)
        {
            HoldButton(holdBtn1, 0);
        }

        private void holdBtn2_Click(object sender, RoutedEventArgs e)
        {
            HoldButton(holdBtn2, 1);
        }

        private void holdBtn3_Click(object sender, RoutedEventArgs e)
        {
            HoldButton(holdBtn3, 2);
        }

        private void holdBtn4_Click(object sender, RoutedEventArgs e)
        {

            HoldButton(holdBtn4, 3);
        }

        private void holdBtn5_Click(object sender, RoutedEventArgs e)
        {
            HoldButton(holdBtn5, 4);
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            ResetDice();
            ResetGame();
        }
    }
}
