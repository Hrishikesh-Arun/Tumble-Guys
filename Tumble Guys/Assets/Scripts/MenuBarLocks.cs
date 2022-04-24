using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBarLocks : MonoBehaviour
{
    public List<GameObject> skinLock;
    public List<int> skinUnlockLevel;
    public List<int> skinUnlockScore;
    public GameObject pumpkin,glow;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy == true)
        {
            int klock = 0;
            int kunlocklevel = 0;
            int kunlockscore = 0;
            foreach (GameObject skin in skinLock)
            {
                foreach (int level in skinUnlockLevel)
                {
                    if (klock == kunlocklevel)
                    {
                        foreach (int score in skinUnlockScore)
                        {
                            if (kunlocklevel == kunlockscore)
                            {
                                if (GameHandler.a >= level)
                                {
                                    if (GameHandler.c >= score)
                                    {
                                        skin.SetActive(true);
                                    }
                                    else
                                    {
                                        skin.SetActive(false);
                                    }
                                }
                                else
                                {
                                    skin.SetActive(false);
                                }
                            }
                            kunlockscore+=1;
                        }
                        kunlockscore = 0;
                    }
                    kunlocklevel += 1;
                }
                klock += 1;
                kunlocklevel = 0;
            }
        }
    }
}
