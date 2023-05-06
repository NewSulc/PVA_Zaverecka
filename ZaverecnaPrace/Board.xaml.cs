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
using System.Diagnostics;

namespace ZaverecnaPrace
{
    public partial class Board : Window
    {
        BoardClasses boardClass = new BoardClasses();

        public Board()
        {
            InitializeComponent();
            boardClass.cardNumber = 0;
        }

        public string newName, newDescription;

        private void AddCard(object sender, RoutedEventArgs e)
        {
            //delaní listu vetsi
            int listIndex = int.Parse((sender as FrameworkElement).Name.Substring((sender as FrameworkElement).Name.Length - 1));
            boardClass.cardLists[listIndex].Height += 50;
            boardClass.panelLists[listIndex].Height += 50;
            boardClass.buttonLists[listIndex].Margin = new Thickness(0, boardClass.buttonLists[listIndex].Margin.Top + 50, 0, 0);

            //zobrazit zadávané okno
            CardInfo info = new CardInfo();
            info.board = this;
            info.ShowDialog();
            AddCardToList(listIndex);
        } // works

        private void AddCardToList(int index)
        {
            //vytvareni karty
            Grid card = new Grid();
            card.MouseUp += cardClick;
            card.Height = 50;
            card.Width = 250;
            card.Name = newName;
            boardClass.cardNumber++;
            Border newBorder = new Border();
            newBorder.BorderThickness = new Thickness(2);
            newBorder.BorderBrush = Brushes.Black;
            card.Children.Add(newBorder);
     
            //vytvrareni textu uvnitr karty
            TextBlock txt = new TextBlock();
            txt.Text = newName;
            txt.HorizontalAlignment = HorizontalAlignment.Center;
            txt.VerticalAlignment = VerticalAlignment.Center;
            txt.FontSize = 18;

            card.Children.Add(txt);
            card.Background = Brushes.White;
            boardClass.panelLists[index].Children.Add(card);
        } //works

        public void cardClick(object sender, RoutedEventArgs e)
        {
            string str = ((Grid)sender).Name;
            Trace.WriteLine("Here is the name: " + str);
            CardInfoChange changeCardInfo = new CardInfoChange(str, "nigga");
            changeCardInfo.ShowDialog();
        } //otevre upravovaci okno

        private void AddList(object sender, RoutedEventArgs e)
        {
            AddListButton.Margin = new Thickness(AddListButton.Margin.Left + 500, AddListButton.Margin.Top, AddListButton.Margin.Right, AddListButton.Margin.Bottom);
            AddListToBoard();
        } //prida list poznamek

        private void AddListToBoard()
        {
            int index = boardClass.cardLists.Count;

            //Pridani listu a jeho jmena
            Grid list = new Grid();
            list.Name = "CardPanel" + index;
            list.Height = 150;
            list.Width = 400;
            list.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF7C7C7C");
            list.HorizontalAlignment = HorizontalAlignment.Left;
            list.VerticalAlignment = VerticalAlignment.Top;
            list.Margin = new Thickness((index)*500, 50, 0, 0);

            StackPanel stackPan = new StackPanel();
            stackPan.Name = "CardList" + index;
            stackPan.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFB12B2B");
            stackPan.Margin = new Thickness(68, 10, 68, 90);
            stackPan.Height = 0;

            Button addCardBtn = new Button();
            addCardBtn.Name = "AddCardButton" + index;
            addCardBtn.Content = "+";
            addCardBtn.HorizontalAlignment = HorizontalAlignment.Center;
            addCardBtn.VerticalAlignment = VerticalAlignment.Top;
            addCardBtn.Height = 50;
            addCardBtn.Width = 150;
            addCardBtn.Margin = new Thickness(0, 90, 0, 0);
            addCardBtn.Click += AddCard;

            list.Children.Add(addCardBtn);
            list.Children.Add(stackPan);
            MainGrid.Children.Add(list);

            boardClass.cardLists.Add(list);
            boardClass.panelLists.Add(stackPan);
            boardClass.buttonLists.Add(addCardBtn);
        } //Prida list poznamek do boardu
    }
}
