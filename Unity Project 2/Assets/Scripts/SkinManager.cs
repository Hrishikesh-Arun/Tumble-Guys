using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinManager : MonoBehaviour
{
    public Material Default;
    public static Material storedMaterial,storedMaterial2;
    public GameObject playerBody, menuSkin, title, playerPrefab;
    public List<Material> materialData;

    // Start is called before the first frame update
    void Start()
    {
        if (GameHandler.b == "")
        {
            if (playerPrefab != null)
            {
                playerPrefab.GetComponent<MeshRenderer>().material = Default;
            }
        }
        if (playerBody != null)
        {
            playerBody.GetComponent<MeshRenderer>().material = playerPrefab.GetComponent<MeshRenderer>().sharedMaterial;
        }
        if (SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "Level3")
        {
            string load = SaveSystem.Load2();
            print(load);

            if (load != null)
            {
                foreach (Material material in materialData)
                {
                    if (material.name == load)
                    {
                        playerBody.GetComponent<MeshRenderer>().material = material;
                        playerPrefab.GetComponent<MeshRenderer>().material = material;
                    }
                }
            }
            else
            {
                playerBody.GetComponent<MeshRenderer>().material = Default;
                playerPrefab.GetComponent<MeshRenderer>().material = Default;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            string load = SaveSystem.Load2();

            if (load != null)
            {
                foreach (Material material in materialData)
                {
                    if (material.name == load)
                    {
                        storedMaterial2 = material;
                    }
                }
            }
            else
            {
                storedMaterial2 = Default;
            }
        }
        else
        {
            storedMaterial2 = playerPrefab.GetComponent<MeshRenderer>().sharedMaterial;
        }
        storedMaterial = playerPrefab.GetComponent<MeshRenderer>().sharedMaterial;
        if (storedMaterial.name != storedMaterial2.name)
        {
            storedMaterial = storedMaterial2;
            playerPrefab.GetComponent<MeshRenderer>().material = storedMaterial;
        }
        SaveSystem.Save2(storedMaterial.name);
    }

    // Switches the Skin of the Player
    public void SwitchSkin(Material material)
    {
        if (playerBody != null)
        {
            playerBody.GetComponent<MeshRenderer>().material = material;
        }
        if (playerPrefab != null)
        {
            playerPrefab.GetComponent<MeshRenderer>().material = material;
        }
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
}
