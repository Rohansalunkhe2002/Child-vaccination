using CProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CProject.Aashawork_Module
{
    internal class AllAashaworker
    {
        int ch;
        bool f = true;
        public void AW_Choice()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("       MENU            ");
                Console.WriteLine("--------------------------");
                Console.WriteLine("1.Create Aashaworker Account");
                Console.WriteLine("--------------------------");
                Console.WriteLine("2.Login Aashaworker Account ");
                Console.WriteLine("--------------------------");
                Console.WriteLine("3.Exit");
                Console.WriteLine("--------------------------");
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
                        Console.WriteLine("       Register Here        ");
                        Console.WriteLine("-----------------------------");
                        RegisterAshawork RW= new RegisterAshawork();
                        RW.A_GetInfo();
                        break;

                    case 2:

                        Console.Clear();
                        Console.WriteLine("Your choice :" + ch);
                        Console.WriteLine("       Login Here        ");
                        Console.WriteLine("-----------------------------");
                        LoginAashwork LA=   new LoginAashwork();
                        LA.Checkinfo();
                        break;

                    case 3:

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
