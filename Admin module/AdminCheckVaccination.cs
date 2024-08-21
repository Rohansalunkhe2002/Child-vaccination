using CProject.child_Module;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace CProject.Admin_module
{
    internal class AdminCheckVaccination
    {
        int ch;
        bool f=true;

        string CEC_Number;
        //Check Vaccination Complete

        public void CheckVaccineComplete()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("MENU FOR CHECK VACCINATION COMPLETE ");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1.Check All Vaccination");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("2.Check Perticular Year Vaccination   ");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("3.Check Perticular Month Vaccination  ");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("4.Check Perticular Day Vaccination    ");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("5.Check Perticular Hospital Vaccination");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("6.Exit ");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Enter Choice : ");
                try
                {
                    ch = int.Parse(Console.ReadLine());

                }
                catch (Exception)
                {
                    Console.WriteLine("Please Enter Correct Choise");
                }

                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Your Choice :"+ch);
                        AllVaccine();

                        break;
                    case 2:
                        Console.WriteLine("Your Choice :" + ch);
                        YearVaccine();
                        break;

                    case 3:
                        Console.WriteLine("Your Choice :" + ch);
                        MonthVaccine();
                        break;

                    case 4:
                        Console.WriteLine("Your Choice :" + ch);
                        DayVaccine();
                        break;

                    case 5:
                        Console.WriteLine("Your Choice :" + ch);
                        HospialVaccination();
                        break;

                    case 6:
                        Console.WriteLine("Your Choice :" + ch);
                        f = false;
                        break;

                    default:
                        Console.WriteLine("Please Enter Correct Choise");
                        break;
                }

            } while (f == true);
        }

        //All vaccination
        private void AllVaccine()
        {
            ch = 1;
            //Count of Vaccine 2
            if (ch == 1)
            {
                string columnName = "Vaccination_date";
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = $"select  COUNT({columnName})Vaccination_date from Vaccine1 ";
                cmd.CommandType = CommandType.Text;
                

                try
                {
                    con.Open();
                    long rdr = (int)cmd.ExecuteScalar();
                    Console.WriteLine(" Vaccine 1 completed Count = " + rdr);

                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                con.Close();
                ch++;
            }

            //Count of Vaccine 2
            if (ch == 2)
            {
                string columnName = "Vaccination_date";
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = $"select  COUNT({columnName})Vaccination_date from Vaccine2 ";
                cmd.CommandType = CommandType.Text;


                try
                {
                    con.Open();
                    long rdr = (int)cmd.ExecuteScalar();
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine(" Vaccine 2 completed Count = " + rdr);
                    Console.WriteLine("--------------------------------------");

                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                con.Close();
                ch++;
            }


            //Count of Vaccine 3
            if (ch == 3)
            {
                string columnName = "Vaccination_date";
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select  COUNT({columnName})Vaccination_date from Vaccine3 ";
                cmd.CommandType = CommandType.Text;
                try
                {
                    con.Open();
                    long rdr = (int)cmd.ExecuteScalar();
                    Console.WriteLine(" Vaccine 3 completed Count = " + rdr);

                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                con.Close();
                ch++;
            }

            //Count of Vaccine 4
            if (ch == 4)
            {
                string columnName = "Vaccination_date";
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = $"select  COUNT({columnName})Vaccination_date from Vaccine4 ";
                cmd.CommandType = CommandType.Text;


                try
                {
                    con.Open();
                    long rdr = (int)cmd.ExecuteScalar();
                    Console.WriteLine(" Vaccine 4 completed Count = " + rdr);

                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                con.Close();
                ch++;
            }


            //Count of Vaccine 5
            if (ch == 5)
            {
                string columnName = "Vaccination_date";
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = $"select  COUNT({columnName})Vaccination_date from Vaccine5 ";
                cmd.CommandType = CommandType.Text;


                try
                {
                    con.Open();
                    long rdr = (int)cmd.ExecuteScalar();
                    Console.WriteLine(" Vaccine 5 completed Count = " + rdr);

                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                con.Close();
                ch++;
            }


            //Count of Vaccine 6
            if (ch == 6)
            {
                string columnName = "Vaccination_date";
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = $"select  COUNT({columnName})Vaccination_date from Vaccine6 ";
                cmd.CommandType = CommandType.Text;


                try
                {
                    con.Open();
                    long rdr = (int)cmd.ExecuteScalar();
                    Console.WriteLine(" Vaccine 6 completed Count = " + rdr);

                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                con.Close();
                ch++;
            }



            //Count of Vaccine 7
            if (ch == 7)
            {
                string columnName = "Vaccination_date";
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = $"select  COUNT({columnName})Vaccination_date from Vaccine7 ";
                cmd.CommandType = CommandType.Text;


                try
                {
                    con.Open();
                    long rdr = (int)cmd.ExecuteScalar();
                    Console.WriteLine(" Vaccine 7 completed Count = " + rdr);

                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                con.Close();
                ch++;
            }

            //Count of Vaccine 8
            if (ch == 8)
            {
                string columnName = "Vaccination_date";
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = $"select  COUNT({columnName})Vaccination_date from Vaccine8 ";
                cmd.CommandType = CommandType.Text;


                try
                {
                    con.Open();
                    long rdr = (int)cmd.ExecuteScalar();
                    Console.WriteLine(" Vaccine 8 completed Count = " + rdr);

                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                con.Close();
                ch++;
            }


            //Count of Vaccine 9
            if (ch == 9)
            {
                string columnName = "Vaccination_date";
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = $"select  COUNT({columnName})Vaccination_date from Vaccine9 ";
                cmd.CommandType = CommandType.Text;


                try
                {
                    con.Open();
                    long rdr = (int)cmd.ExecuteScalar();
                    Console.WriteLine(" Vaccine 9 completed Count = " + rdr);

                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                con.Close();
                ch = 0;
                Console.ReadKey();
            }
        }

        //check Hospital Wise Vaccination
        public void HospialVaccination()
        {
            SqlConnection con = new SqlConnection(Global.ConnectionString);
            try
            {
                
                Console.WriteLine("Enter CSE number of hospital");
                CEC_Number = Console.ReadLine();

                SqlCommand cmd = new SqlCommand($"select CEC_number from Hospital where CEC_number='{CEC_Number}' ", con);
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    Console.Clear();
                    con.Close();
                    Console.WriteLine("Hospital Found");

                    SqlCommand cmd1 = new SqlCommand($"select count( CEC_number) from Vaccine1 va inner join Aashaworkr aa on va.Aashaworkr_Addhar_no=aa.Aashaworkr_Addhar_no  where aa.CEC_number='{CEC_Number}'",con);
                    con.Open();
                    int rdr1 = (int)cmd1.ExecuteScalar();

                    Console.WriteLine("Vaccination Complete of this Hospital ="+rdr1);
                    Console.ReadKey();
                    
                    

                }
                else
                {
                    Console.WriteLine("Hospital not found");

                }

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

        //Year Wise Vaccination 
        private void YearVaccine()
        {
            int year=0;
            //MONTH(Vaccination_date)
            try
            {
                Console.WriteLine("Enter the year to check vaccine( Ex.2002)");
                year=int.Parse(Console.ReadLine());

            }catch(FormatException e)
            {
                Console.WriteLine("Please Re-Enter");
            }


            string columnName = "Vaccination_date";
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = $"SELECT COUNT(*) FROM Vaccine1 WHERE YEAR(Vaccination_date) ='{year}';";
            cmd.CommandType = CommandType.Text;
            try
            {
                con.Open();
                long rdr = (int)cmd.ExecuteScalar();
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(" Vaccine 1 completed Count = " + rdr);
                Console.WriteLine("--------------------------------------");

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            con.Close();

            Console.ReadKey();

        }

        //Month wise Vaccination
        private void MonthVaccine()
        {
            Console.Clear();
            int year = 0;
            int month = 0;
            //MONTH(Vaccination_date)
            try
            {
                Console.WriteLine("Enter the Month to check vaccine( Ex.1,2 )");
                month = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the year to check vaccine( Ex.2002)");
                year = int.Parse(Console.ReadLine());

            }
            catch (FormatException e)
            {
                Console.WriteLine("Please Re-Enter");
            }


            string columnName = "Vaccination_date";
            SqlConnection con = new SqlConnection(Global.ConnectionString);
            SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM Vaccine1 WHERE MONTH(Vaccination_date)='{month}'AND YEAR(Vaccination_date) ='{year}'",con);

            
            
            cmd.CommandType = CommandType.Text;
            try
            {
                con.Open();
                long rdr = (int)cmd.ExecuteScalar();
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(" Vaccine 1 completed Count = " + rdr);
                Console.WriteLine("--------------------------------------");

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            con.Close();

            Console.ReadKey();

        }

        //Day wise Vaccination
        private void DayVaccine()
        {
            Console.Clear();
            int year = 0;
            int month = 0;
            int day = 0;
            //MONTH(Vaccination_date)
            try
            {

                Console.WriteLine("Enter the day  only to check Vaccine( Ex.1,15,27 etc)");
                day=int.Parse(Console.ReadLine());  

                Console.WriteLine("Enter the Month to check vaccine( Ex.1,2 )");
                month = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the year to check vaccine( Ex.2002)");
                year = int.Parse(Console.ReadLine());

            }
            catch (FormatException e)
            {
                Console.WriteLine("Please Re-Enter");
            }


            string columnName = "Vaccination_date";
            SqlConnection con = new SqlConnection(Global.ConnectionString);
            SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM Vaccine1 WHERE DAY(Vaccination_date)='{day}'AND MONTH(Vaccination_date)='{month}'AND YEAR(Vaccination_date) ='{year}'", con);



            cmd.CommandType = CommandType.Text;
            try
            {
                con.Open();
                long rdr = (int)cmd.ExecuteScalar();
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(" Vaccine 1 completed Count = " + rdr);
                Console.WriteLine("--------------------------------------");

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            con.Close();

            Console.ReadKey();
    }

        


    }
}
