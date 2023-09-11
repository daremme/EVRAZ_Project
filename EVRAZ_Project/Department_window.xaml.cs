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
    /// Логика взаимодействия для Department_window.xaml
    /// </summary>
    public partial class Department_window : Window
    {
        public Department_window()
        {
            InitializeComponent();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (Department.Items.Count>0)
            {
                Rails rails = new Rails();
                rails = Department.Items[0] as Rails;
                //С поставки в печь
                if (rails.Position == 0 && Department.SelectedIndex >= 0)
                {
                    rails = Department.SelectedItem as Rails;
                    rails.Position = 2;
                    MainWindow k = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(); ;
                    k.Delivery.Items.Remove(rails);
                    Department.Items.Remove(rails);
                    k.Furnace.Items.Add(rails);
                    k.Documents.Items.Add(rails);
                    k.Documents.Items.Add(rails);
                }
                //С холодильника на контроль
                if (rails.Position == 4 && Department.SelectedIndex >= 0)
                {
                    rails = Department.SelectedItem as Rails;
                    rails.Position = 6;
                    MainWindow k = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(); ;
                    k.Fridge.Items.Remove(rails);
                    Department.Items.Remove(rails);
                    k.Checkup.Items.Add(rails);
                    k.Documents.Items.Add(rails);
                    k.Documents.Items.Add(rails);
                }
            }
        }

            private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Storage_Click(object sender, RoutedEventArgs e)
        {
            if (Department.Items.Count > 0)
            {
                Rails rails = new Rails();
                rails = Department.Items[0] as Rails;
                //С поставки на склад
                if (rails.Position == 0 && Department.SelectedIndex >= 0)
                {
                    rails = Department.SelectedItem as Rails;
                    rails.Position = 1;
                    rails.PrewiosPos = 1;
                    MainWindow k = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(); ;
                    k.Delivery.Items.Remove(rails);
                    Department.Items.Remove(rails);
                    k.Storage.Items.Add(rails);
                    k.Documents.Items.Add(rails);   
                }
                //С холодильника в хранилище
                if (rails.Position == 4 && Department.SelectedIndex >= 0)
                {
                    rails = Department.SelectedItem as Rails;
                    rails.Position = 5;
                    rails.PrewiosPos = 2;
                    MainWindow k = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(); ;
                    k.Fridge.Items.Remove(rails);
                    Department.Items.Remove(rails);
                    k.Add_fridge.Items.Add(rails);
                    k.Documents.Items.Add(rails);
                }
            }
        }
    }
}
