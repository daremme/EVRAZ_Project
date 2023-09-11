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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity.Infrastructure.Design;

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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string connect = ConfigurationManager.ConnectionStrings["EVRAZ_Project.Properties.Settings.EvrazDB_TestConnectionString"].ConnectionString;
            string sql1 = "SELECT Prof_name FROM Profile_Prod";
            string sql2 = "SELECT Marka_type FROM Marka_Prod";
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql1, connect))
            {
                DataTable db = new DataTable();
                adapter.Fill(db);
                Profile.ItemsSource = db.DefaultView;
                //Отображение
                Profile.DisplayMemberPath = "Prof_name";
            }
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql2, connect))
            {
                DataTable db = new DataTable();
                adapter.Fill(db);
                Steel_grade.ItemsSource = db.DefaultView;
                //Отображение
                Steel_grade.DisplayMemberPath = "Marka_type";
            }
        }


        
        int m = 0;
        int n = 0;
        private void Stamp_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (n == 0)
            {
                Stamp.Clear();
                n++;
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
                if (Steel_grade.Text.Trim() == "")
                {
                    Steel_grade.Focus();
                    throw new Exception("Выберете марку стали поступившей балки");
                }
                if (Profile.Text.Trim() == "")
                {
                    Profile.Focus();
                    throw new Exception("Выберете профиль поступившей балки");
                }
                if (Date.Text.Trim() == "Выбор даты" || Date.Text.Trim() == "")
                {
                    Date.Focus();
                    throw new Exception("Дата введена неверно");
                }

                string[] time = Time.Text.Trim().Split(new char[] { ':', '.', ',', '\\', '/' });
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
                    Rails Rail = new Rails(Stamp.Text.Trim(), Steel_grade.Text.Trim(), Profile.Text.Trim(), Dialog.Maker.Text.Trim(), Convert.ToDouble(Dialog.Length.Text.Trim()), Convert.ToDouble(Dialog.Width.Text.Trim()), Convert.ToDouble(Dialog.Height.Text.Trim()), Convert.ToInt32(Dialog.Year.Text.Trim()));

                    Rail.PrewiosPos = 0;
                    Rail.Position = 0;
                    string[] time = Time.Text.Trim().Split(new char[] { ':', '.', ',', '\\', '/' });
                    Reports reports = new Reports(Environment.UserName, Date.Text.Trim(), time[0] + ":" + time[1], Rail);

                    reports.Position = Rail.Position;
                    reports.Type = 0;

                    Delivery.Items.Add(Rail);
                    Documents.Items.Add(reports);

                    int ID_ = 0;

                    string connect = ConfigurationManager.ConnectionStrings["EVRAZ_Project.Properties.Settings.EvrazDB_TestConnectionString"].ConnectionString;
                    
                    string sql_prod = $"INSERT INTO Products_Ved(Kleim,Profile,Marka,ID_Place) VALUES ('{Rail.Stamp}','{Rail.Profile_ID}','{Rail.Steel_grade_ID}','{Rail.Position}')";

                    string test = $"Select ID From Products_Ved where Kleim='{Rail.Stamp}'";
                    using (SqlConnection connection = new SqlConnection(connect))
                    {
                        connection.Open();


                        using (SqlCommand command = new SqlCommand(sql_prod, connection)) 
                        {
                            command.ExecuteNonQuery();
                        }
                        using (SqlCommand command = new SqlCommand(test, connection))
                        {

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    ID_ = reader.GetInt32(0);
                                }
                            }
                        }
                        using (SqlCommand command = new SqlCommand(sql_char, connection)) { }
                        connection.Close();
                    }*/



                    MessageBox.Show(Rail.ToString() + " успешно добавлена", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    MessageBox.Show(reports.Name, "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                /*if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Suka", "Blyat3");
                }*/
            }
            // connection.Close();
        }
        private void Find_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("awggr", "Требуется исправление", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void Delivery_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Delivery.Items.Count != 0)
            {
                Department_window Dialog = new Department_window();
                Dialog.Title = "Продукты на поставке";

                for (int i = 0; i < Delivery.Items.Count; i++)
                {
                    Rails Rail = Delivery.Items[i] as Rails;
                    Dialog.Department.Items.Add(Rail);
                }

                bool? result = Dialog.ShowDialog();
            }
        }

        private void Fridge_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Fridge.Items.Count != 0)
            {
                Department_window Dialog = new Department_window();
                Dialog.Title = "Продукты в холодильнике";

                for (int i = 0; i < Fridge.Items.Count; i++)
                {
                    Rails Rail = Fridge.Items[i] as Rails;
                    Dialog.Department.Items.Add(Rail);
                }

                bool? result = Dialog.ShowDialog();
            }
        }

        private void Storage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Storage.Items.Count != 0)
            {
                Process_window Dialog = new Process_window();
                Dialog.Title = "Продукты на складе";

                for (int i = 0; i < Storage.Items.Count; i++)
                {
                    Rails Rail = Storage.Items[i] as Rails;
                    Dialog.Department.Items.Add(Rail);
                }

                bool? result = Dialog.ShowDialog();
            }
        }

        private void Furnace_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Furnace.Items.Count != 0)
            {
                Process_window Dialog = new Process_window();
                Dialog.Title = "Продукты в печи";

                for (int i = 0; i < Furnace.Items.Count; i++)
                {
                    Rails Rail = Furnace.Items[i] as Rails;
                    Dialog.Department.Items.Add(Rail);
                }

                bool? result = Dialog.ShowDialog();
            }
        }

        private void Mill_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mill.Items.Count != 0)
            {
                Process_window Dialog = new Process_window();
                Dialog.Title = "Продукты на прокате";

                for (int i = 0; i < Mill.Items.Count; i++)
                {
                    Rails Rail = Mill.Items[i] as Rails;
                    Dialog.Department.Items.Add(Rail);
                }

                bool? result = Dialog.ShowDialog();
            }
        }

        private void Add_fridge_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Add_fridge.Items.Count != 0)
            {
                Process_window Dialog = new Process_window();
                Dialog.Title = "Продукты в хранилище";

                for (int i = 0; i < Add_fridge.Items.Count; i++)
                {
                    Rails Rail = Add_fridge.Items[i] as Rails;
                    Dialog.Department.Items.Add(Rail);
                }

                bool? result = Dialog.ShowDialog();
            }
        }

        private void Сheckup_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Checkup.Items.Count != 0)
            {
                Process_window Dialog = new Process_window();
                Dialog.Title = "Продукты на контроле";

                for (int i = 0; i < Checkup.Items.Count; i++)
                {
                    Rails Rail = Checkup.Items[i] as Rails;
                    Dialog.Department.Items.Add(Rail);
                }

                bool? result = Dialog.ShowDialog();
            }
        }

        private void Shipment_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Shipment.Items.Count != 0)
            {
                Process_window Dialog = new Process_window();
                Dialog.Title = "Продукты на погрузке";

                for (int i = 0; i < Shipment.Items.Count; i++)
                {
                    Rails Rail = Shipment.Items[i] as Rails;
                    Dialog.Department.Items.Add(Rail);
                }

                bool? result = Dialog.ShowDialog();
            }
        }

        private void Documents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (Documents.SelectedItem.GetType() == typeof(Reports))
            {
                Report_window Dialog = new Report_window();
                Dialog.Title = "Создание ведомости о поставке";
                Reports report = Documents.SelectedItem as Reports;
                Dialog.Steel_grade.Text = report.Rail.Steel_grade;
                Dialog.Profile.Text = report.Rail.Profile;
                Dialog.Stamp.Text = report.Rail.Stamp;
                Dialog.Length.Text = report.Rail.Length.ToString();
                Dialog.Width.Text = report.Rail.Width.ToString();
                Dialog.Year.Text = report.Rail.Year.ToString();
                Dialog.Height.Text = report.Rail.Height.ToString();
                Dialog.Maker.Text = report.Rail.Maker;
                Dialog.Time.Text = report.Time.ToString();
                DateTime date = DateTime.Parse(report.Time);
                Dialog.Date.SelectedDate = date;
                Dialog.Date.IsEnabled = false;
                Dialog.Time.IsReadOnly = true;
                Dialog.Time.IsReadOnlyCaretVisible = false;
                Dialog.ShowDialog();
            }
            else if (report._Rails.Position == 6 && report.k==1)
            {
                Control_window Dialog = new Control_window();
                Dialog.Title = "Создание ведомости";
                Dialog.Steel_grade.Text = report._Rails.Steel_grade;
                Dialog.Profile.Text = report._Rails.Profile;
                Dialog.Stamp.Text = report._Rails.Stamp;
                Dialog.Length.Text = report._Rails.Length.ToString();
                Dialog.Width.Text = report._Rails.Width.ToString();
                Dialog.Year.Text = report._Rails.Year.ToString();
                Dialog.Height.Text = report._Rails.Height.ToString();
                Dialog.Maker.Text = report._Rails.Maker;
                Dialog.ShowDialog();
            }
            else if (Documents.SelectedItem.GetType() == typeof(Rails))
            {
                Rails Rail = Documents.SelectedItem as Rails;
                if (Rail.Position == 7)
                {
                    Control_window Dialog = new Control_window();
                    Dialog.Title = "Создание ведомости о дефектах балки";

                    Dialog.Steel_grade.Text = Rail.Steel_grade;
                    Dialog.Profile.Text = Rail.Profile;
                    Dialog.Stamp.Text = Rail.Stamp;
                    Dialog.Length.Text = Rail.Length.ToString();
                    Dialog.Width.Text = Rail.Width.ToString();
                    Dialog.Year.Text = Rail.Year.ToString();
                    Dialog.Height.Text = Rail.Height.ToString();
                    Dialog.Maker.Text = Rail.Maker;
                    Dialog.ShowDialog();
                }
                else
                {
                    Report_window Dialog = new Report_window();
                    Dialog.Title = "Создание ведомости";

                    Dialog.Steel_grade.Text = Rail.Steel_grade;
                    Dialog.Profile.Text = Rail.Profile;
                    Dialog.Stamp.Text = Rail.Stamp;
                    Dialog.Length.Text = Rail.Length.ToString();
                    Dialog.Width.Text = Rail.Width.ToString();
                    Dialog.Year.Text = Rail.Year.ToString();
                    Dialog.Height.Text = Rail.Height.ToString();
                    Dialog.Maker.Text = Rail.Maker;
                    Dialog.ShowDialog();
                }
            }
        }
    }
}

