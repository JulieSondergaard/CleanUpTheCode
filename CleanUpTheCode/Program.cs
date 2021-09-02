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
            Data.GetDiskMetadata();
            Data.GetHardDiskSerialNumber();           
            Logic.Cpu();
            Logic.HovedLager();
            Logic.Test();
            Logic.Testhest();
            Console.WriteLine("Process søgning");
            Logic.ListAllServices();

            Console.ReadKey();

        } //Slut main
    }
}
