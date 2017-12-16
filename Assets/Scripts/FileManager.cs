using System.IO;
using UnityEngine;

public class FileManager
{
    private static FileManager instance;
    public static FileManager GetInstance()
    {
        if (instance == null)
            instance = new FileManager();
        return instance;
    }

    private FileManager()
    {
    }

    public void RewriteIntInFile(int value, string filePath)
    {
        CreateNewFile(filePath);
        //FileStream file = File.OpenWrite(filePath);
        //TextWriter writer = new StreamWriter(Stream.Synchronized(file));
        //TextWriter writer = new StreamWriter(filePath);
        File.WriteAllLines(filePath, new string[1] { value.ToString() });
        /*writer.WriteLine(value);
            writer.Close();
            file.Close();*/
    }

    public int? ReadFromFile(string filePath)
    {
        // FileStream file = File.OpenRead(filePath);
        //TextReader reader = new StreamReader(Stream.Synchronized(file));
        //TextReader reader = new StreamReader(filePath);
        string[] res = File.ReadAllLines(filePath);
        int? result = null;
        try
        {
            result = int.Parse(res[0]);
        }
        catch
        {

        }
        finally
        {
            //reader.Close();
            //file.Close();
        }
        return result;
    }

    public void CreateIfNotExist(string filePath)
    {
        FileStream file = File.Open(filePath, FileMode.OpenOrCreate);
        file.Close();
    }

    private void CreateNewFile(string filePath)
    {
        FileStream file = File.Open(filePath, FileMode.Create);
        file.Close();
    }
}