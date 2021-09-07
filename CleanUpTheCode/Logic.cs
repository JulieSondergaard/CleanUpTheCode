using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace CleanUpTheCode
{
    public class Logic
    {
        Data memory = new Data(); 
        
        public static void GetHeader()
        {
            string header = "";
            string headerSpace = "";

            for (int i = 0; i < 50; i++)
            {
                header += "=";
                if (i % 4 == 0)
                {
                    headerSpace += " ";
                }

            }
            Console.WriteLine(header);
            Console.WriteLine($"\n {headerSpace} Clean Up The Code \n ");
            Console.WriteLine(header);
        }

        public static void GetDiskMetaData()
        {
           Data.DiskMetaData();
        }

        public static void GetHardDiskSerialNumber()
        {
            Data.HardDiskSerialNumber();
        }

        public static void GetListAllServices()
        {
            Data.ListAllServices();
        }
        public List<Memory> GetMemoryInformation()
        {
            return memory.MemoryInformation();
        }

        public static void GetCpuInformation()
        {
            Data.CpuInformation();
        }
        public static string GetOrganizationInfo()
        {
            return Data.OrganizationInfo();
        }
        public static string GetBootDeviceTest()
        {
            return Data.BootDeviceTest();
        }





    }
}
