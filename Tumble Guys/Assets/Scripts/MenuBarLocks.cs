using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBarLocks : MonoBehaviour
{
    public GameObject pumpkin;

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
    }
}
