﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace OS_Project
{
    public static class VirtualDisk
    {

        static public string FileName = "Os.txt";
        public static byte[] super = Encoding.ASCII.GetBytes("0");
        public static byte[] bytes = Encoding.ASCII.GetBytes("#");
        public static byte[] Data = Encoding.ASCII.GetBytes("*");
        public static int position = 0;
        public static Directory Root;
        public static void Intialize()
        {
            if (!File.Exists(FileName))
            {
                using (FileStream file = new FileStream(FileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    for (int i = 0; i < 1024; i++)
                    {
                        file.Write(super);
                        position++;
                    }

                    file.Seek(position, SeekOrigin.Begin);
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 1024; j++)
                        {
                            file.Write(bytes);
                            position++;
                        }
                    }
                    file.Seek(position, SeekOrigin.Begin);

                    for (int i = 0; i < 1019; i++)
                    {
                        for (int j = 0; j < 1024; j++)
                        {
                            file.Write(Data);
                            position++;
                        }
                    }
                    file.Close();
                }
                FatTable.initaltizeFat();
                Root = new Directory("H:".ToCharArray(), 1, 5,0, null);
                //Root.DirectoryTable.Add(Root);     ///!!!!!!!!!!!!!!!!!
                Root.Write_Directory();
                FatTable.WriteFatTable();
            }
            else
            {
                FatTable.GetFatTable();
                Root = new Directory("H:".ToCharArray(), 1, 5,0, null);
                //Root.DirectoryTable.Add(Root);  //!!!!!!!!!!!!!!!!!!!!!!
                // Root.Write_Directory();
                Root.ReadDirectory();
                FatTable.WriteFatTable();
               
            }
        }

        static public void WriteBlock(byte[] BlockData, int Fatindex)
        {
            string fileName = "OS.txt";
            using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                file.Seek(Fatindex * 1024, SeekOrigin.Begin);
                file.Write(BlockData, 0, BlockData.Length);
                file.Close();
            }
            //for (int i = 0; i < BlockData.Length; i++)
            //{
            //    Console.WriteLine(BlockData[i]);
            //    Console.WriteLine("done dodo");
            //}
        }

        static public byte[] GetBlock(int index)
        {
            string FileName = "OS.txt";
            byte[] TheReturnData = new byte[1024];
            FileStream file = File.OpenRead(FileName);
            file.Seek(index * 1024, SeekOrigin.Begin);
            file.Read(TheReturnData, 0, TheReturnData.Length);
            file.Close();
            return TheReturnData;
        }
        //static public void printBlock(int index)
        //{
        //    for (int i = 0; i < 1024; i++)
        //    {
        //        Console.Write((char)GetBlock(index)[i]);
        //    }
        //}
    }

}
