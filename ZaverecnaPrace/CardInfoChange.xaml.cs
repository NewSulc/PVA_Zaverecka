using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class CardInfoChange : Window
    {

        public CardInfoChange(string name, string description)
        {
            InitializeComponent();
            CardInfoName.Text = name;
            CardInfoDesc.Text = description;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            ((Board)Application.Current.MainWindow).newName = CardInfoName.Text;
            ((Board)Application.Current.MainWindow).newDescription = CardInfoDesc.Text;
            this.Close();
        }
    }
}
