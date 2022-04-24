using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string SAVE_FOLDER = Application.persistentDataPath + "/GameData/";

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
    public static void Save2(string data)
    {
        File.WriteAllText(SAVE_FOLDER + "/PlayerSkin.kty", data);
    }
    public static string Load2()
    {
        if (File.Exists(SAVE_FOLDER + "/PlayerSkin.kty"))
        {
            return File.ReadAllText(SAVE_FOLDER + "/PlayerSkin.kty");
        }
        else
        {
            return null;
        }
    }

    public static bool DeleteAllData()
    {
        try{
            Directory.Delete(SAVE_FOLDER,true);
        }
        catch
        {
            return false;
        }
        return true;
    }
}
