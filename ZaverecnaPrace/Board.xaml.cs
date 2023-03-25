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
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class Board : Window
    {
        public Board()
        {
            InitializeComponent();
        }

        int lastCardX = 0;

        private void AddCard(object sender, RoutedEventArgs e)
        {
            CardList.Height = CardList.ActualHeight + 50;

            Thickness marginTop = AddCardButton.Margin;
            marginTop.Top = marginTop.Top + 50;
            AddCardButton.Margin = marginTop;

            Grid card = new Grid();
            card.Height = 20;
            card.Width = 100;

            Thickness cardMarginTop = card.Margin;
            cardMarginTop.Top = lastCardX;
            lastCardX += 50;
            card.Margin = cardMarginTop;

            card.Background = Brushes.White;
            CardList.Children.Add(card);
        }
    }
}
