using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;



namespace WpfWithDB
{

    public partial class MainWindow : Window
    {
        //private ObservableCollection<string> list = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            using (
                SqlConnection saConn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString())
                )
            {
                saConn.Open();

                string query = "select First_Name from Catalog";
                SqlCommand cmd = new SqlCommand(query, saConn);

                using (SqlDataReader saReader = cmd.ExecuteReader())
                {
                    while (saReader.Read())
                    {
                        comboBox1.Items.Add(saReader.GetString(0));
                        //string name = saReader.GetString(0);
                        //list.Add(name);
                    }
                }
                //comboBox1.ItemsSource = list;

                saConn.Close();
            }





      

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win2 = new Insert();
            
            win2.Show();
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           var selectedvalue= comboBox1.SelectedValue.ToString();
            var es = new Employees();
            Employee emp = es.GetEmployee(selectedvalue);
            var win2 = new Load();
            win2.NameTb.Text = emp.FirstName;
            win2.LastTb.Text = emp.LastName;
            win2.AddressTb.Text = emp.Address;
            win2.EmailTb.Text = emp.Email;
            win2.GenderTb.Text = emp.Gender.ToString();
            win2.Show();
            this.Close();

        }


        private void NameList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var c = sender as ComboBox;
            //var selectedvalue = c.SelectedValue.ToString();

           
            
           






        }
    }
}
