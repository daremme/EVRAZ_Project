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
    /// Логика взаимодействия для Process_window.xaml
    /// </summary>
    public partial class Process_window : Window
    {
        public Process_window()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            
        }
        
        private void Storage_Click(object sender, RoutedEventArgs e)
        {
            
            if (Department.Items.Count > 0)
            {
                Rails rails = new Rails();
                rails = Department.Items[0] as Rails;
                //Со склада в печь
                if (rails.Position == 1 && Department.SelectedIndex >= 0)
                {
                    rails = Department.SelectedItem as Rails;
                    rails.Position = 2;
                    MainWindow k = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                    k.Storage.Items.Remove(rails);
                    Department.Items.Remove(rails);
                    k.Furnace.Items.Add(rails);
                    
                    Reports report = new Reports(2,rails);
                    k.Documents.Items.Add(report);
                    k.Documents.Items.Add(report);
                }
                //С печи на прокат
                if ((rails.Position == 2 || rails.Position == 3) && Department.SelectedIndex >= 0)
                {
                    rails = Department.SelectedItem as Rails;
                    rails.Position = 4;
                    MainWindow k = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(); 
                    k.Furnace.Items.Remove(rails);
                    Department.Items.Remove(rails);
                    k.Mill.Items.Add(rails);

                    Reports report = new Reports(4, rails);
                    k.Documents.Items.Add(report);
                    k.Documents.Items.Add(report);
                }
                //С проката в холодильник
                if (rails.Position == 4 && Department.SelectedIndex >= 0)
                {
                    rails = Department.SelectedItem as Rails;
                    rails.Position = 5;
                    MainWindow k = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(); 
                    k.Mill.Items.Remove(rails);
                    Department.Items.Remove(rails);
                    k.Fridge.Items.Add(rails);

                    Reports report = new Reports(5, rails);
                    k.Documents.Items.Add(report);
                    k.Documents.Items.Add(report);
                }
                //С хранилища на контроль
                if (rails.Position == 6 && Department.SelectedIndex >= 0)
                {
                    rails = Department.SelectedItem as Rails;
                    rails.Position = 7;
                    MainWindow k = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(); 
                    k.Add_fridge.Items.Remove(rails);
                    Department.Items.Remove(rails);
                    k.Checkup.Items.Add(rails);

                    Reports report = new Reports(7, rails);
                    k.Documents.Items.Add(report);
                    k.Documents.Items.Add(report);
                }
                //С контроля на отгрузку
                if ((rails.Position == 8 || rails.Position == 7) && Department.SelectedIndex >= 0)
                {

                    rails = Department.SelectedItem as Rails;
                    rails.Position = 9;
                    MainWindow k = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(); 
                    k.Checkup.Items.Remove(rails);
                    Department.Items.Remove(rails);
                    k.Shipment.Items.Add(rails);

                    Reports report = new Reports(9, rails);
                    k.Documents.Items.Add(report);
                    k.Documents.Items.Add(report);
                }
                //С отгрузки в .......
                if (rails.Position == 9 && Department.SelectedIndex >= 0)
                {
                    rails = Department.SelectedItem as Rails;
                    MainWindow k = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(); 
                    k.Shipment.Items.Remove(rails);
                    Department.Items.Remove(rails);

                    Reports report = new Reports(10, rails);
                    k.Documents.Items.Add(report);
                    //В дальнейшем реализовать создание отчета и удаление из базы(наверное)
                }
            }
        }
    }
}
