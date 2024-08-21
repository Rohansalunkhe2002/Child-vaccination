using CProject.child_Module;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CProject.Admin_module
{
    internal class LoginAdmin
    {
       
        string AD_User;
        string AD_Password;

        string AD_AadharString, AD_PasswordString;
        int Child_count = 0;
       



        public void CheckAdmininfo()
        {
            int n = 0;
            while (n != 1)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine(" Admin Login Form!!!");
                    Console.WriteLine("----------------------");
                    Console.WriteLine();
                    Console.WriteLine("Enter Admin user id");
                    AD_User = Console.ReadLine();
                    n = ValidateMyString(AD_User);    
                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.Clear();
                    Console.WriteLine("please Enter Correct Admin User id..");
                    Console.WriteLine("-------------------------------------------");

                }

            }


            n = 0;
            //-- User password
            while (n != 1)
            {
                try
                {

                    
                    Console.WriteLine("Enter your  Admin Password");
                    AD_Password = Console.ReadLine();
                    AD_Password = AD_Password.Trim();
                    n = 1;
                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.WriteLine("please Re-Enter Password");
                    Console.WriteLine("-------------------------------------------");

                }

            }


            static int ValidateMyString(string s)
            {
                Regex regex = new Regex("^[a-zA-Z]*$");

                if (!regex.IsMatch(s))
                {
                    Console.WriteLine("Please Re-Enter");
                    return 0;
                }
                return 1;
            }


            n = 0;
            //-- ckeck User Authentication
           
                Console.WriteLine();
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = $"select AD_user_id, AD_Password from Admin where AD_user_id='{AD_User}' AND AD_Password='{AD_Password}'";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    Console.Clear();
                    Console.WriteLine("   WELCOME ADMIN..!!   ");
                    Console.WriteLine(" YOU ARE  LOGIN NOW");
                    AddHospital AH= new AddHospital();
                    AH.ChoiceAdmin();
                    Console.Clear();
                    Console.WriteLine();
                    n = 1;
                }
                else
                {
                    Console.WriteLine("Invalid Credential...!!!");
                    Console.ReadKey();
                    n = 0;
                }
                con.Close();
            

        }
    }
}
