using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace CleanUpTheCode
{
    public static class Logic
    {

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

        public static void GetMemoryInformation()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();

            foreach (ManagementObject result in results)
            {
                Console.WriteLine("Total Visible Memory: {0}KB", result["TotalVisibleMemorySize"]);
                Console.WriteLine("Free Physical Memory: {0}KB", result["FreePhysicalMemory"]);
                Console.WriteLine("Total Virtual Memory: {0}KB", result["TotalVirtualMemorySize"]);
                Console.WriteLine("Free Virtual Memory: {0}KB", result["FreeVirtualMemory"]);
            }

        }

        public static void GetCpuInformation() 
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");
            foreach (ManagementObject obj in searcher.Get())
            {
                var usage = obj["PercentProcessorTime"];
                var name = obj["Name"];
                Console.WriteLine(name + " : " + usage);
                Console.WriteLine("CPU");
            }
        }

            
    public static void GetOrganizationInfo()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();
            foreach (ManagementObject result in results)
            {
                Console.WriteLine("User:\t{0}", result["RegisteredUser"]);
                Console.WriteLine("Org.:\t{0}", result["Organization"]);
                Console.WriteLine("O/S :\t{0}", result["Name"]);
            }

        }
        public static void BootDeviceTest()
        {
            Console.WriteLine("Boot Device Test");
            ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\cimv2");

            // Create object query.
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");

            // Create object searcher.
            ManagementObjectSearcher searcher =
                                    new ManagementObjectSearcher(scope, query);

            // Get a collection of WMI objects.
            ManagementObjectCollection queryCollection = searcher.Get();

            // Enumerate the collection.
            foreach (ManagementObject m in queryCollection)
            {
                // Access properties of the WMI object.
                Console.WriteLine("BootDevice : {0}", m["BootDevice"]);

            }
            Console.WriteLine("Boot Device Test slut");


        }

        public static void ListAllServices()
        {
            ManagementObjectSearcher windowsServicesSearcher = new ManagementObjectSearcher("root\\cimv2", "select * from Win32_Service");
            ManagementObjectCollection objectCollection = windowsServicesSearcher.Get();

            Console.WriteLine("There are {0} Windows services: ", objectCollection.Count);

            foreach (ManagementObject windowsService in objectCollection)
            {
                PropertyDataCollection serviceProperties = windowsService.Properties;
                foreach (PropertyData serviceProperty in serviceProperties)
                {
                    if (serviceProperty.Value != null)
                    {
                        Console.WriteLine("Windows service property name: {0}", serviceProperty.Name);
                        Console.WriteLine("Windows service property value: {0}", serviceProperty.Value);
                    }
                }
                Console.WriteLine("---------------------------------------");
            }
        }



    }
}
