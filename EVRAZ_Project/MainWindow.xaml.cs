﻿using System;
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
            bool q = false;
            try
            {
                if (Stamp.Text.Trim() == "" || Stamp.Text.Trim() == "Введите номер клейма")
                {
                    Stamp.Focus();
                    throw new Exception("Не введено клеймо поступившей балки");
                }
                //if (Steel_grade.Text.Trim() == "")
                //{
                //    Steel_grade.Focus();
                //    throw new Exception("Выберете марку стали поступившей балки");
                //}
                //if (Profile.Text.Trim() == "")
                //{
                //    Profile.Focus();
                //    throw new Exception("Выберете профиль поступившей балки");
                //}
                if (Date.Text.Trim() == "Выбор даты" || Date.Text.Trim() == "")
                {
                    Date.Focus();
                    throw new Exception("Дата введена неверно");
                }

                string[] time = Time.Text.Trim().Split(new char[] { ':', '.', ',', '\\' });
                if (time.Length != 2)
                {
                    Time.Focus();
                    throw new Exception("Время введено неверно");
                }
                if (Convert.ToInt32(time[0]) < 0 || Convert.ToInt32(time[0]) > 24 || Convert.ToInt32(time[0]) < 0 || Convert.ToInt32(time[1]) > 60)
                {
                    Time.Focus();
                    throw new Exception("Время введено неверно");
                }
                q = true;
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

            if (q)
            {
                Info_window Dialog = new Info_window();
                Dialog.Length.Text = "";
                Dialog.Width.Text = "";
                Dialog.Height.Text = "";
                Dialog.Maker.Text = "";
                Dialog.Year.Text = "";

                bool? result = Dialog.ShowDialog();

                if (result == true)
                {
                    Rails Rail = new Rails();
                    Rail.Stamp = Stamp.Text.Trim();
                    Rail.Steel_grade = Steel_grade.Text.Trim();
                    Rail.Profile = Profile.Text.Trim();

                    Rail.Length = Convert.ToDouble(Dialog.Length.Text.Trim());
                    Rail.Width = Convert.ToDouble(Dialog.Width.Text.Trim());
                    Rail.Height = Convert.ToDouble(Dialog.Height.Text.Trim());
                    Rail.Maker = Dialog.Maker.Text.Trim();
                    Rail.Year = Convert.ToInt32(Dialog.Year.Text.Trim());

                    Rail.Position = 0;

                    Delivery.Items.Add(Rail);
                }
                if (result == false)
                {
                    MessageBox.Show("Галя отмена", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }



        }



        private void Find_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("awggr", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void Delivery_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Department_window Dialog = new Department_window();
            Dialog.Title = "Продукты на поставке";

            bool? result = Dialog.ShowDialog();

            if (result == true)
            {
                MessageBox.Show("Оке доке", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (result == false)
            {
                MessageBox.Show("Галя отмена", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Fridge_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Department_window Dialog = new Department_window();
            Dialog.Title = "Продукты в холодильнике";

            bool? result = Dialog.ShowDialog();

            if (result == true)
            {
                MessageBox.Show("Оке доке", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (result == false)
            {
                MessageBox.Show("Галя отмена", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Storage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Process_window Dialog = new Process_window();
            Dialog.Title = "Продукты на складе";

            bool? result = Dialog.ShowDialog();

            if (result == true)
            {
                MessageBox.Show("Оке доке", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (result == false)
            {
                MessageBox.Show("Галя отмена", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Furnace_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Process_window Dialog = new Process_window();
            Dialog.Title = "Продукты в печи";

            bool? result = Dialog.ShowDialog();

            if (result == true)
            {
                MessageBox.Show("Оке доке", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (result == false)
            {
                MessageBox.Show("Галя отмена", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Mill_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Process_window Dialog = new Process_window();
            Dialog.Title = "Продукты на прокате";

            bool? result = Dialog.ShowDialog();

            if (result == true)
            {
                MessageBox.Show("Оке доке", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (result == false)
            {
                MessageBox.Show("Галя отмена", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Add_fridge_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Process_window Dialog = new Process_window();
            Dialog.Title = "Продукты в хранилище";

            bool? result = Dialog.ShowDialog();

            if (result == true)
            {
                MessageBox.Show("Оке доке", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (result == false)
            {
                MessageBox.Show("Галя отмена", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Сheckup_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Process_window Dialog = new Process_window();
            Dialog.Title = "Продукты на контроле";

            bool? result = Dialog.ShowDialog();

            if (result == true)
            {
                MessageBox.Show("Оке доке", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (result == false)
            {
                MessageBox.Show("Галя отмена", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Shipment_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Process_window Dialog = new Process_window();
            Dialog.Title = "Продукты на погрузке";

            bool? result = Dialog.ShowDialog();

            if (result == true)
            {
                MessageBox.Show("Оке доке", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (result == false)
            {
                MessageBox.Show("Галя отмена", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
