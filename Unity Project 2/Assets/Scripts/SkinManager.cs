using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SkinManager : MonoBehaviour
{
    public Material Default;
    public static Material storedMaterial;
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
                PrefabUtility.SaveAsPrefabAsset(playerPrefab, "Assets/Prefabs/Player.prefab");
            }
        }
        if (playerBody != null)
        {
            playerBody.GetComponent<MeshRenderer>().material = playerPrefab.GetComponent<MeshRenderer>().sharedMaterial;
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
        if (playerPrefab != null)
        {
            playerPrefab.GetComponent<MeshRenderer>().material = material;
            PrefabUtility.SaveAsPrefabAsset(playerPrefab , "Assets/Prefabs/Player.prefab");
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
