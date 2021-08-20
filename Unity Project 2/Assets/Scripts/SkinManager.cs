using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public Material Default;
    public GameObject playerBody,menuSkin,title,playerPrefab;

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
