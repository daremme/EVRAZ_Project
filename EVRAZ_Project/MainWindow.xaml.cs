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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EVRAZ_Project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
        }
        int k = 0;
        int m = 0;
        int n = 0;
        private void Stamp_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (k == 0)
            {
                Stamp.Clear();
                k++;
            }
        }
        private void Time_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (m == 0)
            {
                Time.Clear();
                m++;
            }
        }
        private void Search_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (n == 0)
            {
                Search.Clear();
                n++;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Stamp.Text == "" || Stamp.Text == "Введите номер клейма")
                {
                    Stamp.Focus();
                    throw new Exception("Не введено клеймо поступившей балки");
                }
                if (Steel_grade.Text == "")
                {
                    Steel_grade.Focus();
                    throw new Exception("Выберете марку стали поступившей балки");
                }
                if (Profile.Text == "")
                {
                    Profile.Focus();
                    throw new Exception("Выберете профиль поступившей балки");
                }
                if (Date.Text == "Выбор даты"|| Date.Text=="")
                {
                    Date.Focus();
                    throw new Exception("Дата введена неверно");
                }

                string[] time = Time.Text.Split(new char[] { ':','.',',','\\' });
                if(time.Length !=2)
                {
                    Time.Focus();
                    throw new Exception("Время введено неверно");
                }
                if(Convert.ToInt32(time[0]) < 0 || Convert.ToInt32(time[0]) > 24 || Convert.ToInt32(time[0]) < 0 || Convert.ToInt32(time[1]) > 60)
                {
                    Time.Focus();
                    throw new Exception("Время введено неверно");
                }

            }
            catch (FormatException)
            {
                Time.Focus();
                MessageBox.Show("Время введено неверно", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }



        private void Find_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("awggr", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);

        }


    }
}
