using CProject.Aashawork_Module;
using CProject.Admin_module;
using CProject.SMS;

namespace CProject
{
    //https://github.com/pravin9696/ADO_CRUD_090724/blob/master/Program.cs
    internal class Program
    {
        
        
        static void Main(string[] args)
        {
            

            //Home Page
            int ch=0;
            bool f = true;
            int cl = 0;
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                                                                                 WELCOME IN MY PROJECT                                                                ");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            do
            {
                if (cl == 1)
                {
                    Console.Clear();
                }
                
                Console.WriteLine("          MENU            ");
                Console.WriteLine("--------------------------");
                Console.WriteLine("1.Parent ");
                Console.WriteLine("--------------------------");
                Console.WriteLine("2.Ashawork ");
                Console.WriteLine("--------------------------");
                Console.WriteLine("3.Admin ");
                Console.WriteLine("--------------------------");
                Console.WriteLine("4.Exit");
                Console.WriteLine("--------------------------");
                try
                {
                    Console.WriteLine("Enter choice :");
                    ch = int.Parse(Console.ReadLine());
                                      
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("please Enter Correct choice...");
                }catch(OverflowException o)
                {
                    Console.WriteLine("please Enter Correct choice...");
                }    
                switch (ch)
                {

                    case 1:
                        
                        Console.Clear();
                        Console.WriteLine("Your choice :"+ch);
                        AllParent Ap = new AllParent();
                        cl=1;
                        Ap.P_Choice();
                        break;

                    case 2:
                        AllAashaworker AW=new AllAashaworker();
                        AW.AW_Choice();
                        break;

                    case 3:
                        cl = 1;
                        LoginAdmin AL=new LoginAdmin();
                        AL.CheckAdmininfo();
                        break;

                    

                    case 4:
                        cl = 1;
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
    }
}
