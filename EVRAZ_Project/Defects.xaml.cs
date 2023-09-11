using System;
using System.Collections;
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
    /// Логика взаимодействия для Defects.xaml
    /// </summary>
    public partial class Defects : Window
    {
        public Defects()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Создать в БД таблицу с типами дефектов и заполнить ей комбо бокс

            Type_defect.Items.Add("Трещина");
            Type_defect.Items.Add("Разрыв");
            Type_defect.Items.Add("Скол");


            // Добавить заполнение уже известных дефектов, хз как 
        }

        private void Add_def_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Type_defect.Text.Trim() == "")
                {
                    Type_defect.Focus();
                    throw new Exception("Выберете тип дефекта заготовки");
                }
                if (Lenght_defect.Text.Trim() == "")
                {
                    Lenght_defect.Focus();
                    throw new Exception("Выберете длину дефекта заготовки");
                }
                Defect defect = new Defect(Convert.ToString(Type_defect.Text), Convert.ToDouble(Lenght_defect.Text.Trim()));
                Defect_List.Items.Add(defect);
            }
            catch (FormatException)
            {
                Lenght_defect.Focus();
                MessageBox.Show("Длина дефекта должна быть числом", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (Defect_List.SelectedIndex >= 0)
            {
                Defect_List.Items.Remove(Defect_List.Items[Defect_List.SelectedIndex]);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            if (Defect_List.Items.Count > 0)
            {

                Defect[] defects = new Defect[Defect_List.Items.Count];

                for (int i = 0; i < defects.Length; i++)
                {

                    defects[i] = Defect_List.Items[i] as Defect;
                }
                MessageBox.Show(defects.Length.ToString());
            }
            DialogResult = true;
            

        }

    }
}
