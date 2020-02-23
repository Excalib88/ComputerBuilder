using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuilder.BL.Parser
{
    public class FileLoader
    {
        private string FilePath;

        public FileLoader(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException("Путь к файлу пустой", nameof(filePath));
            }
            FilePath = filePath;
        }

        public async Task<string> Load()
        {
            string source = null;
            try
            {
                using (StreamReader sr = new StreamReader(FilePath, Encoding.Default))
                {
                    source = await sr.ReadToEndAsync();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return source;
        }
    }
}
