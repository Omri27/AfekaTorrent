using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FreeFile.DownloadManager
{
    public static class FileUtility
    {
        
        const int FiePartsize = 10240;
        public static string FindFileByHash(string path,string fileName ,string hash)
        {
            var files = Directory.GetFiles(Config.SharedFolder, fileName, SearchOption.AllDirectories);
            foreach (var item in files)
            {
                SHA512 sha512 = SHA512.Create();
                using (FileStream fstream = new FileStream(item, FileMode.Open, FileAccess.Read))
                {
                    var computedhash = sha512.ComputeHash(fstream);                    
                    if (string.Compare(BitConverter.ToString(computedhash, 0), hash, true)==0)
                    {
                        return item;
                    }
                }    
            }
            return null;
        }

        

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
