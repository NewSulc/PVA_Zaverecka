using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Web.UI.WebControls;

namespace ZaverecnaPrace
{
    internal class UserClass
    {
        public string name;
        public string password;
        public List<ProjectClass> projects;

        public UserClass(string name, string password)
        {
            this.name = name;
            this.password = password;
        }

        public UserClass changeUserData(bool changePassword, string newData)
        {
            string[] userData = File.ReadAllLines("AllData/UserData.txt");
            UserClass newUser = new UserClass(this.name, this.password);

            for (int i = 0; i < userData.Length; i++)
            {
                if (userData[i].Contains(this.name))
                {
                    if (changePassword)
                    {
                        newUser = new UserClass(this.name, newData);
                        userData[i] = this.name + ";" + newData;
                    }
                    else
                    {
                        newUser = new UserClass(newData, this.password);
                        userData[i] = newData + ";" + this.password;
                    }
                    break;
                }
            }

            File.WriteAllLines("AllData/UserData.txt", userData);
            return newUser;
        }

        public static bool autorization(bool isPassword, string dataToCheck)
        {
            if (isPassword)
            {
                if (dataToCheck.Length < 6 || dataToCheck.Contains(" ")) return false;
            }
            else
            {
                char[] validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789._".ToCharArray();
                for (int i = 0; i < dataToCheck.Length; i++)
                {
                    if (!validChars.Contains(dataToCheck[i])) return false;
                }
            }

            return true;
        }

        public void createProject(string projectName)
        {
            Trace.WriteLine(this.name);
            checkFolder();
            //if (!Directory.Exists("AllData/" + this.name + "/" + projectName)) Directory.CreateDirectory("AllData/" + this.name + "/" + projectName);
            //if (!File.Exists("AllData/" + this.name + "/" + this.name + ".txt"))
            //{
            //    File.WriteAllText("AllData/" + this.name + "/" + this.name + "_data.txt", "smh");
            //}
        }

        private void checkFolder()
        {
            string folderPath = "AllData/" + this.name;
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
            Trace.WriteLine(folderPath);
        }
    }
}
