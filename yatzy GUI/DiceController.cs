using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace yatzy_GUI
{
    class DiceController
    {

        Random rnd = new Random();

        private static int numRolls;

        private static List<Dice> dice = new List<Dice>()
        {
            new Dice(),
            new Dice(),
            new Dice(),
            new Dice(),
            new Dice()
        };

        public static void ResetDice(MainWindow mw)
        {
            for (int i = 0; i < dice.Count; i++)
            {
                dice[i] = new Dice();
                ImageManager.Images[i].Source = null;
                HoldButton.HoldButtons[i].IsEnabled = false;
                HoldButton.HoldButtons[i].Background = Brushes.LightGray;
            }

            mw.Roll_Button.IsEnabled = true;
            numRolls = 0;
        }

        public void RollDice()
        {
            for (int i = 0; i < dice.Count; i++)
            {
                if (!dice[i].Hold)
                {
                    dice[i].Value = rnd.Next(1, 7);
                    ImageManager.setImage(dice[i].Value, ImageManager.Images[i]);
                }
            }
        }

        public static List<Dice> Dices
        {
            get => dice;
            set => dice = value;
        }

        public static int NumRolls
        {
            get => numRolls;
            set => numRolls = value;
        }


    }
}
