using System;
using System.IO;

namespace Supermercado
{
    internal class LogLocal
    {
        private readonly string logFilePath;

        public LogLocal()
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            Directory.CreateDirectory(folderPath);
            logFilePath = Path.Combine(folderPath, "log.txt");
        }

        public void RegistrarLog(string errorMessage)
        {
            try
            {
                string logEntry = $"{DateTime.Now:dd-MM-yyyy HH:mm:ss} - LOG: {errorMessage}";
                File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar o log: " + ex.Message);
            }
        }
    }
}
