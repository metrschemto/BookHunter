using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace BookHunterManagment.Classes
{
    class Order
    {
        public string OrderCode { get; set; }
        public SolidColorBrush ColorLabel { get; set; }
        public string OrderStatus { get; set; }
        public string OrderCost { get; set; }
        public bool IsEnableButton { get; set; }
    }
}
