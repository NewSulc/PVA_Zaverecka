using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ZaverecnaPrace
{
    internal class BoardClasses
    {
        public List<Grid> cardLists = new List<Grid>();
        public List<StackPanel> panelLists = new List<StackPanel>();
        public List<Button> buttonLists = new List<Button>();

        public int cardNumber;

        public List<CardClass> cardClassLists = new List<CardClass>();
    }

    internal class CardClass
    {
        public string cardName;
        public string cardDescription;
        public int indexInList;
    }

    internal class BoardClass
    {
        public List<CardClass> cardClassesList = new List<CardClass>();
        public string boardName;
    }

    internal class ProjectClass
    {
        public string projectName;
        public List<BoardClass> boardClassList = new List<BoardClass>();
    }

    internal class UserClass
    {
        public string userName;
        public string userEmail;
        public string userPassword;
        public List<ProjectClass> projectClassList = new List<ProjectClass>();
    }
}
