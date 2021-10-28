using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBarLocks : MonoBehaviour
{
    public GameObject pumpkin,glow;

    // Update is called once per frame
    void Update()
    {
        if (GameHandler.a >= 1)
        {
            pumpkin.SetActive(true);
        }
        else
        {
            pumpkin.SetActive(false);
        }

        if (GameHandler.a >= 2)
        {
            glow.SetActive(true);
        }
        else
        {
            glow.SetActive(false);
        }
    }
}
