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
using System.Threading;
using System.Diagnostics;

namespace ZaverecnaPrace
{
    /// <summary>
    /// Interakční logika pro NewProfile.xaml
    /// </summary>
    public partial class NewProfile : Window
    {

        public NewProfile()
        {
            InitializeComponent();
            Trace.WriteLine("Good to go!");
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists("AllData")) Directory.CreateDirectory("AllData");
            if (!File.Exists("AllData/UserData.txt")) File.Create("AllData/UserData.txt").Close();


            List<string> userData = File.ReadAllLines("AllData/UserData.txt").ToList();
            for (int i = 0; i < userData.Count; i++)
            {
                userData[i] = userData[i].Split(';')[0];
            }

            if (userData.Contains(UserName.Text)) errorMsg.Text = "This username already exist";
            else if (!UserClass.autorization(true, Password.Password)) errorMsg.Text = "Password muset be longer than 6 characters and can't contain SPACE";
            else if (!UserClass.autorization(false, UserName.Text)) errorMsg.Text = "Wrong username";
            else
            {
                string newUserData = UserName.Text + ";" + Password.Password + "\n";
                File.AppendAllText("AllData/UserData.txt", newUserData);
                this.Close();
            }
        }
    }
}
