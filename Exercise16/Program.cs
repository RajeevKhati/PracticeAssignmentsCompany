using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Exercise16
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\fileio";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            //Getting all the files
            FileInfo[] allFiles = directoryInfo.GetFiles();

            //1. Return the number of text files in the directory (*.txt).
            int numOfTxtFiles = GetNumberOfTextFiles(allFiles);
            Console.WriteLine("Number of Text files are "+numOfTxtFiles);


            //2.Return the number of files per extension type.
            IDictionary<string, int> numOfFilesPerExtensionType = GetNumberOfFilesPerExtensionType(allFiles);
            foreach(var pair in numOfFilesPerExtensionType)
            {
                Console.WriteLine($"Extension of file : {pair.Key}, Quantity: {pair.Value}");
            }

            //3.Return the top 5 largest files, along with their file size(use anonymous types).
            var top5Files = directoryInfo.GetFiles().OrderByDescending(file => file.Length).Take(5);
            Console.WriteLine("Top 5 files in length are ");
            foreach(FileInfo file in top5Files)
            {
                Console.WriteLine(file.Name);
            }
            Console.WriteLine("************");

            //4.Return the file with maximum length.
            FileInfo fileWithMaxLength = GetFileWithMaxLength(allFiles);
            Console.WriteLine("File with maximum length is " + fileWithMaxLength.Name);

        }

        private static FileInfo GetFileWithMaxLength(FileInfo[] allFiles)
        {
            FileInfo maxLenFile = allFiles[0];
            long maxLength = allFiles[0].Length;
            foreach (FileInfo file in allFiles)
            {
                if (file.Length > maxLength)
                {
                    maxLenFile = file;
                    maxLength = file.Length;
                }   
            }
            return maxLenFile;
        }

        private static IDictionary<string, int> GetNumberOfFilesPerExtensionType(FileInfo[] allFiles)
        {
            IDictionary<string, int> filesPerExtensionType = new Dictionary<string, int>();
            foreach (FileInfo file in allFiles)
            {
                if (filesPerExtensionType.ContainsKey(file.Extension))
                {
                    filesPerExtensionType[file.Extension]++;
                }
                else
                {
                    filesPerExtensionType.Add(file.Extension, 1);
                }
            }
            return filesPerExtensionType;
        }

        private static int GetNumberOfTextFiles(FileInfo[] allFiles)
        {
            int count = 0;
            foreach (FileInfo file in allFiles)
            {
                if (file.Extension.Equals(".txt"))
                    count++;
            }
            return count;
        }


    }
}
