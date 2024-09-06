using System;
using System.IO;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
namespace Services
{
    public class RarDecompressor: IDataDecompresser
    {
        public void Decompress(string rarFilePath, string extractToPath)
        {
            try
            {
                using (var archive = RarArchive.Open(rarFilePath))
                {
                    foreach (var entry in archive.Entries)
                    {
                        if (!entry.IsDirectory)
                        {
                            entry.WriteToDirectory(extractToPath, new SharpCompress.Common.ExtractionOptions()
                            {
                                ExtractFullPath = true,
                                Overwrite = true
                            });
                        }
                    }
                }
                Console.WriteLine("RAR file decompressed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }

}