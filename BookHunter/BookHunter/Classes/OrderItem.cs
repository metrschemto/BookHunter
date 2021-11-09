using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BookHunter.Classes
{
    class OrderItem
    {
        public string OrderCode { get; set; }
        public string BookCode { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public string BookCount { get; set; }
        public string BookCost { get; set; }
        public BitmapImage ImageBook { get; set; }
    }
}
