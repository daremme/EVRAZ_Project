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

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            int rowCount = Defect.Items.Count; // количество строк в массиве
            double[,] resultArray = new double[rowCount, 2]; // создаем двумерный массив с двумя столбцами

            for (int i = 0; i < rowCount; i++)
            {
                Def_Array namedArray = (Def_Array)Defect.Items[i]; // получаем элемент ListBox типа NamedArray
                double[] array = namedArray.Array; // получаем массив из элемента NamedArray
                resultArray[i, 0] = array[0]; // записываем имя массива в первый столбец
                resultArray[i, 1] = array[1]; // записываем значения массива во второй столбец
            }

        }

        private void Add_def_Click(object sender, RoutedEventArgs e)
        {
            int Type;
            if (Type_defect.Text.Trim()=="Трещина") { Type = 0; }    
            else { Type = 1; }
            
            string len = Lenght_defect.Text.Trim();
            double Lenght;
            if (double.TryParse(len, out Lenght))
            {
                double[] mas = new double[] { Type, Lenght };
                var varmas  = new Def_Array { Array=mas };
                Defect.Items.Add(varmas);
            }
            else { MessageBox.Show("Длина должна быть вещественным числом"); }
        }

        private void Lenght_defect_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            int l = 0;
            if (l == 0)
            {
                Lenght_defect.Clear();
                l++;
            }
        }
    }
}
