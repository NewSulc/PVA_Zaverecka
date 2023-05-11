using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
}
