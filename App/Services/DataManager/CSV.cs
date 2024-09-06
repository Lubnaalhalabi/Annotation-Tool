using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DataManager
{
    public class CSV : ICSV
    {
        public IEnumerable<string> Process(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath); // Read all lines of the CSV

                    List<string> fileContents = new List<string>(); // Create a list to store file contents

                    foreach (string line in lines)
                    {
                        fileContents.Add(line);
                    }

                    Console.WriteLine("CSV file processed successfully.");
                    return fileContents; // Return the list of file contents
                }
                else
                {
                    Console.WriteLine("Invalid or non-existent CSV file path.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing CSV file: {ex.Message}");
            }

            return Enumerable.Empty<string>(); // Return an empty enumerable in case of an error or invalid file
        }


    }
}