using System.Diagnostics;
using Business.Interfaces;


namespace Buisness.Services
{
    public class FileService : IFileService
    {
        private readonly string _directoryPath;
        private readonly string _filePath;       
        

        public FileService(string fileName )
        {
            _directoryPath = "Data";
            _filePath = Path.Combine(_directoryPath, fileName);
            
            
        }


        public bool SaveContentToFile(string content)
        {
           try
            {
                if (!Directory.Exists(_directoryPath))
                    Directory.CreateDirectory(_directoryPath);
                                

                File.WriteAllText(_filePath, content);
                return true;
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public string LoadContentFromFile()
        {         
            
                if (File.Exists(_filePath))
                    return File.ReadAllText(_filePath);

                return null!;              
            
            
        }       

    
    }
}
