using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace yatzy_GUI
{
    class HoldButton
    {
        private static List<Button> holdButtons = new List<Button>();

        public void HoldBtn(Button holdBtn, int i)
        {
            if (!DiceController.Dices[i].Hold)
            {
                DiceController.Dices[i].Hold = true;
                holdBtn.Background = Brushes.Red;
            }
            else
            {
                DiceController.Dices[i].Hold = false;
                holdBtn.Background = Brushes.LightGray;
            }
        }

        public static List<Button> HoldButtons
        {
            get => holdButtons;
            set => holdButtons = value;
        }

    }
}
