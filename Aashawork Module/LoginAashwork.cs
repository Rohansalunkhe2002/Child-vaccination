using CProject.child_Module;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using CProject.Admin_module;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Runtime.InteropServices;

namespace CProject.Aashawork_Module
{
    
    internal class LoginAashwork
    {
        long A_Addhar_no;
        string A_Password;
        string A_AadharString, A_PasswordString, AadharString;
        int ChildFnumbar;
        int ch;
        int n = 0;
        long M_Addhar_no;
        bool IsDelete=true;
        long tmpAshaAdhar;
        string tempCEC_Number;
        bool next = true;
        int number;

        Int32 Cse;


        //check Aashaworkr Validation

        public void Checkinfo()
        {
            //Aashaworkr Aadhar number
            n = 0;
            while (n != 1)
            {
                try
                {

                    Console.WriteLine("Enter the 12 digit Aashaworker Aadhaar number (User id)");
                    A_Addhar_no = long.Parse(Console.ReadLine());
                    A_AadharString = A_Addhar_no.ToString();
                    A_AadharString = A_AadharString.Trim();
                    if (A_AadharString.Length == 12)
                    {
                        n = 1;

                    }
                    else
                    {
                        Console.WriteLine("Please Re-Enter 12 digit Aadhar number");
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
            //-- Aashaworker User password
            while (n != 1)
            {
                try
                {


                    Console.WriteLine("Enter your 10 charcter Password");
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
                        Console.WriteLine("Please Re-Enter Password");
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


            Console.WriteLine();
            SqlConnection con = new SqlConnection(Global.ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select CEC_number from Aashaworkr where Aashaworkr_Addhar_no='{A_Addhar_no}' AND Aashaworkr_Password='{A_Password}'";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    GlobalAasha.AashaAadhar_number = A_Addhar_no;

                    while (rdr.Read() && n == 1)
                    {
                        Hospital_CEC.CEC_Number = rdr["CEC_number"].ToString();
                        n = 1;
                    }
                }
                else
                {
                    Console.WriteLine("cant find CEC Number of Hospital");

                    n = 0;

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
           
            
            CheckHospital(Hospital_CEC.CEC_Number);

        }

        //Check Hospital is delete or not
        public void CheckHospital(string cec_number)
        {
            Console.WriteLine();
            SqlConnection con = new SqlConnection(Global.ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select IsDelete from Hospital where CEC_number='{cec_number}'";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {


                    while (rdr.Read())
                    {
                        Cse = Convert.ToInt32(rdr["IsDelete"]);
                    }
                    if (Cse != 1)
                    {
                        AashProfile();
                    }
                    else
                    {
                        Console.WriteLine("Your hospital is Deleted please contact to Admin");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("cant find CEC Number of Hospital");
                    Console.ReadKey();

                    n = 0;

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

        //Aashaworker  Profile 
        public void AashProfile()
        {
            Console.Clear();
            Console.WriteLine("    Aashaworkr Profile    ");
            Console.WriteLine("---------------------------");


            
            SqlConnection con = new SqlConnection(Global.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select Hospital_name from Hospital where CEC_number='{Hospital_CEC.CEC_Number}'";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader ins = cmd.ExecuteReader();

                if (ins.HasRows)
                {
                    while (ins.Read())
                    {
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine("Your Hospital Name : " + ins["Hospital_name"]);
                        Console.WriteLine("----------------------------------------------------------");
                        Console.WriteLine("Press any key to Continue");
                        Console.ReadKey();
                    }
                    con.Close();
                }
                else
                {
                    Console.WriteLine("Error in Getting name of your hospital ");
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
            bool f = true;
            do
            {
                Console.Clear();
                Console.WriteLine("           MENU            ");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("1.Child Info And Vaccination Status   ");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("2.Update Vaccination status ");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("3.Check Your hospital Vaccination count ");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("4.Exit");
                Console.WriteLine("---------------------------------------");

                try
                {
                    Console.WriteLine("Enter choice :");
                    ch = int.Parse(Console.ReadLine());

                }
                catch (FormatException fe)
                {
                    Console.WriteLine("please Enter Correct choice...");
                }
                catch (OverflowException o)
                {
                    Console.WriteLine("please Enter Correct choice...");
                }
                switch (ch)
                {

                    case 1:

                        Console.Clear();
                        Console.WriteLine("Your choice :" + ch);
                        Console.WriteLine("      Child  Info         ");
                        Console.WriteLine("----------------------------------------------");
                        CheckvalidChild();

                        break;

                    case 2:

                        Console.Clear();
                        Console.WriteLine("Your choice :" + ch);
                        Console.WriteLine("       Update Child vaccination status        ");
                        Console.WriteLine("----------------------------------------------");
                        CheckvalidChild();



                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Your choice :" + ch);
                        Console.WriteLine("        vaccination count        ");
                        Console.WriteLine("----------------------------------------------");
                        HospialVaccination();


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

        // Child Info
        public void ChildInfo(long M_Aaddhar, int Clnumber,int flag)
        {
            SqlConnection con = new SqlConnection(Global.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = $"select Mother_Addhar_no,Child_Fname,child_Mname,child_Lname,Gender,DOB,child_number from child where Mother_Addhar_no={Global.Mother_adhar_no} AND child_number={Clnumber}";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    Console.Clear();
                    Console.WriteLine("Child Found");
                    while (rdr.Read())
                    {
                        Console.WriteLine("Mother Aadhar Number :" + rdr["Mother_Addhar_no"]);
                        Console.WriteLine("Child Name :" + rdr["Child_Fname"] + " " + rdr["child_Mname"] + " " + rdr["child_Lname"]);
                        Console.WriteLine("Gender :" + rdr["Gender"]);
                        Console.WriteLine("Date of Birth :" + rdr["DOB"]);
                        Console.WriteLine("Child Number :" + rdr["child_number"]);
                    }


                    Console.WriteLine("Press any key to Continue");
                    Console.ReadKey();

                    if (ch == 2 && flag == 1)//only asha warker
                    {
                        UpdateVaccination(Global.Mother_adhar_no, Global.child_number);
                    }
                    else // both
                    {
                        CheckVaccinationStatus(Global.Mother_adhar_no, Clnumber);

                    }
                }
                else
                {
                    Console.WriteLine("Someting Went Wrong");
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
            
            
        }

        //Check Vaccination 1 status


        public void CheckVaccinationStatus(long M_Aaddhar, int ChildFnumber)
        {
            
            n = 0;
            while (n != 1)
            {
                int z = 0;
                if (z == 0)
                {
                    
                    SqlConnection con = new SqlConnection(Global.ConnectionString);
                    try
                    {
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = con;
                        cmd.CommandText = $"select Vaccine_number,Vaccine_Name,Vaccination_date,Aashaworkr_Addhar_no from Vaccine1 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                        //cmd.CommandText = $"select Mother_Addhar_no,Child_Fname,child_Mname,child_Lname,Gender,DOB,child_number from child where Mother_Addhar_no={M_Addhar_no} AND child_number={ChildFnumber}";
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();

                        if (rdr.HasRows)
                        {
                            Console.Clear();
                            Console.WriteLine("         Vaccine 1  Complete   ");
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine();
                            while (rdr.Read())
                            {
                                Console.WriteLine("Vaccine Number             : " + rdr["Vaccine_number"]);
                                Console.WriteLine("Vaccine Name               : " + rdr["Vaccine_Name"]);
                                Console.WriteLine("Vaccination Date And time  : " + rdr["Vaccination_date"]);
                                //Console.WriteLine("Child Number :" + rdr["child_number"]);
                                if (rdr != null)
                                {
                                    try
                                    {
                                        tmpAshaAdhar = Convert.ToInt64(rdr["Aashaworkr_Addhar_no"]);
                                        n = 1;

                                    }
                                    catch (FormatException ex)
                                    {

                                        Console.WriteLine("Conversion failed: " + ex.Message);
                                    }
                                    catch (OverflowException ex)
                                    {

                                        Console.WriteLine("Conversion failed: " + ex.Message);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine();
                            Console.WriteLine("Vaccine 1 Not Complete");
                            Console.WriteLine();
                            Console.WriteLine("--------------------------------");
                            next = false;
                            Console.ReadKey();
                            n = 1;
                            break;
                        }

                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);

                    }
                    finally
                    {
                        con.Close();
                    } 
                    z++;
                }

                if (z == 1)
                {
                    SqlConnection con = new SqlConnection(Global.ConnectionString);
                    try
                    {
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = con;
                        cmd.CommandText = $"select Aashaworkr_Fname,Aashaworkr_Mname,Aashaworkr_Lname,Aashaworkr_Contact,CEC_number from Aashaworkr where Aashaworkr_Addhar_no='{tmpAshaAdhar}' ";
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();

                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                Console.WriteLine("Vaccine Given by             : " + rdr["Aashaworkr_Fname"] + " " + rdr["Aashaworkr_Mname"] + " " + rdr["Aashaworkr_Lname"]);
                                Console.WriteLine("Aashaworker Contact          : " + rdr["Aashaworkr_Contact"]);
                                if (rdr != null)
                                {
                                    try
                                    {
                                        tempCEC_Number = Convert.ToString(rdr["CEC_number"]);

                                    }
                                    catch (FormatException ex)
                                    {

                                        Console.WriteLine("Conversion failed: " + ex.Message);
                                    }
                                    catch (OverflowException ex)
                                    {

                                        Console.WriteLine("Conversion failed: " + ex.Message);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (n != 0)
                            {
                                Console.WriteLine("Someting Went Wrong to fetch data");
                            }

                        }

                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    finally
                    {
                        con.Close();
                    }
                    z++;
                }
                if (z == 2)
                {
                    SqlConnection con = new SqlConnection(Global.ConnectionString);
                    try
                    {
                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = con;
                        cmd.CommandText = $"select Hospital_name from Hospital where CEC_number='{tempCEC_Number}'";
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();

                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                Console.WriteLine("Hosptital Name           : " + rdr["Hospital_name"]);

                            }
                        }
                        else
                        {
                            if (n != 0)
                            {
                                Console.WriteLine("Someting Went Wrong to fetch data");
                            }
                        }

                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    finally
                    {
                        con.Close();
                    }
                    
                    
                    
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------");

                }

            }

            if (next ==true)
            {
                CheckVaccinationStatus2( M_Aaddhar, ChildFnumber);
            }
        }


        //Check Vacccination 2 Status

        public void CheckVaccinationStatus2(long M_Aaddhar, int ChildFnumber)
        {

            n = 0;
            while (n != 1)
            {
                int z = 0;
                if (z == 0)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Vaccine_number,Vaccine_Name,Vaccination_date,Aashaworkr_Addhar_no from Vaccine2 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        
                        Console.WriteLine("         Vaccine 2  Complete   ");
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine();
                        while (rdr.Read())
                        {
                            Console.WriteLine("Vaccine Number             : " + rdr["Vaccine_number"]);
                            Console.WriteLine("Vaccine Name               : " + rdr["Vaccine_Name"]);
                            Console.WriteLine("Vaccination Date And time  : " + rdr["Vaccination_date"]);
                            //Console.WriteLine("Child Number :" + rdr["child_number"]);
                            if (rdr != null)
                            {
                                try
                                {
                                    tmpAshaAdhar = Convert.ToInt64(rdr["Aashaworkr_Addhar_no"]);
                                    n = 1;

                                }
                                catch (FormatException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                                catch (OverflowException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Vaccine 2 Not Complete");
                        Console.WriteLine();
                        Console.WriteLine("--------------------------------");
                        SqlConnection con1 = new SqlConnection(Global.ConnectionString);
                        SqlCommand cmd1 = new SqlCommand();

                        cmd1.Connection = con1;
                        cmd1.CommandText = $"select TVaccination_date from Vaccine1 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                        cmd1.CommandType = CommandType.Text;
                        con1.Open();
                        SqlDataReader rdr1 = cmd1.ExecuteReader();

                        if (rdr1.HasRows)
                        {
                            while (rdr1.Read())
                            {
                                Console.WriteLine("Next vaccination date :" + rdr1[0]);

                            }

                        }
                        else
                        {
                            Console.WriteLine("Not found");
                        }
                        next = false;
                        Console.ReadKey();
                        n = 1;
                        break;
                    }
                    con.Close();
                    z++;
                }

                if (z == 1)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Aashaworkr_Fname,Aashaworkr_Mname,Aashaworkr_Lname,Aashaworkr_Contact,CEC_number from Aashaworkr where Aashaworkr_Addhar_no='{tmpAshaAdhar}' ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("Vaccine Given by             : " + rdr["Aashaworkr_Fname"] + " " + rdr["Aashaworkr_Mname"] + " " + rdr["Aashaworkr_Lname"]);
                            Console.WriteLine("Aashaworker Contact          : " + rdr["Aashaworkr_Contact"]);
                            if (rdr != null)
                            {
                                try
                                {
                                    tempCEC_Number = Convert.ToString(rdr["CEC_number"]);

                                }
                                catch (FormatException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                                catch (OverflowException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (n != 0)
                        {
                            Console.WriteLine("Someting Went Wrong to fetch data");
                        }

                    }
                    con.Close();
                    z++;

                }
                if (z == 2)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Hospital_name from Hospital where CEC_number='{tempCEC_Number}'";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("Hosptital Name           : " + rdr["Hospital_name"]);

                        }
                    }
                    else
                    {
                        if (n != 0)
                        {
                            Console.WriteLine("Someting Went Wrong to fetch data");
                        }
                    }
                    con.Close();
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------");

                }

            }

            if (next == true)
            {
                CheckVaccinationStatus3(M_Aaddhar, ChildFnumber);

            }
            

        }

        //Check Vacccination 3 Status

        public void CheckVaccinationStatus3(long M_Aaddhar, int ChildFnumber)
        {

            n = 0;
            while (n != 1)
            {
                int z = 0;
                if (z == 0)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Vaccine_number,Vaccine_Name,Vaccination_date,Aashaworkr_Addhar_no from Vaccine3 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {

                        Console.WriteLine("         Vaccine 3  Complete   ");
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine();
                        while (rdr.Read())
                        {
                            Console.WriteLine("Vaccine Number             : " + rdr["Vaccine_number"]);
                            Console.WriteLine("Vaccine Name               : " + rdr["Vaccine_Name"]);
                            Console.WriteLine("Vaccination Date And time  : " + rdr["Vaccination_date"]);
                            //Console.WriteLine("Child Number :" + rdr["child_number"]);
                            if (rdr != null)
                            {
                                try
                                {
                                    tmpAshaAdhar = Convert.ToInt64(rdr["Aashaworkr_Addhar_no"]);
                                    n = 1;

                                }
                                catch (FormatException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                                catch (OverflowException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Vaccine 3 Not Complete");
                        Console.WriteLine();
                        Console.WriteLine("--------------------------------");
                        SqlConnection con1 = new SqlConnection(Global.ConnectionString);
                        SqlCommand cmd1 = new SqlCommand();

                        cmd1.Connection = con1;
                        cmd1.CommandText = $"select TVaccination_date from Vaccine2 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                        cmd1.CommandType = CommandType.Text;
                        con1.Open();
                        SqlDataReader rdr1 = cmd1.ExecuteReader();

                        if (rdr1.HasRows)
                        {
                            while (rdr1.Read())
                            {
                                Console.WriteLine("Next vaccination date :" + rdr1[0]);

                            }

                        }
                        else
                        {
                            Console.WriteLine("Not found");
                        }
                        next = false;
                        Console.ReadKey();
                        n = 1;
                        break;
                    }
                    con.Close();
                    z++;
                }

                if (z == 1)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Aashaworkr_Fname,Aashaworkr_Mname,Aashaworkr_Lname,Aashaworkr_Contact,CEC_number from Aashaworkr where Aashaworkr_Addhar_no='{tmpAshaAdhar}' ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("Vaccine Given by             : " + rdr["Aashaworkr_Fname"] + " " + rdr["Aashaworkr_Mname"] + " " + rdr["Aashaworkr_Lname"]);
                            Console.WriteLine("Aashaworker Contact          : " + rdr["Aashaworkr_Contact"]);
                            if (rdr != null)
                            {
                                try
                                {
                                    tempCEC_Number = Convert.ToString(rdr["CEC_number"]);

                                }
                                catch (FormatException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                                catch (OverflowException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (n != 0)
                        {
                            Console.WriteLine("Someting Went Wrong to fetch data");
                        }

                    }
                    con.Close();
                    z++;

                }
                if (z == 2)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Hospital_name from Hospital where CEC_number='{tempCEC_Number}'";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("Hosptital Name           : " + rdr["Hospital_name"]);

                        }
                    }
                    else
                    {
                        if (n != 0)
                        {
                            Console.WriteLine("Someting Went Wrong to fetch data");
                        }
                    }
                    con.Close();
                    
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------");

                }

            }

            if (next == true)
            {
                
                CheckVaccinationStatus4(M_Aaddhar, ChildFnumber);
            }


        }


        //--Check Vaccination 4 Status
        public void CheckVaccinationStatus4(long M_Aaddhar, int ChildFnumber)
        {

            n = 0;
            while (n != 1)
            {
                int z = 0;
                if (z == 0)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Vaccine_number,Vaccine_Name,Vaccination_date,Aashaworkr_Addhar_no from Vaccine4 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {

                        Console.WriteLine("         Vaccine 4  Complete   ");
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine();
                        while (rdr.Read())
                        {
                            Console.WriteLine("Vaccine Number             : " + rdr["Vaccine_number"]);
                            Console.WriteLine("Vaccine Name               : " + rdr["Vaccine_Name"]);
                            Console.WriteLine("Vaccination Date And time  : " + rdr["Vaccination_date"]);
                            //Console.WriteLine("Child Number :" + rdr["child_number"]);
                            if (rdr != null)
                            {
                                try
                                {
                                    tmpAshaAdhar = Convert.ToInt64(rdr["Aashaworkr_Addhar_no"]);
                                    n = 1;

                                }
                                catch (FormatException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                                catch (OverflowException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Vaccine 4 Not Complete");
                        Console.WriteLine();
                        Console.WriteLine("--------------------------------");
                        SqlConnection con1 = new SqlConnection(Global.ConnectionString);
                        SqlCommand cmd1 = new SqlCommand();

                        cmd1.Connection = con1;
                        cmd1.CommandText = $"select TVaccination_date from Vaccine3 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                        cmd1.CommandType = CommandType.Text;
                        con1.Open();
                        SqlDataReader rdr1 = cmd1.ExecuteReader();

                        if (rdr1.HasRows)
                        {
                            while (rdr1.Read())
                            {
                                Console.WriteLine("Next vaccination date :" + rdr1[0]);

                            }

                        }
                        else
                        {
                            Console.WriteLine("Not found");
                        }
                        next = false;
                        Console.ReadKey();
                        n = 1;
                        break;
                    }
                    con.Close();
                    z++;
                }

                if (z == 1)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Aashaworkr_Fname,Aashaworkr_Mname,Aashaworkr_Lname,Aashaworkr_Contact,CEC_number from Aashaworkr where Aashaworkr_Addhar_no='{tmpAshaAdhar}' ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("Vaccine Given by             : " + rdr["Aashaworkr_Fname"] + " " + rdr["Aashaworkr_Mname"] + " " + rdr["Aashaworkr_Lname"]);
                            Console.WriteLine("Aashaworker Contact          : " + rdr["Aashaworkr_Contact"]);
                            if (rdr != null)
                            {
                                try
                                {
                                    tempCEC_Number = Convert.ToString(rdr["CEC_number"]);

                                }
                                catch (FormatException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                                catch (OverflowException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (n != 0)
                        {
                            Console.WriteLine("Someting Went Wrong to fetch data");
                        }

                    }
                    con.Close();
                    z++;

                }
                if (z == 2)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Hospital_name from Hospital where CEC_number='{tempCEC_Number}'";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("Hosptital Name           : " + rdr["Hospital_name"]);

                        }
                    }
                    else
                    {
                        if (n != 0)
                        {
                            Console.WriteLine("Someting Went Wrong to fetch data");
                        }
                    }
                    con.Close();
                    
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------");

                }

            }

            if (next == true)
            {
                CheckVaccinationStatus5(M_Aaddhar, ChildFnumber);

            }


        }


        //--Check Vaccination 5 Status
        public void CheckVaccinationStatus5(long M_Aaddhar, int ChildFnumber)
        {

            n = 0;
            while (n != 1)
            {
                int z = 0;
                if (z == 0)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Vaccine_number,Vaccine_Name,Vaccination_date,Aashaworkr_Addhar_no from Vaccine5 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {

                        Console.WriteLine("         Vaccine 5  Complete   ");
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine();
                        while (rdr.Read())
                        {
                            Console.WriteLine("Vaccine Number             : " + rdr["Vaccine_number"]);
                            Console.WriteLine("Vaccine Name               : " + rdr["Vaccine_Name"]);
                            Console.WriteLine("Vaccination Date And time  : " + rdr["Vaccination_date"]);
                            //Console.WriteLine("Child Number :" + rdr["child_number"]);
                            if (rdr != null)
                            {
                                try
                                {
                                    tmpAshaAdhar = Convert.ToInt64(rdr["Aashaworkr_Addhar_no"]);
                                    n = 1;

                                }
                                catch (FormatException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                                catch (OverflowException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                            }
                        }
                        z++;
                    }
                    else
                    {
                        con.Close();
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Vaccine 5 Not Complete");
                        Console.WriteLine();
                        Console.WriteLine("--------------------------------");
                        SqlConnection con1 = new SqlConnection(Global.ConnectionString);
                        SqlCommand cmd1 = new SqlCommand();

                        cmd1.Connection = con1;
                        cmd1.CommandText = $"select TVaccination_date from Vaccine4 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                        cmd1.CommandType = CommandType.Text;
                        con1.Open();
                        SqlDataReader rdr1 = cmd1.ExecuteReader();

                        if (rdr1.HasRows)
                        {
                            while (rdr1.Read())
                            {
                                Console.WriteLine("Next vaccination date :"+rdr1[0]);
                                
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Not found");
                        }
                        next = false;
                        Console.ReadKey();
                        n = 1;
                        break;
                    }
                    con.Close();
                    
                }

                if (z == 1)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Aashaworkr_Fname,Aashaworkr_Mname,Aashaworkr_Lname,Aashaworkr_Contact,CEC_number from Aashaworkr where Aashaworkr_Addhar_no='{tmpAshaAdhar}' ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("Vaccine Given by             : " + rdr["Aashaworkr_Fname"] + " " + rdr["Aashaworkr_Mname"] + " " + rdr["Aashaworkr_Lname"]);
                            Console.WriteLine("Aashaworker Contact          : " + rdr["Aashaworkr_Contact"]);
                            if (rdr != null)
                            {
                                try
                                {
                                    tempCEC_Number = Convert.ToString(rdr["CEC_number"]);

                                }
                                catch (FormatException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                                catch (OverflowException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (n != 0)
                        {
                            Console.WriteLine("Someting Went Wrong to fetch data");
                        }

                    }
                    con.Close();
                    z++;

                }
                if (z == 2)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Hospital_name from Hospital where CEC_number='{tempCEC_Number}'";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("Hosptital Name           : " + rdr["Hospital_name"]);

                        }
                    }
                    else
                    {
                        if (n != 0)
                        {
                            Console.WriteLine("Someting Went Wrong to fetch data");
                        }
                    }
                    con.Close();
                    
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------");

                }

            }

            if (next == true)
            {
                CheckVaccinationStatus6(M_Aaddhar, ChildFnumber);

            }


        }


        //--Check Vaccination 6 Status
        public void CheckVaccinationStatus6(long M_Aaddhar, int ChildFnumber)
        {

            n = 0;
            while (n != 1)
            {
                int z = 0;
                if (z == 0)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Vaccine_number,Vaccine_Name,Vaccination_date,Aashaworkr_Addhar_no from Vaccine6 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {

                        Console.WriteLine("         Vaccine 6  Complete   ");
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine();
                        while (rdr.Read())
                        {
                            Console.WriteLine("Vaccine Number             : " + rdr["Vaccine_number"]);
                            Console.WriteLine("Vaccine Name               : " + rdr["Vaccine_Name"]);
                            Console.WriteLine("Vaccination Date And time  : " + rdr["Vaccination_date"]);
                            //Console.WriteLine("Child Number :" + rdr["child_number"]);
                            if (rdr != null)
                            {
                                try
                                {
                                    tmpAshaAdhar = Convert.ToInt64(rdr["Aashaworkr_Addhar_no"]);
                                    n = 1;

                                }
                                catch (FormatException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                                catch (OverflowException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Vaccine 6 Not Complete");
                        Console.WriteLine();
                        Console.WriteLine("--------------------------------");
                        SqlConnection con1 = new SqlConnection(Global.ConnectionString);
                        SqlCommand cmd1 = new SqlCommand();

                        cmd1.Connection = con1;
                        cmd1.CommandText = $"select TVaccination_date from Vaccine5 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                        cmd1.CommandType = CommandType.Text;
                        con1.Open();
                        SqlDataReader rdr1 = cmd1.ExecuteReader();

                        if (rdr1.HasRows)
                        {
                            while (rdr1.Read())
                            {
                                Console.WriteLine("Next vaccination date :" + rdr1[0]);

                            }

                        }
                        else
                        {
                            Console.WriteLine("Not found");
                        }
                        next = false;
                        Console.ReadKey();
                        n = 1;
                        break;
                    }
                    con.Close();
                    z++;
                }

                if (z == 1)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Aashaworkr_Fname,Aashaworkr_Mname,Aashaworkr_Lname,Aashaworkr_Contact,CEC_number from Aashaworkr where Aashaworkr_Addhar_no='{tmpAshaAdhar}' ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("Vaccine Given by             : " + rdr["Aashaworkr_Fname"] + " " + rdr["Aashaworkr_Mname"] + " " + rdr["Aashaworkr_Lname"]);
                            Console.WriteLine("Aashaworker Contact          : " + rdr["Aashaworkr_Contact"]);
                            if (rdr != null)
                            {
                                try
                                {
                                    tempCEC_Number = Convert.ToString(rdr["CEC_number"]);

                                }
                                catch (FormatException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                                catch (OverflowException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (n != 0)
                        {
                            Console.WriteLine("Someting Went Wrong to fetch data");
                        }

                    }
                    con.Close();
                    z++;

                }
                if (z == 2)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Hospital_name from Hospital where CEC_number='{tempCEC_Number}'";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("Hosptital Name           : " + rdr["Hospital_name"]);

                        }
                    }
                    else
                    {
                        if (n != 0)
                        {
                            Console.WriteLine("Someting Went Wrong to fetch data");
                        }
                    }
                    con.Close();
                    
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------");

                }

            }

            if (next == true)
            {

                CheckVaccinationStatus7(M_Aaddhar, ChildFnumber);
            }


        }


        //--Check Vaccination 7 Status

        public void CheckVaccinationStatus7(long M_Aaddhar, int ChildFnumber)
        {

            n = 0;
            while (n != 1)
            {
                int z = 0;
                if (z == 0)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Vaccine_number,Vaccine_Name,Vaccination_date,Aashaworkr_Addhar_no from Vaccine7 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        
                        Console.WriteLine("         Vaccine 7  Complete   ");
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine();
                        while (rdr.Read())
                        {
                            Console.WriteLine("Vaccine Number             : " + rdr["Vaccine_number"]);
                            Console.WriteLine("Vaccine Name               : " + rdr["Vaccine_Name"]);
                            Console.WriteLine("Vaccination Date And time  : " + rdr["Vaccination_date"]);
                            
                            //Console.WriteLine("Child Number :" + rdr["child_number"]);
                            if (rdr != null)
                            {
                                try
                                {
                                    tmpAshaAdhar = Convert.ToInt64(rdr["Aashaworkr_Addhar_no"]);
                                    n = 1;

                                }
                                catch (FormatException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                                catch (OverflowException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Vaccine 7 Not Complete");
                        Console.WriteLine();
                        Console.WriteLine("--------------------------------");
                        SqlConnection con1 = new SqlConnection(Global.ConnectionString);
                        SqlCommand cmd1 = new SqlCommand();

                        cmd1.Connection = con1;
                        cmd1.CommandText = $"select TVaccination_date from Vaccine6 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                        cmd1.CommandType = CommandType.Text;
                        con1.Open();
                        SqlDataReader rdr1 = cmd1.ExecuteReader();

                        if (rdr1.HasRows)
                        {
                            while (rdr1.Read())
                            {
                                Console.WriteLine("Next vaccination date :" + rdr1[0]);

                            }

                        }
                        else
                        {
                            Console.WriteLine("Not found");
                        }
                        next = false;
                        Console.ReadKey();
                        n = 1;
                        break;
                    }
                    con.Close();
                    z++;
                }

                if (z == 1)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Aashaworkr_Fname,Aashaworkr_Mname,Aashaworkr_Lname,Aashaworkr_Contact,CEC_number from Aashaworkr where Aashaworkr_Addhar_no='{tmpAshaAdhar}' ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("Vaccine Given by             : " + rdr["Aashaworkr_Fname"] + " " + rdr["Aashaworkr_Mname"] + " " + rdr["Aashaworkr_Lname"]);
                            Console.WriteLine("Aashaworker Contact          : " + rdr["Aashaworkr_Contact"]);
                            if (rdr != null)
                            {
                                try
                                {
                                    tempCEC_Number = Convert.ToString(rdr["CEC_number"]);

                                }
                                catch (FormatException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                                catch (OverflowException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (n != 0)
                        {
                            Console.WriteLine("Someting Went Wrong to fetch data");
                        }

                    }
                    con.Close();
                    z++;

                }
                if (z == 2)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Hospital_name from Hospital where CEC_number='{tempCEC_Number}'";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("Hosptital Name           : " + rdr["Hospital_name"]);

                        }
                    }
                    else
                    {
                        if (n != 0)
                        {
                            Console.WriteLine("Someting Went Wrong to fetch data");
                        }
                    }
                    con.Close();
                    
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------");
                    


                }

            }

            if (next == true)
            {

                CheckVaccinationStatus8(M_Aaddhar, ChildFnumber);
            }


        }


        //--Check Vaccination 8 status

        public void CheckVaccinationStatus8(long M_Aaddhar, int ChildFnumber)
        {

            n = 0;
            while (n != 1)
            {
                int z = 0;
                if (z == 0)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Vaccine_number,Vaccine_Name,Vaccination_date,Aashaworkr_Addhar_no from Vaccine8 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        
                        Console.WriteLine("         Vaccine 8  Complete   ");
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine();
                        while (rdr.Read())
                        {
                            Console.WriteLine("Vaccine Number             : " + rdr["Vaccine_number"]);
                            Console.WriteLine("Vaccine Name               : " + rdr["Vaccine_Name"]);
                            Console.WriteLine("Vaccination Date And time  : " + rdr["Vaccination_date"]);
                            //Console.WriteLine("Child Number :" + rdr["child_number"]);
                            if (rdr != null)
                            {
                                try
                                {
                                    tmpAshaAdhar = Convert.ToInt64(rdr["Aashaworkr_Addhar_no"]);
                                    n = 1;

                                }
                                catch (FormatException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                                catch (OverflowException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Vaccine 8 Not Complete");
                        Console.WriteLine();
                        Console.WriteLine("--------------------------------");
                        SqlConnection con1 = new SqlConnection(Global.ConnectionString);
                        SqlCommand cmd1 = new SqlCommand();

                        cmd1.Connection = con1;
                        cmd1.CommandText = $"select TVaccination_date from Vaccine4 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                        cmd1.CommandType = CommandType.Text;
                        con1.Open();
                        SqlDataReader rdr1 = cmd1.ExecuteReader();

                        if (rdr1.HasRows)
                        {
                            while (rdr1.Read())
                            {
                                Console.WriteLine("Next vaccination date :" + rdr1[0]);

                            }

                        }
                        else
                        {
                            Console.WriteLine("Not found");
                        }
                        next = false;
                        Console.ReadKey();
                        n = 1;
                        break;
                    }
                    con.Close();
                    z++;
                }

                if (z == 1)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Aashaworkr_Fname,Aashaworkr_Mname,Aashaworkr_Lname,Aashaworkr_Contact,CEC_number from Aashaworkr where Aashaworkr_Addhar_no='{tmpAshaAdhar}' ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("Vaccine Given by             : " + rdr["Aashaworkr_Fname"] + " " + rdr["Aashaworkr_Mname"] + " " + rdr["Aashaworkr_Lname"]);
                            Console.WriteLine("Aashaworker Contact          : " + rdr["Aashaworkr_Contact"]);
                            if (rdr != null)
                            {
                                try
                                {
                                    tempCEC_Number = Convert.ToString(rdr["CEC_number"]);

                                }
                                catch (FormatException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                                catch (OverflowException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (n != 0)
                        {
                            Console.WriteLine("Someting Went Wrong to fetch data");
                        }

                    }
                    con.Close();
                    z++;

                }
                if (z == 2)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Hospital_name from Hospital where CEC_number='{tempCEC_Number}'";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("Hosptital Name           : " + rdr["Hospital_name"]);

                        }
                    }
                    else
                    {
                        if (n != 0)
                        {
                            Console.WriteLine("Someting Went Wrong to fetch data");
                        }
                    }
                    con.Close();
                    
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------");

                }

            }

            if (next == true)
            {
                CheckVaccinationStatus9(M_Aaddhar, ChildFnumber);

            }


        }

        //--Check Vaccination 9 status
        public void CheckVaccinationStatus9(long M_Aaddhar, int ChildFnumber)
        {

            n = 0;
            while (n != 1)
            {
                int z = 0;
                if (z == 0)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Vaccine_number,Vaccine_Name,Vaccination_date,Aashaworkr_Addhar_no from Vaccine9 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        
                        Console.WriteLine("         Vaccine 9  Complete   ");
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine();
                        while (rdr.Read())
                        {
                            Console.WriteLine("Vaccine Number             : " + rdr["Vaccine_number"]);
                            Console.WriteLine("Vaccine Name               : " + rdr["Vaccine_Name"]);
                            Console.WriteLine("Vaccination Date And time  : " + rdr["Vaccination_date"]);
                            //Console.WriteLine("Child Number :" + rdr["child_number"]);
                            if (rdr != null)
                            {
                                try
                                {
                                    tmpAshaAdhar = Convert.ToInt64(rdr["Aashaworkr_Addhar_no"]);
                                    n = 1;

                                }
                                catch (FormatException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                                catch (OverflowException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Vaccine 9 Not Complete");
                        Console.WriteLine();
                        Console.WriteLine("--------------------------------");
                        SqlConnection con1 = new SqlConnection(Global.ConnectionString);
                        SqlCommand cmd1 = new SqlCommand();

                        cmd1.Connection = con1;
                        cmd1.CommandText = $"select TVaccination_date from Vaccine8 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                        cmd1.CommandType = CommandType.Text;
                        con1.Open();
                        SqlDataReader rdr1 = cmd1.ExecuteReader();

                        if (rdr1.HasRows)
                        {
                            while (rdr1.Read())
                            {
                                Console.WriteLine("Next vaccination date :" + rdr1[0]);

                            }

                        }
                        else
                        {
                            Console.WriteLine("Not found");
                        }
                        next = false;
                        Console.ReadKey();
                        n = 1;
                        break;
                    }
                    con.Close();
                    z++;
                }

                if (z == 1)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Aashaworkr_Fname,Aashaworkr_Mname,Aashaworkr_Lname,Aashaworkr_Contact,CEC_number from Aashaworkr where Aashaworkr_Addhar_no='{tmpAshaAdhar}' ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("Vaccine Given by             : " + rdr["Aashaworkr_Fname"] + " " + rdr["Aashaworkr_Mname"] + " " + rdr["Aashaworkr_Lname"]);
                            Console.WriteLine("Aashaworker Contact          : " + rdr["Aashaworkr_Contact"]);
                            if (rdr != null)
                            {
                                try
                                {
                                    tempCEC_Number = Convert.ToString(rdr["CEC_number"]);

                                }
                                catch (FormatException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                                catch (OverflowException ex)
                                {

                                    Console.WriteLine("Conversion failed: " + ex.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (n != 0)
                        {
                            Console.WriteLine("Someting Went Wrong to fetch data");
                        }

                    }
                    con.Close();
                    z++;

                }
                if (z == 2)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Hospital_name from Hospital where CEC_number='{tempCEC_Number}'";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine("Hosptital Name           : " + rdr["Hospital_name"]);
                            

                        }
                    }
                    else
                    {
                        if (n != 0)
                        {
                            Console.WriteLine("Someting Went Wrong to fetch data");
                            Console.ReadKey();

                        }
                    }
                    con.Close();
                    
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------");
                    

                }

            }

            if (next == true)
            {
                Console.WriteLine("You Complet All Vaccination");
                Console.ReadKey();

            }


        }

        //-- ckeck Valid Child
        public void CheckvalidChild()
        
        {

            int n = 0;
            while (n != 1)
            {
                try
                {

                    Console.WriteLine("Enter user mother (Aadhar no))");

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


                    Console.WriteLine("Enter Child family number(Ex=1,2) ");
                    ChildFnumbar = int.Parse(Console.ReadLine());
                    n = 1;


                }
                catch (FormatException fe)
                {
                    n = 0;

                    Console.WriteLine("please Re-Enter Child family number(Ex=1,2)");
                    Console.WriteLine("-------------------------------------------");


                }

            }

            
            //-- ckeck Valid Child 
            
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = $"select * from child where Mother_Addhar_no='{M_Addhar_no}'AND IsDelete!='{IsDelete}'AND child_number={ChildFnumbar}";
                //cmd.CommandText = $"select Mother_Addhar_no,Child_Fname,child_Mname,child_Lname,Gender,DOB,child_number from child where Mother_Addhar_no={M_Addhar_no} AND child_number={ChildFnumbar}";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                
            
            
            if (rdr.HasRows)
                {
                    Console.Clear();
                    int c=0;
                    Console.WriteLine("Child Found");
                    Global.Mother_adhar_no = M_Addhar_no;
                    Global.child_number = ChildFnumbar;
                    ChildInfo(M_Addhar_no, ChildFnumbar,1);
                Console.WriteLine();
                    n = 1;
                }
                else
                {
                    Console.WriteLine("Invalid Credential...!!!");

                    n = 0;
                    
                }
                con.Close();
            
                

        }


        //--Update Vaccination Status

        private void UpdateVaccination(long M_Aaddhar, int ChildFnumber)
        {
            
            Console.WriteLine("Update Vaccination Status ");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Enter which number of vaccination Update (Ex.1 to 9) ");
            try
            {
                number = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please Enter Correct number");
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Please Enter Only Number between 1 to 9");
            }

            //Check 1 vaccine is complete or not
            if (number == 1)
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = $"select Vaccine_number,Vaccine_Name,Vaccination_date,Aashaworkr_Addhar_no from Vaccine1 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    Console.Clear();
                    Console.WriteLine("--------------------------------------------------------------");
                    Console.WriteLine("     Vaccine  1  Complete  Please check Vaccination Status    ");
                    Console.WriteLine("---------------------------------------------------------------");
                    while (rdr.Read())
                    {
                        Console.WriteLine("Vaccine Number             : " + rdr["Vaccine_number"]);
                        Console.WriteLine("Vaccine Name               : " + rdr["Vaccine_Name"]);
                        Console.WriteLine("Vaccination Date And time  : " + rdr["Vaccination_date"]);
                        //Console.WriteLine("Child Number :" + rdr["child_number"]);
                        if (rdr != null)
                        {
                            try
                            {
                                tmpAshaAdhar = Convert.ToInt64(rdr["Aashaworkr_Addhar_no"]);
                                n = 1;

                            }
                            catch (FormatException ex)
                            {

                                Console.WriteLine("Conversion failed: " + ex.Message);
                            }
                            catch (OverflowException ex)
                            {

                                Console.WriteLine("Conversion failed: " + ex.Message);
                            }
                        }
                    }
                    con.Close();
                    Console.ReadKey();
                }
                else
                {
                    con.Close ();
                    Console.Clear();
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("Vaccine 1 Not Complete");
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("1.Press 1 To Complete Vaccine    ");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("2.Press 2 To Exit Without ");
                    Console.WriteLine("---------------------------------");
                    ch=int.Parse(Console.ReadLine());

                    if (ch==1)
                    {
                        Console.WriteLine(A_Addhar_no);
                        Console.ReadKey();
                        SqlConnection con12 = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");

                        SqlCommand cmd12 = new SqlCommand();

                        cmd12.Connection = con12;
                        cmd12.CommandText = $"insert into Vaccine1(Mother_Addhar_no,Aashaworkr_Addhar_no,child_number)values( '{M_Aaddhar}','{A_Addhar_no}', {ChildFnumber})";
                        cmd12.CommandType = CommandType.Text;
                        con12.Open();
                        int ins1 = cmd12.ExecuteNonQuery();

                        if (ins1 > 0)
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine("Vaccination 1 status Updated Successfully ");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Error :Not Update Vaccination 1 status");
                        }

                        con12.Close();
                    }
                    Console.ReadKey();
                }
            }

            //Check 1 and 2 vaccine is complete or not 
            if (number == 2)
            {
                next = false;
                int backcheck = 0;
                if (backcheck == 0)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Vaccine_number,Vaccine_Name,Vaccination_date,Aashaworkr_Addhar_no from Vaccine1 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        next = true;
                        backcheck++;
                        con.Close();
                    }
                    else
                    {
                        con.Close();
                        next= false;
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine(" Please Check Correct Vaccine number Complete ");
                        Console.WriteLine(" Error: Please Complete first  vaccine Number = 1  ");
                        Console.ReadKey();
                    }
                }

                if (backcheck == 1&& next==true)
                {
                    SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con1;
                    cmd.CommandText = $"insert into Vaccine2(Mother_Addhar_no,Aashaworkr_Addhar_no,child_number)values( '{M_Aaddhar}','{A_Addhar_no}', {ChildFnumber})";
                    cmd.CommandType = CommandType.Text;
                    con1.Open();
                    int ins1 = cmd.ExecuteNonQuery();

                    if (ins1 > 0)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("Vaccination 2 status Updated Successfully ");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Error :Not Update Vaccination 2 status");
                    }
                    con1.Close();
                }
                
            }


            //Check 2 and 3 vaccine is complete or not 
            if (number == 3)
            {
                next = false;
                int backcheck = 0;
                if (backcheck == 0)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Vaccine_number,Vaccine_Name,Vaccination_date,Aashaworkr_Addhar_no from Vaccine2 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        next = true;
                        backcheck++;
                        con.Close();
                    }
                    else
                    {
                        con.Close();
                        next = false;
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine(" Please Check Correct Vaccine number Complete ");
                        Console.WriteLine(" Error: Please Complete first  vaccine Number = 2  ");
                        Console.ReadKey();
                    }
                }

                if (backcheck == 1 && next == true)
                {
                    SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con1;
                    cmd.CommandText = $"insert into Vaccine3(Mother_Addhar_no,Aashaworkr_Addhar_no,child_number)values( '{M_Aaddhar}','{A_Addhar_no}', {ChildFnumber})";
                    cmd.CommandType = CommandType.Text;
                    con1.Open();
                    int ins1 = cmd.ExecuteNonQuery();

                    if (ins1 > 0)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("Vaccination 3 status Updated Successfully ");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Error :Not Update Vaccination 3 status");
                    }
                    con1.Close();
                }
            }


            //Check 3 and 4 vaccine is complete or not 
            if (number == 4)
            {
                next = false;
                int backcheck = 0;
                if (backcheck == 0)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Vaccine_number,Vaccine_Name,Vaccination_date,Aashaworkr_Addhar_no from Vaccine3 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        next = true;
                        backcheck++;
                        con.Close();
                    }
                    else
                    {
                        con.Close();
                        next = false;
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine(" Please Check Correct Vaccine number Complete ");
                        Console.WriteLine(" Error: Please Complete first  vaccine Number = 3  ");
                        Console.ReadKey();
                    }
                }

                if (backcheck == 1 && next == true)
                {
                    SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con1;
                    cmd.CommandText = $"insert into Vaccine4(Mother_Addhar_no,Aashaworkr_Addhar_no,child_number)values( '{M_Aaddhar}','{A_Addhar_no}', {ChildFnumber})";
                    cmd.CommandType = CommandType.Text;
                    con1.Open();
                    int ins1 = cmd.ExecuteNonQuery();

                    if (ins1 > 0)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("Vaccination 4 status Updated Successfully ");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Error :Not Update Vaccination 4 status");
                    }
                    con1.Close();
                }

            }


            //Check 4 and 5 vaccine is complete or not 
            if (number == 5)
            {
                next = false;
                int backcheck = 0;
                if (backcheck == 0)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Vaccine_number,Vaccine_Name,Vaccination_date,Aashaworkr_Addhar_no from Vaccine4 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        next = true;
                        backcheck++;
                        con.Close();
                    }
                    else
                    {
                        con.Close();
                        next = false;
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine(" Please Check Correct Vaccine number Complete ");
                        Console.WriteLine(" Error: Please Complete first  vaccine Number = 4  ");
                        Console.ReadKey();
                    }
                }

                if (backcheck == 1 && next == true)
                {
                    SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con1;
                    cmd.CommandText = $"insert into Vaccine5(Mother_Addhar_no,Aashaworkr_Addhar_no,child_number)values( '{M_Aaddhar}','{A_Addhar_no}', {ChildFnumber})";
                    cmd.CommandType = CommandType.Text;
                    con1.Open();
                    int ins1 = cmd.ExecuteNonQuery();

                    if (ins1 > 0)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("Vaccination 5 status Updated Successfully ");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Error :Not Update Vaccination 5 status");
                    }
                    con1.Close();
                }

            }


            //Check 5 and 6 vaccine is complete or not 

            if (number == 6)
            {
                next = false;
                int backcheck = 0;
                if (backcheck == 0)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Vaccine_number,Vaccine_Name,Vaccination_date,Aashaworkr_Addhar_no from Vaccine5 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        next = true;
                        backcheck++;
                        con.Close();
                    }
                    else
                    {
                        con.Close();
                        next = false;
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine(" Please Check Correct Vaccine number Complete ");
                        Console.WriteLine(" Error: Please Complete first  vaccine Number = 5  ");
                        Console.ReadKey();
                    }
                }

                if (backcheck == 1 && next == true)
                {
                    SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con1;
                    cmd.CommandText = $"insert into Vaccine6(Mother_Addhar_no,Aashaworkr_Addhar_no,child_number)values( '{M_Aaddhar}','{A_Addhar_no}', {ChildFnumber})";
                    cmd.CommandType = CommandType.Text;
                    con1.Open();
                    int ins1 = cmd.ExecuteNonQuery();

                    if (ins1 > 0)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("Vaccination 6 status Updated Successfully ");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Error :Not Update Vaccination 6 status");
                    }
                    con1.Close();
                }

            }


            //Check 6 and 7 vaccine is complete or not 

            if (number == 7)
            {
                next = false;
                int backcheck = 0;
                if (backcheck == 0)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Vaccine_number,Vaccine_Name,Vaccination_date,Aashaworkr_Addhar_no from Vaccine6 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        next = true;
                        backcheck++;
                        con.Close();
                    }
                    else
                    {
                        con.Close();
                        next = false;
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine(" Please Check Correct Vaccine number Complete ");
                        Console.WriteLine(" Error: Please Complete first  vaccine Number = 6  ");
                        Console.ReadKey();
                    }
                }

                if (backcheck == 1 && next == true)
                {
                    SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con1;
                    cmd.CommandText = $"insert into Vaccine7(Mother_Addhar_no,Aashaworkr_Addhar_no,child_number)values( '{M_Aaddhar}','{A_Addhar_no}', {ChildFnumber})";
                    cmd.CommandType = CommandType.Text;
                    con1.Open();
                    int ins1 = cmd.ExecuteNonQuery();

                    if (ins1 > 0)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("Vaccination 7 status Updated Successfully ");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Error :Not Update Vaccination 7 status");
                    }
                    con1.Close();
                }

            }


            //Check 7 and 8 vaccine is complete or not 

            if (number == 8)
            {
                next = false;
                int backcheck = 0;
                if (backcheck == 0)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Vaccine_number,Vaccine_Name,Vaccination_date,Aashaworkr_Addhar_no from Vaccine7 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        next = true;
                        backcheck++;
                        con.Close();
                    }
                    else
                    {
                        con.Close();
                        next = false;
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine(" Please Check Correct Vaccine number Complete ");
                        Console.WriteLine(" Error: Please Complete first  vaccine Number = 7  ");
                        Console.ReadKey();
                    }
                }

                if (backcheck == 1 && next == true)
                {
                    SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con1;
                    cmd.CommandText = $"insert into Vaccine8(Mother_Addhar_no,Aashaworkr_Addhar_no,child_number)values( '{M_Aaddhar}','{A_Addhar_no}', {ChildFnumber})";
                    cmd.CommandType = CommandType.Text;
                    con1.Open();
                    int ins1 = cmd.ExecuteNonQuery();

                    if (ins1 > 0)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("Vaccination 8 status Updated Successfully ");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Error :Not Update Vaccination 8 status");
                    }
                    con1.Close();
                }

            }



