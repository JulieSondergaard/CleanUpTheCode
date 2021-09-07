using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Threading;


namespace CleanUpTheCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic memory = new Logic();
            Data text = new Data();
            // Calling the header from Logic class.
            Logic.GetHeader();
            
            // Menu
            Console.WriteLine("\nWhich data do you want to see?\n");
            Console.WriteLine("1. Get Disk Meta Data.\n");
            Console.WriteLine("2. Get Harddisk Serial Number.\n");
            Console.WriteLine("3. Get Information about the CPU.\n");
            Console.WriteLine("4. Get Memory Information.\n");
            Console.WriteLine("5. Get Information about the User, Organization and OS.\n");
            Console.WriteLine("6. Run Boot Device Test.\n");
            Console.WriteLine("7. List All Services.\n");

            //Getting the user input.
            int menuInput = int.Parse(Console.ReadLine());

            // Switch cases giving the opportunity to enter the specific data you want to get a look at.
            switch (menuInput)
            {
                case 1:
                    {
                        Logic.GetDiskMetaData();
                        break;
                    }
                case 2:
                    {
                        Logic.GetHardDiskSerialNumber();
                        break;
                    }
                case 3:
                    {
                        Logic.GetCpuInformation();
                        break;
                    }
                case 4:
                    {
                        foreach (Memory m in memory.GetMemoryInformation())
                        {
                            Console.WriteLine("Free Virtual Memory: {0}KB", m.FreeVirtualMemory);
                            Console.WriteLine("Total Virtual Memory: {0}KB", m.TotalVirtualMemorySize);
                            Console.WriteLine("Free Physical Memory: {0}KB", m.FreePhysicalMemory);                         
                            Console.WriteLine("Total Visible Memory: {0}KB", m.TotalVisibleMemorySize);
                        }

                        break;
                    }
                case 5:
                    {
                        PrintToConsole(Logic.GetOrganizationInfo());
                        break;
                    }
                case 6:
                    {
                        
                        PrintToConsole(Logic.GetBootDeviceTest());
                        break;
                    }
                case 7:
                    {
                        Logic.GetListAllServices();
                        break;
                    }
            }
  
            Console.ReadKey();

        } //Slut main

        public static void PrintToConsole(string text)
        {
            Console.WriteLine(text);
        }
    }
}
