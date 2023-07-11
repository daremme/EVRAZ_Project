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
    /// Логика взаимодействия для Info_window.xaml
    /// </summary>
    public partial class Info_window : Window
    {
        public Info_window()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DialogResult == true)
            {
                int i = 0;
                try
                {
                    if (Length.Text.Trim() == "")
                    {
                        Length.Focus();
                        throw new Exception("Введите значение длины продукта");
                    }
                    if (Width.Text.Trim() == "")
                    {
                        Width.Focus();
                        throw new Exception("Введите значение ширины продукта");
                    }
                    if (Height.Text.Trim() == "")
                    {
                        Height.Focus();
                        throw new Exception("Введите значение высоты продукта");
                    }
                    if (Maker.Text.Trim() == "")
                    {
                        Maker.Focus();
                        throw new Exception("Введите производителя продукта");
                    }
                    if (Year.Text.Trim() == "")
                    {
                        Year.Focus();
                        throw new Exception("Введите год производства продукта");
                    }
                    double example = Convert.ToDouble(Length.Text);
                    i = 1;
                    example = Convert.ToDouble(Width.Text);
                    i = 2;
                    example = Convert.ToDouble(Height.Text);
                    i = 3;
                    example = Convert.ToDouble(Year.Text);
                    if (example<2000 || example > DateTime.Today.Year)
                    {
                        Year.Focus();
                        throw new Exception("Год производства введен некорректно");
                    }
                }
                catch (FormatException)
                {
                    e.Cancel = true;
                    if (i == 0)
                    {
                        Length.Focus();
                        MessageBox.Show("Значение длины должно быть числом", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (i == 1)
                    {
                        Width.Focus();
                        MessageBox.Show("Значение ширины должно быть числом", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (i == 2)
                    {
                        Height.Focus();
                        MessageBox.Show("Значение высоты должно быть числом", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                    else if (i == 3)
                    {
                        Year.Focus();
                        MessageBox.Show("Значение года должно быть целым числом", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
                catch (Exception E)
                {
                    e.Cancel = true;
                    MessageBox.Show(E.Message, "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
