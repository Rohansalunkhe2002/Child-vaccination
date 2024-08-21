using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Transactions;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.SqlClient;
using System.Data;
using CProject.child_Module;

namespace CProject
{
    internal class parent
    {
        long M_Addhar_no,M_contact;
        string M_Fname, M_Mname, M_Lname;
        string M_Password,M_city,M_tehsil,M_district,M_state;
        string AadharString, ContactString,PasswordString;

        public void M_GetInfo()
            
        {
           

            //------------User Signup form
            int n = 0;

            //---aadhar number

            while (n != 1)
            {
                try
                {
                    
                    Console.WriteLine("Enter the 12 digit Mother Aadhaar number (this is also a user id)");
                    M_Addhar_no = long.Parse(Console.ReadLine());
                
                    AadharString = M_Addhar_no.ToString();
                    AadharString= AadharString.Trim();  
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
                    Console.WriteLine("Your choice :  1");
                    Console.WriteLine("please Enter Correct Aadhar number..");
                    Console.WriteLine("-------------------------------------------");

                }

            }


            n = 0;
            //--Contact number
            while (n != 1)
            {
                try
                {
                    

                    Console.WriteLine("Enter the Mother Contact number");
                    M_contact = long.Parse(Console.ReadLine());
                    ContactString = M_contact.ToString();
                    ContactString= ContactString.Trim();
                    if (ContactString.Length == 10)
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
                    
                    Console.WriteLine("please Enter Correct Contact number");
                    Console.WriteLine("-------------------------------------------");

                }

            }
            //--Mother first name
            n = 0;
            
            while (n != 1)
            {
                try
                {


                    Console.WriteLine("Enter the Mother First Name");
                    M_Fname = Console.ReadLine();
                    M_Fname = M_Fname.Trim();
                    n =ValidateMyString(M_Fname);


                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.WriteLine("please Enter Correct Mother First name");
                    Console.WriteLine("-------------------------------------------");

                }

            }


            //--Mother Middle name
            n = 0;

            while (n != 1)
            {
                try
                {

                    Console.WriteLine("Enter the Mother Middle Name");
                    M_Mname = Console.ReadLine();
                    M_Mname = M_Mname.Trim();
                    n = ValidateMyString(M_Mname);

                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.WriteLine("please Enter Correct Mother Middle name");
                    Console.WriteLine("-------------------------------------------");

                }

            }


            //--Mother Last name
            n = 0;

            while (n != 1)
            {
                try
                {

                    Console.WriteLine("Enter the Mother Last Name");
                    M_Lname = Console.ReadLine();
                    M_Lname = M_Lname.Trim();
                    n = ValidateMyString(M_Lname);
  
                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.WriteLine("please Enter Correct Mother Last name");
                    Console.WriteLine("-------------------------------------------");

                }

            }

            n = 0;
            //-- User password
            while (n != 1)
            {
                try
                {


                    Console.WriteLine("Enter the 10 charcter Password");
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

            //--City name
            n = 0;

            while (n != 1)
            {
                try
                {
                    Console.WriteLine("Enter the City name");
                    M_city = Console.ReadLine();
                    M_city = M_city.Trim();
                    n = ValidateMyString(M_Fname);
                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.WriteLine("please Enter Correct City name");
                    Console.WriteLine("-------------------------------------------");

                }

            }

            //--Tehsil name
            n = 0;

            while (n != 1)
            {
                try
                {

                    Console.WriteLine("Enter the Tehsil name");
                    M_tehsil = Console.ReadLine();
                    M_tehsil = M_tehsil.Trim();
                    n = ValidateMyString(M_Fname);
                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.WriteLine("please Enter Correct Mother First name");
                    Console.WriteLine("-------------------------------------------");

                }

            }


            //--district name
            n = 0;

            while (n != 1)
            {
                try
                {

                    Console.WriteLine("Enter the District name");
                    M_district = Console.ReadLine();
                    M_district = M_district.Trim();
                    n = ValidateMyString(M_Fname);
                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.WriteLine("please Enter Correct District  name");
                    Console.WriteLine("-------------------------------------------");

                }

            }


            //-- State name
            n = 0;

            while (n != 1)
            {
                try
                {

                    Console.WriteLine("Enter the state name");
                    M_state = Console.ReadLine();
                    M_state = M_state.Trim();
                    n = ValidateMyString(M_Fname);
                    
                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.WriteLine("please Enter Correct District  name");
                    Console.WriteLine("-------------------------------------------");

                }

            }

            //--Check digit or symbol in string
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

            SqlConnection con = new SqlConnection(Global.ConnectionString);

            try
            {
                //--SQL Connection for Registration




                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = "insert into Parent(Mother_Addhar_no,mother_Fname,mother_Mname,mother_Lname,M_Password ,Contact ,City ,tehsil,district,[state] ) " +
                    "values(" + M_Addhar_no + ",'" + M_Fname + "','" + M_Mname + "','" + M_Lname + "','" + M_Password + "'," + M_contact + ",'" + M_city + "','" + M_tehsil + "','" + M_district + "','" + M_state + "')";
                cmd.CommandType = CommandType.Text;
                con.Open();
                int ins = cmd.ExecuteNonQuery();

                if (ins > 0)
                {
                    Console.WriteLine("record inserted successully");
                }
                else
                {
                    Console.WriteLine("record not inserted!!!");
                }

            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                Console.WriteLine("This Aadhar number is already used please take another dhar");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
            
            finally
            {
                con.Close();

            }
            
            
        }
        public void M_show()
        {
            Console.Clear();
            Console.Write("|"); Console.WriteLine("-----------------------------------------------------|"); 
            Console.Write("|"); Console.WriteLine(" Aadhaar number       : "+M_Addhar_no +"             "); 
            Console.Write("|"); Console.WriteLine(" Contact              : " + M_contact+"              "); 
            Console.Write("|"); Console.WriteLine(" Mother First name    : "+ M_Fname + "               "); 
            Console.Write("|"); Console.WriteLine(" Mother Middel name   : " + M_Mname + "              "); 
            Console.Write("|"); Console.WriteLine(" Mother Last name     : " + M_Lname + "              "); 
            Console.Write("|"); Console.WriteLine(" Mother city name     : " + M_city + "               "); 
            Console.Write("|"); Console.WriteLine(" Mother tehsil name   : " + M_tehsil + "             ");
            Console.Write("|"); Console.WriteLine(" Mother district name : " + M_district + "           "); 
            Console.Write("|"); Console.WriteLine(" Mother state name    : " + M_state + "              "); 
            Console.Write("|"); Console.WriteLine("-----------------------------------------------------|");
            Console.ReadKey();
            Console.WriteLine(" check all info you inserted and Press Any key to continue");
        }



    }
}
