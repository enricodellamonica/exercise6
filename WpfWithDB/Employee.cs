using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfWithDB
{
    public class Employees
    {
        public List<Employee> EmployeeList { get; set; }

        public Employee GetEmployee(string selectedValue)
        {
            var e = new Employee();
            using (var cnn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString()))
            {
                cnn.Open();
                var cmd = new SqlCommand();

                cmd.Connection = cnn;
                cmd.CommandText =
                    "Select * from Catalog where First_Name='{0}'";

                cmd.CommandText = string.Format(cmd.CommandText, selectedValue);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    e.Load(reader);
                }
                return e;
            }

        }
    }

    public class Employee
        {
            //public int EmployeeId {
            //    get;
            //    set;
            //    }

            public string FirstName { get; set; }
            public string LastName { get; set; }

            public string Address { get; set; }

            public char Gender { get; set; }

            public string Email { get; set; }

            public void Load(SqlDataReader reader)
            {
                FirstName = reader["First_Name"].ToString();
                LastName = reader["Last_Name"].ToString();
                Address = reader["Address"].ToString();
                Email = reader["Email"].ToString();
                Gender = Char.Parse(reader["Gender"].ToString().Trim());


            }


        }
    }

