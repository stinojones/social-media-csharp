using System.Collections.Generic;
using System.IO;
public class FileHandler 
{
    


        public FileHandler()
        {

        }
    // ------------------------------methods-----------------------------------
    public void SaveFile(List<string> data, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (string item in data)
            {
                writer.WriteLine(item);
            }
        }
    }
    public List<string> LoadFile(string filePath)
    {
        List<string> data = new List<string>();

        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    data.Add(line);
                }
            }
        }
        return data;
    }


    
}
