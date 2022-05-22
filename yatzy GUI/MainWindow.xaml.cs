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
    public partial class MainWindow : Window
    {
        DiceController dc = new DiceController();
        HoldButton holdBtn = new HoldButton();
        Score score = new Score();
        GameState gameState = new GameState();

        public MainWindow()
        {
            InitializeComponent();
            gameState.InitializeGame(this);
        }


        private void roll_Click(object sender, RoutedEventArgs e)
        {
            dc.RollDice();

            DiceController.NumRolls++;

            if (DiceController.NumRolls == 1)
            {
                foreach (Button b in HoldButton.HoldButtons)
                {
                    b.IsEnabled = true;
                }
            }

            if (DiceController.NumRolls == 3)
            {
                Roll_Button.IsEnabled = false;
            }
        }

        private void onesLbl_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            score.SetScore(onesLbl, 1, this);
        }
        private void twosLbl_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            score.SetScore(twosLbl, 2, this);
        }
        private void threesLbl_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            score.SetScore(threesLbl, 3, this);
        }
        private void foursLbl_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            score.SetScore(foursLbl, 4, this);
        }
        private void fivesLbl_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            score.SetScore(fivesLbl, 5, this);
        }
        private void sixesLbl_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            score.SetScore(sixesLbl, 6, this);
        }

        private void holdBtn1_Click(object sender, RoutedEventArgs e)
        {
            holdBtn.HoldBtn(holdBtn1, 0);
        }

        private void holdBtn2_Click(object sender, RoutedEventArgs e)
        {
            holdBtn.HoldBtn(holdBtn2, 1);
        }

        private void holdBtn3_Click(object sender, RoutedEventArgs e)
        {
            holdBtn.HoldBtn(holdBtn3, 2);
        }

        private void holdBtn4_Click(object sender, RoutedEventArgs e)
        {

            holdBtn.HoldBtn(holdBtn4, 3);
        }

        private void holdBtn5_Click(object sender, RoutedEventArgs e)
        {
            holdBtn.HoldBtn(holdBtn5, 4);
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            DiceController.ResetDice(this);
            gameState.ResetGame(this);
        }

        public Button RollButton
        {
            get => Roll_Button;
            set => Roll_Button = value;
        }
    }
}
