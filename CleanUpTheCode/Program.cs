﻿using System;
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
                        Data.GetDiskMetaData();
                        break;
                    }
                case 2:
                    {
                        Data.GetHardDiskSerialNumber();
                        break;
                    }
                case 3:
                    {
                        Logic.GetCpuInformation();
                        break;
                    }
                case 4:
                    {
                        Logic.GetMemoryInformation();
                        break;
                    }
                case 5:
                    {
                        Logic.GetOrganizationInfo();
                        break;
                    }
                case 6:
                    {
                        Logic.BootDeviceTest();
                        break;
                    }
                case 7:
                    {
                        Logic.ListAllServices();
                        break;
                    }
            }
  
            Console.ReadKey();

        } //Slut main
    }
}
