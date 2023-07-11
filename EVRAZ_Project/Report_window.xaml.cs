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

namespace EVRAZ_Project
{
    /// <summary>
    /// Логика взаимодействия для Report_window.xaml
    /// </summary>
    public partial class Report_window : Window
    {
        public Report_window()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
