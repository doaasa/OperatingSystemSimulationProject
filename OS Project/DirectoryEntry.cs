﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OS_Project
{
    public class DirectoryEntry
    {
        //fields
       public  char[] FileName = new char[11];
        public byte fileAttribute;
        public  byte[] fileEmpty = new byte[12];
        public int fileSize;
        public int firstCluster;
       public DirectoryEntry( char[] fileName, byte fileAttribute, int FirstCluster, int fileSize)
        {
            //
            string s = new string(fileName);
            if (fileName.Length < 11)
            {
                for (int i = fileName.Length; i < 11; i++)
                    s += (char)' ';
            }
            this.FileName = s.ToCharArray();
           this.fileAttribute = fileAttribute;
           this.firstCluster = FirstCluster;
            this.fileSize = fileSize;
            for (int i = 0; i < fileEmpty.Length; i++)
            {
                fileEmpty[i] = 0;
            }
        }
        //public void fun2(char [] arr)   // للتأكيد
        //{
        //    byte[] ConvertFileNametoBYTE1 = Encoding.Unicode.GetBytes(arr);//convert array of char to array of byte
        //    for(int i=0; i<ConvertFileNametoBYTE1.Length;i++)
        //    {
        //        Console.Write(ConvertFileNametoBYTE1[i] + " | ");
        //    }
        //    byte[] arr2 = new byte[11];
        //    int l = 0;
        //    for (int i = 0; i < 11; i++)
        //    {
        //        arr2[i] = ConvertFileNametoBYTE1[l]; // خزنا اسم الفايل جوه الاراى
        //        l = l + 2; // لأن الشار فى السى شارب بتأخد 2 كاركتر فكنت بعمل سكيب للصفر علشان اخد بس الحرف اللى متخزن
        //    }
        //    Console.WriteLine();
        //    for (int i = 0; i <arr2.Length; i++)
        //    {
        //        Console.Write(arr2[i] + " | ");
        //    }

        //}
        public byte[] getByte()
        {
            byte[] ConvertFileNametoBYTE = Encoding.ASCII.GetBytes(FileName);//convert array of char to array of byte
            byte[] DirEntryarray = new byte[32];  // عملنا اراى كبيرة من نوع بايت تخزن كل الداتا بتاعت الانتريز
            byte[] arr2 = new byte[(ConvertFileNametoBYTE.Length)];
            int l = 0;
            for (int i = 0; i < ConvertFileNametoBYTE.Length; i++)
            {
                DirEntryarray[i] = ConvertFileNametoBYTE[l]; // خزنا اسم الفايل جوه الاراى
                l++;// لأن الشار فى السى شارب بتأخد 2 كاركتر فكنت بعمل سكيب للصفر علشان اخد بس الحرف اللى متخزن
            }

            //byte[] ConvertFileNametoBYTE = Encoding.Unicode.GetBytes(FileName);//convert array of char to array of byte
            //byte[] DirEntryarray = new byte[32];  // عملنا اراى كبيرة من نوع بايت تخزن كل الداتا بتاعت الانتريز
            //byte[] arr2 = new byte[(ConvertFileNametoBYTE.Length)];
            //int l = 0;
            //for (int i = 0; i < ConvertFileNametoBYTE.Length; i++)
            //{
            //    arr2[i] = ConvertFileNametoBYTE[l]; // خزنا اسم الفايل جوه الاراى
            //    l++;// لأن الشار فى السى شارب بتأخد 2 كاركتر فكنت بعمل سكيب للصفر علشان اخد بس الحرف اللى متخزن
            //}

            //for (int i = 0; i < arr2.Length; i++)
            //{
            //    DirEntryarray[i] = arr2[i];
            //}
            DirEntryarray[11] = fileAttribute;  // حطيت الاتريبيوت هو فايل ولا فولدر 1أو 0

            int j = 0;
            for (int i = 12; i < 24; i++)
            {
                DirEntryarray[i] = fileEmpty[j];  // خزنت الداتا بتاعت الفايل ايمبتى فى الاراى
                j++;
            }

            int c = 0;
            byte[] CovnINTtoBYTE_firstcluster = BitConverter.GetBytes(firstCluster);//convert int to array of byte
            // لأن الفيرست كلاستر من نوع انتيجير وانا عايزة اخليه 4 بايتات فعملت اراى علشان اخزنه
            for (int i = 24; i < 28; i++)
            {
                //DirEntry[i] = Convert.ToByte(firstCluster);
                DirEntryarray[i] = CovnINTtoBYTE_firstcluster[c];
                c++;
            }

            int k = 0;
            byte[] CovnINTtoBYTE_size = BitConverter.GetBytes(fileSize);//convert int to array of byte
            // لأن الفايل سايز من نوع انتيجير وانا عايزة اخليه 4 بايتات فعملت اراى علشان اخزنه
            for (int i = 28; i < 32; i++)
            {
                DirEntryarray[i] = CovnINTtoBYTE_size[k];
                k++;
            }

            return DirEntryarray;
        }

        //public void fun(byte []b)  // فانكشن للتأكيد انه بيحول الرقم مظبوط
        //{

        //    int FClu = BitConverter.ToInt32(b, 24);

        //    Console.WriteLine(FClu);

        //}
        public DirectoryEntry GetDirectoryEntry(byte[] b) //فانكشن لتحويل من الاراى اوف بايت للديركتورى انترى
        {
            char[] char11_FileName = new char[11];  // اراى اوف كاركتر لتخزين الفايل نيم
            byte[] First11byte_filename = new byte[11]; // علشان يقرأ البايتات بتاعت الفايل نيم
           
            for (int i = 0; i < 11; i++)
            {
                First11byte_filename[i] = b[i]; // بيقرأ البايتات من الاراى اللى راجعة
            }
            for (int i = 0; i < First11byte_filename.Length; i++)
            {
                char11_FileName[i] = Convert.ToChar(First11byte_filename[i]); // بيحولها لكاركتر وبيخزنها فى اراى
            }
            byte fileatt = b[11]; // خزن الفايل اتريبيوت

            byte[] FileEmpty = new byte[12]; // عمل اراى اوف بايت علشان يقرأ بايتات الاراى القديمة
            int j = 0;
            for (int i = 12; i < 24; i++)
            {
                FileEmpty[j] = b[i]; // خزن من الاراى القديمة وحطها فى الاراى القديمة
                j++;
            }
            int index = 0;
            byte[] Fcluster = new byte[4]; // علشان يقرأ الفيرست كلاستر
            for (int i=24;i<28; i++)
            {
                Fcluster[index] = b[i]; // خزن الفيرست كلاستر فى الاراى
                index++;
            }
            int FClu = BitConverter.ToInt32(Fcluster);  // خزن الفيرست كلاستر فى متغير انتيجير
            int indexSize = 0;
            byte[] FSize = new byte[4];
            for (int i = 28; i < 32; i++)
            {
                FSize[indexSize] = b[i]; // قرأ الفايل سايز فى اراى
                indexSize++;
            }
            int FileSizeNew = BitConverter.ToInt32(FSize);  //خزن السايز فى رقم انتيجر
            DirectoryEntry a = new DirectoryEntry(char11_FileName, fileatt, FClu,FileSizeNew); //عمل متغير من الكلاس علشان يبعتله الداتا
            a.fileEmpty = FileEmpty;
            return a;

        }

        public DirectoryEntry GetDirectoryEntry() //فانكشن لتحويل من الاراى اوف بايت للديركتورى انترى
        {

            DirectoryEntry a = new DirectoryEntry(FileName, fileAttribute, firstCluster, fileSize); //عمل متغير من الكلاس علشان يبعتله الداتا
            a.fileEmpty = fileEmpty;
            return a;

        }

    }
}
