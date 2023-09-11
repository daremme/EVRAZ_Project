using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
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
    /// Логика взаимодействия для Control_window.xaml
    /// </summary>
    public partial class Control_window : Window
    {
        public Control_window()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
           
           
        }

        /*private void Add_def_Click(object sender, RoutedEventArgs e)
        {
            Defects Dialog = new Defects();
            Dialog.Title = "Добавить информацию о дефектах";
            string connect = ConfigurationManager.ConnectionStrings["EVRAZ_Project.Properties.Settings.EvrazDB_TestConnectionString"].ConnectionString;
            string sql1 = "SELECT Type_def FROM Type_Def";
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql1, connect))
            {
                DataTable db = new DataTable();
                adapter.Fill(db);
                Dialog.Type_defect.ItemsSource = db.DefaultView;
                //Отображение
                Dialog.Type_defect.DisplayMemberPath = "Type_def";
            }
            Dialog.ShowDialog();
        }*/

        Defect[] defects;
        public Defect[] GetDef
        {
            get { return defects; }
            set { defects = value; }
        }
        List<Defect> ListLoad=new List<Defect>();
        private void Add_def_Click(object sender, RoutedEventArgs e)
        {

            Defects Dialog = new Defects();
            Dialog.Title = "Добавление дефектов";
            if (ListLoad != null) 
            {
                for (int i = 0; i < ListLoad.Count; i++)
                {
                    Dialog.Defect_List.Items.Add(ListLoad[i]);
                }
            }
            Dialog.Closed += (s, args) =>
            {
                ListLoad.Clear();
                // Сохранить данные ListBox после закрытия окна
                for (int i = 0; i < Dialog.Defect_List.Items.Count; i++)
                {
                    ListLoad.Add(Dialog.Defect_List.Items[i] as Defect);
                }
            };

            Dialog.ShowDialog();


            //Defect[] defects = new Defect[Dialog.Defect_List.Items.Count];
            /*bool? result = Dialog.ShowDialog();

            if (result == true)
                MessageBox.Show(ListLoad[0].ToString());*/
            /*for (int i = 0; i < defects.Length; i++)
        {

            defects[i] = Dialog.Defect_List.Items[i] as Defect;
        }


        *//*bool? result = Dialog.ShowDialog();
        if (result == true)
            for (int i = 0; i < Dialog.Defect_List.Items.Count; i++)
                defects1.Append(Dialog.Defect_List.Items[i]);*//*
        MessageBox.Show(defects.Length.ToString());
        MessageBox.Show(defects[0].Lenght_def.ToString());*/
        }
    }
}
