using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZaverecnaPrace
{
    internal class ProjectClass
    {
        public string name;
        public string user;

        public ProjectClass(string name, string user)
        {
            this.name = name;
            this.user = user;
        }

        public void createFolder()
        {
            checkFolder();
        }

        private void checkFolder()
        {
            string folderName = "AllData/" + this.user + "/" + this.name;
            if (!Directory.Exists(folderName)) Directory.CreateDirectory(folderName);
        }
    }
}