            //Check 8 and 9 vaccine is complete or not 

            if (number == 9)
            {
                next = false;
                int backcheck = 0;
                if (backcheck == 0)
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;
                    cmd.CommandText = $"select Vaccine_number,Vaccine_Name,Vaccination_date,Aashaworkr_Addhar_no from Vaccine8 where Mother_Addhar_no='{M_Aaddhar}' AND child_number={ChildFnumber} ";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        next = true;
                        backcheck++;
                        con.Close();
                    }
                    else
                    {
                        con.Close();
                        next = false;
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine(" Please Check Correct Vaccine number Complete ");
                        Console.WriteLine(" Error: Please Complete first  vaccine Number = 8  ");
                        Console.ReadKey();
                    }
                }

                if (backcheck == 1 && next == true)
                {
                    SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");

                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con1;
                    cmd.CommandText = $"insert into Vaccine9(Mother_Addhar_no,Aashaworkr_Addhar_no,child_number)values( '{M_Aaddhar}','{A_Addhar_no}', {ChildFnumber})";
                    cmd.CommandType = CommandType.Text;
                    con1.Open();
                    int ins1 = cmd.ExecuteNonQuery();

                    if (ins1 > 0)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("Vaccination 9 status Updated Successfully ");
                        Console.WriteLine("Congratulations You Have  Complete All Vaccinations ");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Error :Not Update Vaccination 9 status");
                    }
                    con1.Close();
                }

            }










        }


        //Check Aashaworker hospital Vaccination
        public void HospialVaccination()
        {
            
            SqlConnection con = new SqlConnection(Global.ConnectionString);
            try
            {
                
                    Console.Clear();
                    con.Close();
                    Console.WriteLine();
                    SqlCommand cmd1 = new SqlCommand($"select count( CEC_number) from Vaccine1 va inner join Aashaworkr aa on va.Aashaworkr_Addhar_no=aa.Aashaworkr_Addhar_no  where aa.CEC_number='{Hospital_CEC.CEC_Number}'", con);
                    con.Open();
                    int rdr1 = (int)cmd1.ExecuteScalar();

                    Console.WriteLine("Vaccination Complete of Your Hospital =" + rdr1);
                    Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
            }
        }
    }
}

