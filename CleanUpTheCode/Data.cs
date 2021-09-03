using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace CleanUpTheCode
{
    public class Data
    {

        public static void DiskMetaData()
        {

            ManagementScope managementScope = new ManagementScope();

            ObjectQuery objectQuery = new ObjectQuery("select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3");

            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(managementScope, objectQuery);

            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();

            foreach (ManagementObject managementObject in managementObjectCollection)

            {

                Console.WriteLine("Disk Name : " + managementObject["Name"].ToString());

                Console.WriteLine("FreeSpace: " + managementObject["FreeSpace"].ToString());

                Console.WriteLine("Disk Size: " + managementObject["Size"].ToString());

                Console.WriteLine("---------------------------------------------------");

            }

        }

        public static string HardDiskSerialNumber(string drive = "C")

        {

            ManagementObject managementObject = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + ":\"");

            managementObject.Get();
            Console.WriteLine(managementObject["VolumeSerialNumber"].ToString());

            return managementObject["VolumeSerialNumber"].ToString();

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

        public static void MemoryInformation()
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

        public static void CpuInformation()
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


        public static string OrganizationInfo()
        {
            string text = "";

            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();
            foreach (ManagementObject result in results)
            {
                text += "User:\t" + result["RegisteredUser"];
                //Console.WriteLine("User:\t{0}", result["RegisteredUser"]);
                text += "\nOrg.:\t" + result["Organization"];
                //Console.WriteLine("Org.:\t{0}", result["Organization"]);
                text += "\nO/S :\t" + result["Name"];
                //Console.WriteLine("O/S :\t{0}", result["Name"]);
            }
            return text;
        }
        public static string BootDeviceTest()
        {
            string returntext = "";

            returntext += "Boot Device Test\n";
                    
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
                returntext += "BootDevice : " + m["BootDevice"];              
                


            }
            returntext += "\nBoot Device Test Slut\n";


            return returntext;
        }
    }
}
