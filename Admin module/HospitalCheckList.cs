using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CProject.Admin_module
{
    internal class HospitalCheckList
    {
        int ch;
        bool f = true;
        public void HospitalChoice()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("       MENU FOR HOSPITAL LIST  ");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("1.Check All  Hospital List         ");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("2.Check All Valid  hospital List      ");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("3.Check  Deleted Hospital List       ");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("4.Exit");
                Console.WriteLine("---------------------------------");
                try
                {
                    Console.WriteLine("Enter choice :");
                    ch = int.Parse(Console.ReadLine());
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("please Enter Correct choice...");
                }
                switch (ch)
                {

                    case 1:
                        Console.Clear();
                        Console.WriteLine("Your choice :" + ch);
                        HospitalList();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Your choice :" + ch);
                        HospitalListValid();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Your choice :" + ch);
                        HospitalListInValid();
                        break;

                    

                    case 4:

                        f = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("----------------------------------------------------");
                        Console.WriteLine("Invalid Choice");
                        Console.WriteLine("Please Enter valid choice from Menu");
                        Console.WriteLine("----------------------------------------------------");
                        break;
                }

            } while (f == true);
        }

        //ALL Hospital  List 
        private void HospitalList()
        {
            
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = $"select CEC_number,Hospital_name from Hospital ";
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                Console.Clear();
                Console.WriteLine("  ALL  Hospital List !!   ");
                int n = 1;
                while (rdr.Read())
                {
                    Console.WriteLine(" Sr.No " + n);
                    Console.WriteLine(" CEC number = " + rdr["CEC_number"]);
                    Console.WriteLine(" Hospital Name = " + rdr["Hospital_name"]);
                    Console.WriteLine();
                    n++;
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No hospital Present");
                Console.ReadKey();

            }
            con.Close();
        }

        //Valid Hospital List
        private void HospitalListValid()
        {
            bool Isdelete=true;
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = $"select CEC_number,Hospital_name from Hospital where IsDelete!='{Isdelete}'";
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                Console.Clear();
                Console.WriteLine(" ALL  Valid  Hospital List !!   ");
                int n = 1;
                while (rdr.Read() )
                {
                    Console.WriteLine(" Sr.No "+n);
                    Console.WriteLine(" CEC number = "+rdr["CEC_number"]); 
                    Console.WriteLine(" Hospital Name = " + rdr["Hospital_name"]);
                    Console.WriteLine();
                    n++;
                }
               Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No hospital Present");
                Console.ReadKey();
                
            }
            con.Close();
        }

        //All Deleted Hospital List
        private void HospitalListInValid()
        {
            bool Isdelete = false;
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = $"select CEC_number,Hospital_name from Hospital where IsDelete!='{Isdelete}'";
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                Console.Clear();
                Console.WriteLine(" ALL  Valid  Hospital List !!   ");
                int n = 1;
                while (rdr.Read())
                {
                    Console.WriteLine(" Sr.No " + n);
                    Console.WriteLine(" CEC number = " + rdr["CEC_number"]);
                    Console.WriteLine(" Hospital Name = " + rdr["Hospital_name"]);
                    Console.WriteLine();
                    n++;
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No hospital Present");
                Console.ReadKey();

            }
            con.Close();
        }
    }
}
