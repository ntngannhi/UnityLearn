using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//static: not instantiate this class
public static class SaveSystem 
{ 
    //Save folder
    //Application of data path is instantiated at runtime
    //therefore it cannot be a constant > change const > static readonly
    //we have essentially a constant but that is set on runtime
    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    
    
    //initialize this save system
    public static void Init()
    {
        //Test if Save folder exists
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static void Save(string saveString)
    {
        int saveNumber = 1;
        while (File.Exists(SAVE_FOLDER + "save" + saveNumber + ".txt"))
        {
            saveNumber++;
        }
        File.WriteAllText(SAVE_FOLDER + "save" + saveNumber + ".txt", saveString);
    }

    public static string Load()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] saveFiles = directoryInfo.GetFiles("*.txt");
        FileInfo mostRecentFile = null;
        foreach (var fileInfo in saveFiles)
        {
            if (mostRecentFile == null)
            {
                mostRecentFile = fileInfo;
            }
            else
            {
                if (fileInfo.LastWriteTime > mostRecentFile.LastWriteTime)
                {
                    mostRecentFile = fileInfo;
                }
            }
        }

        if (mostRecentFile != null)
        {
            string saveString = File.ReadAllText(mostRecentFile.FullName);
            return saveString;
        }
        else
        {
            return null;
        }
    }
}
