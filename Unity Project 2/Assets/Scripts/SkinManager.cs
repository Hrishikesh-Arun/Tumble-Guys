using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SkinManager : MonoBehaviour
{
    public Material Default;
    public static Material storedMaterial;
    public GameObject playerBody, menuSkin, title;
    public List<Material> materialData;
    private string data;

    // Start is called before the first frame update
    void Start()
    {
        if (GameHandler.b == "")
        {
            data = Default.name;
        }
        else
        {
            data = SaveSystem.Load2();
        }
        storedMaterial = LoadMaterialsList(data);
        if (playerBody != null)
        {
            playerBody.GetComponent<MeshRenderer>().material = storedMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Switches the Skin of the Player
    public void SwitchSkin(Material material)
    {
        if (playerBody != null)
        {
            playerBody.GetComponent<MeshRenderer>().material = material;
        }
        SaveSystem.Save2(material.name);
    }

    // Toggle Skin Selection
    public void ToggleSkinSelection()
    {
        if (!menuSkin.activeInHierarchy)
        {
            menuSkin.SetActive(true);
            title.SetActive(false);
        }
        else
        {
            menuSkin.SetActive(false);
            title.SetActive(true);
        }
    }

    // Load List
    public Material LoadMaterialsList(string inp)
    {
        foreach (Material material in materialData)
        {
            if (material.name == inp)
            {
                return material;
            }
        }
        return null;
    }
}
