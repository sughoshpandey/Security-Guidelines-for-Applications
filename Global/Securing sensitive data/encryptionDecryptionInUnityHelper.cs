using UnityEngine;
using System.Security.Cryptography;

public class encryptionDecryptionUnityHelper :  MonoBehaviour {

    private string folderPath => Path.Combine(Application.persistentDataPath, "TextFiles"); //add subdirectory with system.variable (optional)  / Can also add absolute path(not recommended)
    private string filePath => Path.Combine(folderPath, "hash.txt"); // add your filename

    // get hash string
    static string CalculateMD5(string filename)
    {
        using (var md5 = MD5.Create())
        {
            using (var stream = File.OpenRead(filename))
            {
                var hash = md5.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }
    }

    // create file and write hash
    public void SaveDataToTextFile()
    {
        if(!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        if(File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        using(var fs = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
        {
            using(war writer = new StreamWriter(fs))
            {
                writer.Write(CalculateMD5(<TOKEN_IN_FILE>));
            }
        }

        ReadSavedData();
    }


    // read hash from file
    public void ReadSavedData()
    {
        if(!File.Exists(filePath)) return;

        using(var fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            using(var reader = new StreamReader(fs))
            {
                var fileContent = savedData.ReadToEnd();
                var lines = fileContent.Split(new char[] { '\n' });

                foreach(var line in lines)
                {
                    var savedDataString = line.Split(new char[] { '\n' });
                    txtField.text = string.Join("\n", savedDataString.Skip(1));
                }
            }
        }   
    }

    
}