﻿using System;
using System.IO;

namespace DownloadManager
{
    public static class FileUtility
    {
        
        const int FiePartsize = 10240;
       

        

        public static byte[] ReadFilePart(string fileFulePath, long partNumber, long partCount, long mod)
        {
            try
            {
                using (FileStream fstream = new FileStream(fileFulePath, FileMode.Open, FileAccess.Read))
                {
                    if (partNumber != partCount)
                    {
                        byte[] data = new byte[10240];
                        //data = File.ReadAllBytes(fileFulePath);
                        //fstream.Seek(partNumber * FiePartsize, SeekOrigin.Begin);
                        fstream.Seek((partNumber - 1) * FiePartsize, SeekOrigin.Begin);
                        fstream.Read(data, 0, FiePartsize);
                        return data;
                    }else
                    {
                        if (mod > 0)
                        {
                            byte[] data = new byte[mod];
                            //data = File.ReadAllBytes(fileFulePath);
                            //fstream.Seek(partNumber * FiePartsize, SeekOrigin.Begin);
                            fstream.Seek((partNumber - 1) * FiePartsize, SeekOrigin.Begin);
                            fstream.Read(data, 0, (int)mod);

                            return data;
                        }else
                        {
                            byte[] data = new byte[10240];
                            //data = File.ReadAllBytes(fileFulePath);
                            //fstream.Seek(partNumber * FiePartsize, SeekOrigin.Begin);
                            fstream.Seek((partNumber - 1) * FiePartsize, SeekOrigin.Begin);
                            fstream.Read(data, 0, FiePartsize);
                            return data;
                        }
                    }
                    // return data;
                }
            }
            catch(Exception ex)
            {

                return null;
            }
        }
    }
}
