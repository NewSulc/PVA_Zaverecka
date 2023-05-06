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
using MahApps.Metro.Controls;
using System.Diagnostics;

namespace ZaverecnaPrace
{
    public partial class Profile : Window
    {
        List<string> userData = new List<string>();
        public Profile()
        {
            InitializeComponent();
            if (File.Exists("AllData/UserData.txt")) WriteUserMenu();
            DeleteUserBtn.IsEnabled = CheckIfExist();
        }
        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            NewProfile newProfile = new NewProfile();
            newProfile.ShowDialog();
            WriteUserMenu();
            DeleteUserBtn.IsEnabled = CheckIfExist();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("AllData/UserData.txt"))
            {
                string[] allUsers = File.ReadAllLines("AllData/UserData.txt");
                string selectedUser = null;

                for (int i = 0; i < allUsers.Length; i++)
                {
                    if (allUsers[i].Contains(UserDropdown.SelectedItem.ToString())) selectedUser = allUsers[i];
                    break;
                }

                if (selectedUser.Contains(PasswordText.Text))
                {
                    Projects newProjects = new Projects();
                    newProjects.Show();
                    this.Close();
                }
            }
        }
        private void WriteUserMenu()
        {
            UserDropdown.Items.Clear();
            userData = File.ReadAllLines("AllData/UserData.txt").ToList();
            for (int i = 0; i < userData.Count; i++)
            {
                string[] dataName = userData[i].Split(';');
                UserDropdown.Items.Insert(i, dataName[0]);
            }
        }
        private bool CheckIfExist()
        {
            if (!File.Exists("AllData/UserData.txt")) return false;
            else return true;
        }
        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            DeleteUser deleteUser = new DeleteUser();
            deleteUser.ShowDialog();
            WriteUserMenu();
        }
    }
}
