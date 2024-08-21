using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CProject.Admin_module;

namespace CProject.Aashawork_Module
{
    internal class RegisterAshawork
    {
        long A_Addhar_no, A_contact;
        string A_Fname, A_Mname, A_Lname;
        int n;

        string CEC_number;
        string A_Password, A_city, A_tehsil, A_district, A_state;
        string A_AadharString,A_ContactString, A_PasswordString;

        public void A_GetInfo()

        {
            
            int IsDelete = 1;
            Console.WriteLine("Enter Hospital Clinical Establishments ncertificate number to Register");
            CEC_number = Console.ReadLine();

            Console.WriteLine();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = $"select * from Hospital where CEC_number='{CEC_number}' and IsDelete !={IsDelete}";
            cmd.CommandType = CommandType.Text;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                Console.Clear();
                Console.WriteLine("   WELCOME Ashaworkr..!!   ");
                Console.WriteLine(" Register Form");
                Hospital_CEC.CEC_Number = CEC_number;
                Register_Asha();
                Console.WriteLine();
                n = 1;
            }
            else
            {
                Console.WriteLine("Invalid CEC number And Hsopital!!!");
                Console.ReadKey();
                n = 0;
            }
            con.Close();
        }


        //--Register Ashaworkr function
        private void Register_Asha()
        {
            //------------Aashawork Signup form
            int n = 0;

            //---Aashaworker aadhar number

            while (n != 1)
            {
                try
                {

                    Console.WriteLine("Enter the 12 digit Aashaworker Aadhaar number (this is also a user id)");
                    A_Addhar_no = long.Parse(Console.ReadLine());

                    A_AadharString = A_Addhar_no.ToString();
                    A_AadharString = A_AadharString.Trim();
                    if (A_AadharString.Length == 12)
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
            //--Aashaworkr Contact number
            while (n != 1)
            {
                try
                {


                    Console.WriteLine("Enter the Aashaworker Contact number");
                    A_contact = long.Parse(Console.ReadLine());
                    A_ContactString = A_contact.ToString();
                    A_ContactString = A_ContactString.Trim();
                    if (A_ContactString.Length == 10)
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
            //--Aashawrokr first name
            n = 0;

            while (n != 1)
            {
                try
                {


                    Console.WriteLine("Enter the Aashaworker First Name");
                    A_Fname = Console.ReadLine();
                    A_Fname = A_Fname.Trim();
                    n = ValidateMyString(A_Fname);


                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.WriteLine("please Enter Correct Mother First name");
                    Console.WriteLine("-------------------------------------------");

                }

            }


            //--Aashawrokr Middle name
            n = 0;

            while (n != 1)
            {
                try
                {

                    Console.WriteLine("Enter the Aashaworker Middle Name");
                    A_Mname = Console.ReadLine();
                    A_Mname = A_Mname.Trim();
                    n = ValidateMyString(A_Mname);

                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.WriteLine("please Enter Correct Mother Middle name");
                    Console.WriteLine("-------------------------------------------");

                }

            }


            //--Aashawrokr Last name
            n = 0;

            while (n != 1)
            {
                try
                {

                    Console.WriteLine("Enter the Aashaworker Last Name");
                    A_Lname = Console.ReadLine();
                    A_Lname = A_Lname.Trim();
                    n = ValidateMyString(A_Lname);

                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.WriteLine("please Enter Correct Mother Last name");
                    Console.WriteLine("-------------------------------------------");

                }

            }

            n = 0;
            //-- Aashaworker password
            while (n != 1)
            {
                try
                {


                    Console.WriteLine("Enter the 10 charcter Password");
                    A_Password = Console.ReadLine();

                    A_Password = A_Password.Trim();

                    n = 1;
                    A_PasswordString = A_Password.ToString();
                    if (A_PasswordString.Length == 10)
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

            //-- Aashawrokr City name
            n = 0;

            while (n != 1)
            {
                try
                {
                    Console.WriteLine("Enter the City name");
                    A_city = Console.ReadLine();
                    A_city = A_city.Trim();
                    n = ValidateMyString(A_Fname);
                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.WriteLine("please Enter Correct City name");
                    Console.WriteLine("-------------------------------------------");

                }

            }

            //--Aashawrokr Tehsil name
            n = 0;

            while (n != 1)
            {
                try
                {

                    Console.WriteLine("Enter the Tehsil name");
                    A_tehsil = Console.ReadLine();
                    A_tehsil = A_tehsil.Trim();
                    n = ValidateMyString(A_Fname);
                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.WriteLine("please Enter Correct Mother First name");
                    Console.WriteLine("-------------------------------------------");

                }

            }


            //-- Aashawrokr district name
            n = 0;

            while (n != 1)
            {
                try
                {

                    Console.WriteLine("Enter the District name");
                    A_district = Console.ReadLine();
                    A_district = A_district.Trim();
                    n = ValidateMyString(A_Fname);
                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.WriteLine("please Enter Correct District  name");
                    Console.WriteLine("-------------------------------------------");

                }

            }


            //-- Aashawrokr State name
            n = 0;

            while (n != 1)
            {
                try
                {

                    Console.WriteLine("Enter the state name");
                    A_state = Console.ReadLine();
                    A_state = A_state.Trim();
                    n = ValidateMyString(A_Fname);

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

            //--SQL Connection for Registration

            SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");



            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = $"insert into Aashaworkr(Aashaworkr_Addhar_no, CEC_number, Aashaworkr_Fname, Aashaworkr_Mname,Aashaworkr_Lname, Aashaworkr_Password, Aashaworkr_Contact, Aashaworkr_City, Aashaworkr_tehsil,Aashaworkr_district, Aashaworkr_state)values('{A_Addhar_no}', '{Hospital_CEC.CEC_Number}', '{A_Fname}', '{A_Mname}', '{A_Mname}', '{A_Password}', '{A_contact}', '{A_city}', '{A_tehsil}', '{A_district}', '{A_state}')";
            cmd.CommandType = CommandType.Text;
            con.Open();
            int ins = cmd.ExecuteNonQuery();

            if (ins > 0)
            {
                Console.WriteLine();
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Aashaworkr Register Successully ");
                GlobalAasha.AashaAadhar_number = A_Addhar_no;
                LoginAashwork AsPro=new LoginAashwork();
                AsPro.AashProfile();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Aashaworker Not  Register!!!");
            }

            con.Close();

        }

    }
}
