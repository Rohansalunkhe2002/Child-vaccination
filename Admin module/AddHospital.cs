using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CProject.child_Module;
using CProject.SMS;

namespace CProject.Admin_module
{
     
    internal class AddHospital: HospitalCheckList
    {
        int ch;
        bool f = true;
        int n = 0;

        string CEC_Number;
        string Hospital_name;
        public void ChoiceAdmin()
        {

            do
            {
                Console.Clear();
                Console.WriteLine("         MENU FOR Hospital   ");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("1.Add New Hospital          ");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("2.Delete hospital       ");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("3.Update hospital       ");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("4.Check Hospital list       ");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("5.Check Vaccination updates ");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("6.Send Notification For todays Vaccination       ");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("7.Exit");
                Console.WriteLine("-------------------------------------------");
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
                        AddHospitals();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Your choice :" + ch);
                        DeleteHospital();

                        
                        break;
                    case 3:
                        UpdateHospital();
                        break;

                    case 4:
                        HospitalCheckList CheckH = new HospitalCheckList();
                        CheckH.HospitalChoice();
                        break;

                    case 5:
                        AdminCheckVaccination ACVaccine = new AdminCheckVaccination();
                        ACVaccine.CheckVaccineComplete();
                        break;

                    case 6:
                        SMS_Sender Sms = new SMS_Sender();
                        Sms.Sms_send();
                        break;

                    case 7:
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

        //Add Hospital
        private void AddHospitals()
        {
            n = 0;
            Console.WriteLine("ADD Hospital FORM");
            Console.WriteLine("------------------");
            Console.WriteLine();
            while (n != 1)
            {
                
                Console.WriteLine("Enter The Hospital Clinical Establishments ncertificate number");
                CEC_Number = Console.ReadLine();
                n=ValidateMyString( CEC_Number );

                if (n == 1)
                {

                }
                else
                {
                    Console.WriteLine("Please R-Enter correct one");

                }
            }
            n = 0;
            while (n != 1)
            {
                Console.WriteLine("Enter Hospital Full name");
                Hospital_name = Console.ReadLine();
                
                if (Hospital_name.Length != 0)
                {
                    n = 1;
                }
                else
                {
                    n = 0;
                }
                
            }


           
            SqlConnection con = new SqlConnection(Global.ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = $"insert into Hospital(CEC_number, Hospital_name )values('{CEC_Number}', '{Hospital_name}')";
                cmd.CommandType = CommandType.Text;
                con.Open();
                int ins = cmd.ExecuteNonQuery();

                if (ins > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Hospital Added Succesfully..");
                }
                else
                {
                    Console.WriteLine("Hospital  not inserted !!!");
                }

            }
            catch (Exception e)
            {

            }
            finally
            {
                con.Close();

            }
            Console.ReadKey();
        }

        //Delete hospital
        private void DeleteHospital()
        {
            Console.WriteLine("Delete Hospital");
            n = 0;
            Console.WriteLine("DELETE Hospital FORM");
            Console.WriteLine("------------------");
            Console.WriteLine();
            while (n != 1)
            {
                
                Console.WriteLine("Enter The Hospital Clinical Establishments ncertificate number to delete ");
                CEC_Number = Console.ReadLine();
                n = ValidateMyString(CEC_Number);



                if (n == 1)
                {
                    Boolean IsDelete = true;

                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = $"select CEC_number,IsDelete from Hospital where CEC_number='{CEC_Number}' AND IsDelete='{IsDelete}'";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader ins = cmd.ExecuteReader();
                    
                    if (ins.HasRows)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Hospital is Delete Already ");
                        con.Close();
                    }
                    else
                    {
                        con.Close();
                        cmd.CommandText = $"select CEC_number from Hospital where CEC_number='{CEC_Number}'";
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        SqlDataReader del = cmd.ExecuteReader();
                        
                        if (del.HasRows)
                        {
                            con.Close();
                            cmd.CommandText = $" delete Hospital where CEC_number='{CEC_Number}'";
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            int dele = cmd.ExecuteNonQuery();
                            if (dele > 0)
                            {
                                Console.WriteLine("Hospital Deleted Succesfully");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Hospital not  found to delete");
                        }   
                    }
                    con.Close();
                }
                else
                {
                    Console.WriteLine("Please R-Enter correct one");

                }
            }

            Console.ReadKey();

        }

        //Update Hospital

        private void UpdateHospital()
        {
            f = true;
            do
            {


                Console.Clear();
                Console.WriteLine("      MENU FOR Update Hospital   ");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("1.Update Hospital CEC number    ");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("2.Update hospital name           ");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("3.Exit           ");
                Console.WriteLine("---------------------------------");

                try
                {
                    ch = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please Enter Correct Choice");
                }

                if (ch == 1)
                {
                    n = 0;
                    SqlConnection con = new SqlConnection(Global.ConnectionString);
                    Console.WriteLine("Your choice : "+ch);
                    Console.WriteLine("1.Update Hospital CEC number ");
                    Console.WriteLine();
                    Console.WriteLine("------------------------------");
                    Console.WriteLine();
                    while (n != 1)
                    {
                        Console.WriteLine("Enter The Hospital Clinical Establishments Certificate number");
                        CEC_Number = Console.ReadLine();
                        n = ValidateMyString(CEC_Number);
                        if (n != 0)
                        {
                            n = 1;
                        }
                        else
                        {
                            n = 0;
                        }

                    }
                    try
                    {
                        n = 0;
                        
                        SqlCommand cmd = new SqlCommand($"select CEC_number from Hospital where CEC_number='{CEC_Number}' ", con);
                        con.Open();

                        SqlDataReader rdr= cmd.ExecuteReader();

                        if (rdr.HasRows)
                        {
                            Console.WriteLine("Hospital Found");
                            con.Close();
                            try
                            {
                                n = 1;
                                
                                while (n != 0)
                                {
                                    Hospital_CEC.CEC_Number = CEC_Number;
                                    Console.WriteLine("Enter New  Hospital Clinical Establishments Certificate number ");
                                    CEC_Number = Console.ReadLine();
                                    n = ValidateMyString(CEC_Number);
                                   
                                    if (n != 0)
                                    {
                                        n = 0;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please Enter Correct CEC number");
                                        n = 1;
                                    }
                                }
                                

                                SqlCommand cmd2 = new SqlCommand($"update Hospital set CEC_number='{CEC_Number}' where CEC_number= '{Hospital_CEC.CEC_Number}'", con);
                                con.Open();
                                int ins = cmd2.ExecuteNonQuery();
                                
                                Console.ReadKey();
                                
                                if (ins>0)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Update Successefully");
                                    Console.ReadKey();

                                }
                                else
                                {
                                    Console.WriteLine("Error : Canot Update this Time");
                                    Console.ReadKey();
                                }

                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine(ex);
                            }
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Hospital Not found");
                            Console.ReadKey();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else if(ch == 2)
                {
                    n = 0;
                    SqlConnection con = new SqlConnection(Global.ConnectionString);
                    Console.WriteLine("Your choice : " + ch);
                    Console.WriteLine("1.Update Hospital Name ");
                    Console.WriteLine();
                    Console.WriteLine("------------------------------");
                    Console.WriteLine();
                    while (n != 1)
                    {
                        Console.WriteLine("Enter The Hospital Clinical Establishments Certificate number");
                        CEC_Number = Console.ReadLine();
                        n = ValidateMyString(CEC_Number);
                        if (n != 0)
                        {
                            n = 1;
                        }
                        else
                        {
                            n = 0;
                        }

                    }
                    try
                    {
                        n = 0;

                        SqlCommand cmd = new SqlCommand($"select CEC_number from Hospital where CEC_number='{CEC_Number}' ", con);
                        con.Open();

                        SqlDataReader rdr = cmd.ExecuteReader();

                        if (rdr.HasRows)
                        {
                            Console.WriteLine("Hospital Found");
                            con.Close();
                            try
                            {
                                n = 1;

                                while (n != 0)
                                { 
                                    
                                    Console.WriteLine("Enter New  Hospital Name ");
                                    Hospital_name = Console.ReadLine();

                                    if (Hospital_name.Length != 0)
                                    {
                                        n = 0;
                                    }
                                    else
                                    {
                                        n = 0;
                                    }
                                    
                                }


                                SqlCommand cmd2 = new SqlCommand($"update Hospital set Hospital_name='{Hospital_name}' where CEC_number= '{CEC_Number}'", con);
                                con.Open();
                                int ins = cmd2.ExecuteNonQuery();

                                

                                if (ins > 0)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Update Successefully");
                                    Console.ReadKey();

                                }
                                else
                                {
                                    Console.WriteLine("Error : Canot Update this Time");
                                    Console.ReadKey();
                                }

                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine(ex);
                            }
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Hospital Not found");
                            Console.ReadKey();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else if (ch==3)
                {
                    
                    f = false;
                    
                }
                else
                {
                    Console.WriteLine("Enter correct Choice");
                }
            } while (f==true);








            


        }


        

        // Vallidate My CEC_number  
        static int ValidateMyString(string s)
        {
            Regex regex = new Regex("^[A-Z0-9]*$");

            if (!regex.IsMatch(s))
            {
                Console.WriteLine("Please Re-Enter");
                return 0;
            }
            return 1;
        }

        
    }
}
