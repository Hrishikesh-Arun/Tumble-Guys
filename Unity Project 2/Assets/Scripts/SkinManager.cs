using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    //public Material Default, Chocolate, Cyan, Pinky;
    public GameObject playerBody,menuSkin,title;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Switches the Skin of the Player
    public void SwitchSkin(Material material)
    {
        playerBody.GetComponent<MeshRenderer>().material = material;
    }

    // Switches the Skin of the Player
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
