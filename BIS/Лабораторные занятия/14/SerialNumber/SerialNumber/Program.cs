using System;
using System.Management;
using System.Reflection;

namespace SerialNumber
{
    public class Program
    {
        public const string PATH = @"D:\7sem\BIS\Лабораторные занятия\14\SerialNumber\SerialNumber\bin\Debug";
        public const string ComputerName= @"DESKTOP-EFEPIJA\\Roman";
        public const string SerialNumber = "BFEBFBFF000A0652";
        public static void Main(string[] args)
        {
            if (!SecurityCheck())
            {
                Console.WriteLine("Hello, redish! Go to Hell, ифин!");
                return;
            }

            if (args.Length != 1) return;

            if (args[0] == "DRD6656")
            {
                Console.WriteLine("ДОБРЕ ДОШЛИ");
                return;
            }

            Console.WriteLine("Go to sleep!");
            return;
        }

        public static bool SecurityCheck() =>
            CurrentComputerName() != ComputerName && 
            CurrentPath().Equals(PATH) && 
            GetSerialNumber() != SerialNumber;

        private static string CurrentComputerName()
        {
            var mbs = new ManagementObjectSearcher("Select * From Win32_processor");
            var processorid = string.Empty;
            foreach (var mo in mbs.Get())
                processorid = mo["ProcessorID"].ToString();

            return processorid;
        }

        private static string GetSerialNumber() =>
            System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        private static string CurrentPath()
        {
            var path = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            var index = 0;
            for (int i = 0; i < path.Length; i++)
                if (path[i] == '\\')
                    index = i;

            return path.Substring(0, index);
        }
    }
}
