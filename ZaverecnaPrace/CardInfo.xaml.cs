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
using System.Windows.Shapes;

namespace ZaverecnaPrace
{
    /// <summary>
    /// Interakční logika pro CardInfo.xaml
    /// </summary>
    public partial class CardInfo : Window
    {
        public Board board;
        public CardInfo()
        {
            InitializeComponent();
            ErrorMsg.Text = "";
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (CardName.Text == "" || CardName.Text == " ")
            {
                ErrorMsg.Text = "Zadejte platný název";
            }
            else
            {
                board.newName = CardName.Text;
                this.Close();
            }
        }
    }
}
