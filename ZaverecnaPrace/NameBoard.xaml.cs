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
    /// Interakční logika pro NameBoard.xaml
    /// </summary>
    public partial class NameBoard : Window
    {
        public string mainText;

        public NameBoard()
        {
            InitializeComponent();
            Naming.Text = mainText;
        }

        public Projects projects;

        private void NameClick(object sender, RoutedEventArgs e)
        {
            projects.newBoardName = Naming.Text;
            this.Close();
        }

    }
}
