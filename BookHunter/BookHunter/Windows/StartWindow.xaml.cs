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

namespace BookHunter.Windows
{
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void MakeAnOrder_Click(object sender, RoutedEventArgs e)
        {
            Catalog catalogwindow = new Catalog();
            catalogwindow.Show();
            this.Close();
        }
    }
}
