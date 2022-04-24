using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    public GameObject areyousure,deletecomplete,deletefailed;
    public void DeleteStep1()
    {
        areyousure.SetActive(true);
    }

    public void DeleteData()
    {
        areyousure.SetActive(false);
        bool a = SaveSystem.DeleteAllData();
        if (a) deletecomplete.SetActive(true);
        else deletefailed.SetActive(true);
    }
}
