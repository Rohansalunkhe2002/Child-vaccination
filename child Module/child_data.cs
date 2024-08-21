using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using CProject.Aashawork_Module;
namespace CProject.child_Module
{
    public   class Global
    {
        public static long Mother_adhar_no;

        public static Int128 child_id;
        public static int child_number; //Data Source=LAPTOP_EDMNNM57\\sqlexpress;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True
        public static string ConnectionString = "Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True";
        

    }
    internal class child_data
    {
        int ch;
        bool f = true;
        int Child_number;
        string C_Fname, C_Mname, C_Lname;
        string Gender, DOB;

        bool IsDelete=true;


        int n;

        //Menu For Aashaworker
        public void ShowChildMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("         MENU FOR CHILD    ");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("1.Add New Child             ");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("2.Check Child List         ");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("3.Check Child Vaccnation status  ");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("4.Update Child Info        ");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("5.Exit");
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
                        AddChild();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Your choice :" + ch);
                        Childlist();
                        break;

                    case 3:
                        CheckvalidChild();

                        break;

                    case 4:
                        UpdateChildProfile();
                        break;

                    case 5:
                        f = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("----------------------------------------------------");
                        Console.WriteLine("Invalid Choice");
                        Console.WriteLine("Please Enter valid choice from Menu");
                        Console.WriteLine("----------------------------------------------------");
                        Console.ReadKey();

