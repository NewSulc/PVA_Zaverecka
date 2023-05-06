using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
    public partial class Projects : Window
    {
        public string newBoardName;

        public Projects()
        {
            InitializeComponent();
        }

        private void CreateBoard(object sender, RoutedEventArgs e)
        {
            NameBoard nameBoard = new NameBoard();
            nameBoard.projects = this;
            nameBoard.mainText = "Name this board!";
            nameBoard.ShowDialog();

            Grid newBoard = new Grid();
            newBoard.Margin = new Thickness(25, 25, 25, 25);
            newBoard.Width = 250;
            newBoard.Height = 150;
            newBoard.Background = Brushes.White;

            TextBlock txt = new TextBlock();
            txt.Text = newBoardName;
            txt.HorizontalAlignment = HorizontalAlignment.Center;
            txt.VerticalAlignment = VerticalAlignment.Center;
            txt.FontSize = 24;

            newBoardName = newBoardName.Replace(" ", "_");
            newBoard.Name = newBoardName;

            newBoard.MouseDown += GoToBoard;

            BoardStackPanel.Children.Add(newBoard);
            newBoard.Children.Add(txt);
        }

        private void CreateProject(object sender, RoutedEventArgs e)
        {
            NameBoard nameBoard = new NameBoard();
            nameBoard.projects = this;
            nameBoard.mainText = "Name this project!!!";
            nameBoard.ShowDialog();

            Grid newBoard = new Grid();
            newBoard.Margin = new Thickness(25, 25, 25, 25);
            newBoard.Width = 100;
            newBoard.Height = 75;
            newBoard.Background = Brushes.White;
            newBoard.Name = newBoardName;

            TextBlock txt = new TextBlock();
            txt.Text = newBoardName;
            txt.HorizontalAlignment = HorizontalAlignment.Center;
            txt.VerticalAlignment = VerticalAlignment.Center;
            txt.FontSize = 20;

            ProjectStackPanel.Children.Add(newBoard);
            newBoard.Children.Add(txt);
        }

        private void GoToBoard(object sender, RoutedEventArgs e)
        {
            Board newBoard = new Board();
            newBoard.Show();
            this.Close();
        }
    }
}
