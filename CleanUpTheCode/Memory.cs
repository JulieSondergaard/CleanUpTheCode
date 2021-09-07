using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanUpTheCode
{
    public class Memory
    {


        //Console.WriteLine("Total Visible Memory: {0}KB", result["TotalVisibleMemorySize"]);
        //        Console.WriteLine("Free Physical Memory: {0}KB", result["FreePhysicalMemory"]);
        //        Console.WriteLine("Total Virtual Memory: {0}KB", result["TotalVirtualMemorySize"]);
                
        private string freeVirtualMemory;
        private string totalVirtualMemorySize;
        private string freePhysicalMemory;
        private string totalVisibleMemorySize;

        public Memory(string freeVirtualMemory, string totalVirtualMemorySize, string freePhysicalMemory, string totalVisibleMemorySize)
        {
            this.freeVirtualMemory = freeVirtualMemory;
            this.totalVisibleMemorySize = totalVisibleMemorySize;
            this.freePhysicalMemory = freePhysicalMemory;
            this.totalVirtualMemorySize = totalVirtualMemorySize;



        }     

        public string FreeVirtualMemory { get => freeVirtualMemory; set => freeVirtualMemory = value; }
        public string TotalVirtualMemorySize { get => totalVirtualMemorySize; set => totalVirtualMemorySize = value; }
        public string FreePhysicalMemory { get => freePhysicalMemory; set => freePhysicalMemory = value; }
        public string TotalVisibleMemorySize { get => totalVisibleMemorySize; set => totalVisibleMemorySize = value; }
    }
}