                        break;
                }
            } while (f == true);
        }

        //Add child 
        private void AddChild()
        {

            //--Child first name
            n = 0;

            while (n != 1)
            {
                try
                {


                    Console.WriteLine("Enter the Child First Name");
                    C_Fname = Console.ReadLine();
                    C_Fname = C_Fname.Trim();
                    C_Fname = C_Fname.ToLower();
                    n = ValidateMyString(C_Fname);
                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.WriteLine("please Enter Correct Child First name");
                    Console.WriteLine("-------------------------------------------");

                }


            }

            //--Child Middle name
            n = 0;
            while (n != 1)
            {
                try
                {

                    Console.WriteLine("Enter the Child Middle Name");
                    C_Mname = Console.ReadLine();
                    C_Mname = C_Mname.Trim();
                    C_Mname = C_Mname.ToLower();
                    n = ValidateMyString(C_Mname);
                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.WriteLine("please Enter Correct Child Middle name");
                    Console.WriteLine("-------------------------------------------");

                }

            }

            //--Child Last name
            n = 0;
            while (n != 1)
            {
                try
                {
                    Console.WriteLine("Enter the Child Last Name");
                    C_Lname = Console.ReadLine();
                    C_Lname = C_Lname.Trim();
                    C_Lname = C_Lname.ToLower();
                    n = ValidateMyString(C_Lname);
                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.WriteLine("please Enter Correct Child Middle name");
                    Console.WriteLine("-------------------------------------------");

                }

            }

            //--Child Gender of child
            n = 0;
            while (n != 1)
            {
                try
                {

                    Console.WriteLine("choice for Child Gender  (Male/Female)");

                    Console.WriteLine("1.Male");
                    Console.WriteLine("2.Female");
                    ch = int.Parse(Console.ReadLine());
                    if (ch == 1)
                    {
                        Gender ="Male";
                        n = 1;
                    }else if (ch == 2)
                    {
                        Gender ="Female";
                        n = 1;
                    }
                    else
                    {
                        Console.WriteLine("Please Enter Correct choice");
                        n = 0;
                    }  
                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.WriteLine("please Enter Correct Gender name");
                    Console.WriteLine("-------------------------------------------");

                }

            }

            //--Child Date of birth of child
            n = 0;
            while (n != 1)
            {
                try
                {

                    Console.WriteLine("Enter the Date of birth of Child (YY-MM-DD) ");
                    DOB = Console.ReadLine();
                    DOB = DOB.Trim();
                    n = ValidateDOB(DOB);
                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.WriteLine("please Enter Correct Date of birth");
                    Console.WriteLine("-------------------------------------------");

                }

            }


            n = 0;
            while (n != 1)
            {
                try
                {

                    Console.WriteLine("Enter the child number in family ");
                    Child_number = int.Parse(Console.ReadLine());
                    if (Child_number < 10)
                    {
                        n = 1;
                    }
                    else
                    {
                        n = 0;
                        Console.WriteLine("Please Enter child number less than 10");
                    }
                }
                catch (FormatException fe)
                {
                    n = 0;
                    Console.WriteLine("please Enter Correct child numnber");
                    Console.WriteLine("-------------------------------------------");

                }

            }
            SqlConnection con = new SqlConnection(Global.ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandText = "insert into Child(Mother_Addhar_no,child_Fname,child_Mname,child_Lname,Gender,DOB,child_number )values (" + Global.Mother_adhar_no + ",'" + C_Fname + "','" + C_Mname + "','" + C_Lname + "','" + Gender + "','" + DOB + "'," + Child_number + ")";
                cmd.CommandType = CommandType.Text;
                con.Open();
                int ins = cmd.ExecuteNonQuery();

                if (ins > 0)
                {
                    Console.WriteLine("Child record inserted successully");

                    /*************************update child count in parent table*******************************/
                    // SqlCommand cmd1=new SqlCommand();
                    // cmd1.Connection = con;
                    // cmd1.CommandText = "sp_update_childCount";
                    // cmd1.CommandType= CommandType.StoredProcedure;
                    // cmd1.Parameters.AddWithValue("@mAdNo", Global.Mother_adhar_no);
                    //int nn= cmd1.ExecuteNonQuery();
                    Console.ReadKey();

                }
                else
                {
                    Console.WriteLine("Child record not inserted!!!");
                    Console.ReadKey();
                }

            }
            catch(Exception e)
            {
                con.Close();

            }
            //------SQL connection For Insert New Child

            

            
        }

        //--Check Child List
        private void Childlist()
        {


            //step1
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");

            try
            {
                con.Open();

                //step2
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = $"select Child_Fname,Child_Lname,child_number from Child where Mother_Addhar_no={Global.Mother_adhar_no}";
                cmd.CommandType = CommandType.Text;


                //step3
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine("Child Name: " + rdr[0] + "\t" + rdr[1]);
                    Console.WriteLine("Child no  : " + rdr[2]);
                    Console.WriteLine();

                }

            }
            catch(Exception e) {

                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
            
            

            Console.ReadKey();
        }

        //--String Validate
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


        //--Validate Date of Birth
        static int ValidateDOB(string s)
        {
            Regex regex = new Regex(@"^\d{4}-\d{2}-\d{2}$");

            if (!regex.IsMatch(s))
            {
                Console.WriteLine("Please Re-Enter");
                return 0;
            }
            return 1;
        }



        //-Check child Vaccination  Status
        public void CheckvalidChild()

        {

            

            n = 0;
            //-- child number;
            while (n != 1)
            {
                try
                {


                    Console.WriteLine("Enter Child family number(Ex=1,2) ");
                    Child_number = int.Parse(Console.ReadLine());
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
            SqlConnection con = new SqlConnection(Global.ConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = $"select * from child where Mother_Addhar_no='{Global.Mother_adhar_no}'AND IsDelete!='{IsDelete}' AND child_number={Child_number}";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    Console.Clear();
                    Console.WriteLine("Child Found");
                    int c = 1;
                    LoginAashwork LA = new LoginAashwork();
                    LA.ChildInfo(Global.Mother_adhar_no, Child_number, 0);//0 for parent 1 for asha worker

                    n = 1;
                }
                else
                {
                    Console.WriteLine("Invalid Credential...!!!");
                    n = 0;
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



        //Update Child info

        public  void UpdateChildProfile()
        {
            n = 0;
            //-- child number;
            while (n != 1)
            {
                try
                {


                    Console.WriteLine("Enter Child family number(Ex=1,2) ");
                    Child_number = int.Parse(Console.ReadLine());
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


            SqlConnection con = new SqlConnection(Global.ConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = $"select Child_Fname from child where Mother_Addhar_no='{Global.Mother_adhar_no}'AND IsDelete!='{IsDelete}' AND child_number={Child_number}";
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {

                    Console.Clear();
                    Console.WriteLine(" Child Found");
                    while (rdr.Read())
                    {
                        Console.WriteLine("Child Name: " + rdr[0]);
                    }
                    con.Close();
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("You can Update only Child name ");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine();

                    n = 0;
                    while (n != 1)
                    {
                        try
                        {

                            Console.WriteLine("Enter the Child First Name");
                            C_Fname = Console.ReadLine();
                            C_Fname = C_Fname.Trim();
                            n = ValidateMyString(C_Fname);
                        }
                        catch (FormatException fe)
                        {
                            n = 0;
                            Console.WriteLine("please Enter Correct Child First name");
                            Console.WriteLine("-------------------------------------------");

                        }
                    }
                    SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-EDMNNM57\\SQLEXPRESS;Initial Catalog=Cproject;Integrated Security=True;TrustServerCertificate=True");

                    try
                    {

                        SqlCommand cmd1 = new SqlCommand();

                        cmd1.Connection = con1;
                        cmd1.CommandText = $"update child set child_Fname='{C_Fname}' where Mother_Addhar_no='{Global.Mother_adhar_no}'AND IsDelete!='{IsDelete}' AND child_number={Child_number}";
                        cmd1.CommandType = CommandType.Text;
                        con1.Open();
                        int ins = cmd1.ExecuteNonQuery();

                        if (ins > 0)
                        {
                            Console.WriteLine("Child name Updated..");

                        }
                        else
                        {
                            Console.WriteLine("Child name not Updated..");
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    finally
                    {
                        con1.Close();
                    }

                    Console.ReadKey();
                    n = 1;
                }
                else
                {
                    
                    Console.WriteLine("Invalid Credential...!!!");
                    
                    n = 0;
                }

            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close ();
            }
            Console.ReadKey(); 
        }



    }
}
