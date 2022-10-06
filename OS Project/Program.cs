using System;
using System.Text;

namespace OS_Project
{
    public static class Program
    {
        public static Directory CurrentDirectory;

        public static string Path=""; 

        public static void Main(string[] args)
        {
          
        Console.WriteLine("WELCOME TO CMD");
            Console.WriteLine("********************");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");



            // Reserve Virtual Disk Memory
            
            // Fat Table Information

            //FT.WriteFatTable();  // روحنا ندهناهم من الفيرتشوال ديسك اوريدي
            //FT.GetFatTable();

            //  char[] filename = new char[11] { 'h', 'q', 'd', 'a', 'f', 'h', 'q', 'd', 'a', 'f', 'a' };
            //  // DirectoryEntry d = new DirectoryEntry(filename, 0, 6);
            //  //d.GetDirectoryEntry(d.getByte());
            // // DirectoryEntry b = new DirectoryEntry(filename, 0, 7);
            //  //b.fun2(filename);
            //Directory a = new Directory(filename, 0, 6, null);
            //a.Write_Directory();
            //  a.ReadDirectory();

            //  Directory b = new Directory("G:".ToCharArray(), 0, 12, null);
            //  b.Write_Directory();

            // FT.PrintFatTable();
            //Console.WriteLine(FT.GetNext(124));
            //  Write Block in the Virtual Disk
            //   byte[] array = Encoding.ASCII.GetBytes("f");
            // VD.WriteBlock(array, 5);

            //Read Data From the Virtual Disk
            //  VD.GetBlock(5);            ممكن نناديها من فانكشن البرينت على طول

            // Print the Data From Virtual Disk at specific Index
            //  VD.printBlock(5);


            //  FT.getAvailableBlock();
            //  FT.getAvailableBlocks();
            //   Console.WriteLine(FT.GetNext(6));
            // FT.setNext(102,8);


            //for (int i=0;i<32; i++)
            //{
            //    Console.Write(d.getByte()[i]);
            //    Console.Write(" ");
            //}


            



            Console.WriteLine();
            Console.WriteLine("*********");

           




            Console.WriteLine();

            VirtualDisk.Intialize();
         
            CurrentDirectory = VirtualDisk.Root;
            string s = new string(CurrentDirectory.FileName);
            Path = s;

            while (true)
            {
                //Console.Write(Environment.CurrentDirectory);
                Console.Write(Path);
                Console.Write(">>");
                string Commmand = Console.ReadLine();
                Commands com = new Commands(Commmand);



            }
        }

    }
}