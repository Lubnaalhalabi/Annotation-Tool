using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Services.DataManager
{
    public class Text : IText
    {
        public IEnumerable<string> Process(string folderPath)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    string[] filePaths = Directory.GetFiles(folderPath);

                    List<string> fileContents = new List<string>();

                    foreach (string filePath in filePaths)
                    {
                        string content = File.ReadAllText(filePath);
                        fileContents.Add(content);
                    }

                    return fileContents;
                }
                else
                {
                    throw new DirectoryNotFoundException($"Folder not found at path: {folderPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading folder: {ex.Message}");
                return new List<string>(); 
            }

        }
    }
}

