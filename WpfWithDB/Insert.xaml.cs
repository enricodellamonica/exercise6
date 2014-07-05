using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace WpfWithDB {
    /// <summary>
    /// Interaction logic for Insert.xaml
    /// </summary>
    public partial class Insert : Window
    {
        private string gender;
        public Insert() {
            InitializeComponent();
            
            }

       
        private void Button_Click(object sender, RoutedEventArgs e) {
        using(var cnn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString())) {
            cnn.Open();
            var cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText =
                "Insert into Catalog (First_Name,Last_Name,Address,Gender,Email) values (@FirstName,@LastName,@Address,@Gender,@Email)";
            
            cmd.Parameters.AddWithValue("@FirstName", NameTb.Text);
            cmd.Parameters.AddWithValue("@LastName", LastTb.Text);
            cmd.Parameters.AddWithValue("@Address", AddressTb.Text);
            cmd.Parameters.AddWithValue("@Gender",gender);
            cmd.Parameters.AddWithValue("@Email", EmailTb.Text);
            cmd.ExecuteNonQuery();

            }

            }

        

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var r = sender as RadioButton;
            if(r.IsChecked != null && (bool)r.IsChecked) {
                gender = r.Name;
                }
          
        }

      
    }
    }
