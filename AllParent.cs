using CProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CProject
{
    internal class AllParent
    {
        int ch;
        bool f=true;

        //Parent Menu Choice
        public void P_Choice()
        {

            do
            {

                Console.Clear();
                Console.WriteLine("       MENU            ");
                Console.WriteLine("--------------------------");
                Console.WriteLine("1.Create Parent Account");
                Console.WriteLine("--------------------------");
                Console.WriteLine("2.Login Parent Account ");
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
                        parent p = new parent();
                        
                        p.M_GetInfo();
                        p.M_show();
                        break;

                    case 2:

                        Console.Clear();
                        Console.WriteLine("Your choice :" + ch);
                        Loginparent lp = new Loginparent();
                        
                        lp.Checkinfo();
                        
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
