using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public Text stars,playerN;
	public InputField playerN2;
    public GameObject NameSelector,Panel;
    private static GameObject Panel4;
    public static int a;
    public static string b;

    // Start is called before the first frame update
    void Awake()
    {
        SaveSystem.Init();
		if (SaveSystem.Load() != null)
        {
			SaveObject saveObject = JsonUtility.FromJson<SaveObject>(SaveSystem.Load());
			a = saveObject.level;
        }
        if (SceneManager.GetActiveScene().name == "Level2" || SceneManager.GetActiveScene().name == "Level3" || SceneManager.GetActiveScene().name == "Level1")
        {
            PlayerMovement.IfWon = false;
            PlayerMovement.AnimateMovement = false;
        }
        else if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Panel4 = Panel;
            if (SaveSystem.Load() == null)
            {
                SaveData(0, "", 0);
            }
            a = LoadData(stars,playerN);
            if (b.Length <= 0)
            {
                NameSelector.SetActive(true);
            }
            SaveData(0,b,a);
            LoadData(stars,playerN);
        }
    }

    public static void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public static void SwitchSceneFromData()
    {
        if (a < 3)
        {
            SceneManager.LoadScene("Level" + (a + 1));
        }
        else
        {
            Panel4.SetActive(true);
        }
    }

    public static void SaveData(int starAmount , string playerName , int level)
    {
        string loadString = SaveSystem.Load();
		print(loadString);
        if (loadString != null)
        {
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(loadString);
            saveObject = new SaveObject { stars = saveObject.stars + starAmount, name = playerName, level = level };
            string json = JsonUtility.ToJson(saveObject);
            SaveSystem.Save(json);
        }
        else
        {
            SaveObject saveObject = new SaveObject { stars = 0 + starAmount, name = playerName, level = level };
            string json = JsonUtility.ToJson(saveObject);
            SaveSystem.Save(json);
        }
    }
    public static int LoadData(Text text, Text playerName)
    {
        string saveString = SaveSystem.Load();
        if (saveString != null)
        {
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            text.text = "Stars: " + saveObject.stars;
            playerName.text = saveObject.name;
            b = saveObject.name;
            return saveObject.level;
        }
        else
        {
            return 0;
        }
    }

    public void reload()
    {
        b = playerN2.text;
        NameSelector.SetActive(false);
        SaveData(0, b, a);
        LoadData(stars, playerN);
    }

    private class SaveObject
    {
        public int stars;
        public string name;
        public int level;
    }
}
