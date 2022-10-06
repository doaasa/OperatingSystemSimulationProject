using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OS_Project
{
    public static class FatTable
    {
        public static int[] arr=new int[1024];
        public static string FileName = "OS.txt";
       //static FatTable()
       // {
       //     arr = new int[1024];
       //     arr[0] = -1; //superblock
       //     arr[1] = -1;   // data fat table
       //     arr[2] = -1;
       //     arr[3] = -1;
       //     arr[4] = -1;
       //     for (int i = 5; i < 1024; i++)
       //     {
       //         arr[i] = 0;
       //     }
       // }
         public  static  void initaltizeFat()
        {
           // arr = new int[1024];
            arr[0] = -1; //superblock
            arr[1] = -1;   // data fat table
            arr[2] = -1;
            arr[3] = -1;
            arr[4] = -1;
            for (int i = 5; i < 1024; i++)
            {
                arr[i] = 0;
            }
        }

        public static void WriteFatTable()

        {
            using (FileStream file = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                var seek = file.Seek(1024, SeekOrigin.Begin);
                var arrayAfterEdit = new byte[1024 * 4];
                Buffer.BlockCopy(arr, 0, arrayAfterEdit, 0, 1024);
                file.Write(arrayAfterEdit);
                file.Close();
            }
        }
        public static void GetFatTable()
        {
          //  FatTable.initaltizeFat();
            using (FileStream file = new FileStream(FileName, FileMode.Open, FileAccess.ReadWrite))
            {
                file.Seek(1024, SeekOrigin.Begin);
                byte[] buffer = new byte[4096];
                file.Read(buffer, 0, buffer.Length);
                int[] retArr = new int[1024];
                Buffer.BlockCopy(buffer, 0, arr, 0, buffer.Length);
                file.Close();
               // return retArr;
            }
        }
        public static int getAvailableBlocks()
        {
            int counter = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    counter++;
                }
            }
            return counter;
        }
        public static int getAvailableBlock()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    return i;
                }
            }
            return 1;
        }

        public static int GetNext(int index)
        {
            return arr[index];
        }
        public static void setNext(int value, int Index) 
        {
            arr[Index] = value;
        }
        static public int FreeSpaces()
        {
            int free = FatTable.getAvailableBlocks() * 1024;
            return free;
        }
       //static public void PrintFatTable()
       // {
       //     for (int i = 0; i < GetFatTable().Length; i++)
       //     {
       //         Console.Write(GetFatTable()[i]);
       //     }

       //     Console.WriteLine();
       // }
    }

}
