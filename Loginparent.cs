using CProject.child_Module;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CProject
{
    internal class Loginparent:parent
    {
        long M_Addhar_no;
        string M_Password;
        string AadharString, ContactString, PasswordString;
        int Child_count = 0;
        
        
        //Mother Parent Login
        public void Checkinfo()
        {
            int n = 0;
            while (n != 1)
            {
                try
                {

                    Console.WriteLine("Enter user id(Aadhar no))");

                    M_Addhar_no = long.Parse(Console.ReadLine());
                    AadharString = M_Addhar_no.ToString();
                    AadharString = AadharString.Trim();
                    if (AadharString.Length == 12)
                    {
                        n = 1;
                    }
                    else
                    {
                        Console.WriteLine("Please Re-Enter");
                        n = 0;
                    }
                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.Clear();
                    Console.WriteLine("Your choice :  2");
                    Console.WriteLine("please Enter Correct Aadhar number..");
                    Console.WriteLine("-------------------------------------------");

                }

            }


            n = 0;
            //-- User password
            while (n != 1)
            {
                try
                {


                    Console.WriteLine("Enter your 10 charcter Password");
                    M_Password = Console.ReadLine();

                    M_Password = M_Password.Trim();

                    n = 1;
                    PasswordString = M_Password.ToString();
                    if (PasswordString.Length == 10)
                    {
                        n = 1;
                    }
                    else
                    {
                        Console.WriteLine("Please Re-Enter");
                        n = 0;
                    }
                }
                catch (FormatException fe)
                {
                    n = 0;

                    Console.WriteLine("please Re-Enter Password");
                    Console.WriteLine("-------------------------------------------");

                }

            }

            n = 0;
            //-- ckeck User Authentication
            while (n != 1)
            {
                SqlConnection con = new SqlConnection(Global.ConnectionString);

                try
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select * from Parent where Mother_Addhar_no={M_Addhar_no} AND M_Password={M_Password}";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        Console.Clear();
                        Global.Mother_adhar_no = M_Addhar_no;
                        Console.WriteLine("   WELCOME..!!   ");
                        Console.WriteLine("YOU ARE LOGIN NOW");
                        Console.WriteLine();


                        n = 1;
                        child_data chl = new child_data();

                        chl.ShowChildMenu();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Credential...!!!");
                        Console.ReadKey();
                        n = 0;
                        break;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    con.Close();
                }
                
                
            }

        }
    
    }
}
