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
using System.IO;
using System.Linq;

namespace ZaverecnaPrace
{
    /// <summary>
    /// Interakční logika pro DeleteUser.xaml
    /// </summary>
    public partial class DeleteUser : Window
    {
        List<string> userData = new List<string>();
        public DeleteUser()
        {
            InitializeComponent();

            userData = File.ReadAllLines("AllData/UserData.txt").ToList();
            for (int i = 0; i < userData.Count; i++)
            {
                DropdownDelete.Items.Insert(i, userData[i].Split(';')[0]);
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            int selected = DropdownDelete.SelectedIndex;

            StreamReader sr = new StreamReader("AllData/UserData.txt");

            List<string> newData = new List<string>();

            while (true)
            {
                string line = sr.ReadLine();
                if (line == null) break;
                else if (line != userData[selected]) newData.Add(line);
            }

            sr.Close();

            File.WriteAllLines("AllData/UserData.txt", newData.ToArray());

            this.Close();
        }
    }
}
