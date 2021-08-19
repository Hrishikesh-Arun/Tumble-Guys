using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string SAVE_FOLDER = Application.dataPath + "/GameData/";

    public static void Init()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }
    public static void Save(string json)
    {
        File.WriteAllText(SAVE_FOLDER + "/gamePlay.kty", json);
    }
    public static string Load()
    {
        if (File.Exists(SAVE_FOLDER + "/gamePlay.kty"))
        {
            return File.ReadAllText(SAVE_FOLDER + "/gamePlay.kty");
        }
        else
        {
            return null;
        }
    }
}
