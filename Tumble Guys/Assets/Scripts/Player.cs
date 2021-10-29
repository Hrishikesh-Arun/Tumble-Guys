using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static bool hasCrystal = false;

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish Line"))
        {
            StartCoroutine(WaitForWin());
        }
        if (collision.gameObject.CompareTag("PlatformToBeDestroyed"))
        {
            StartCoroutine(WaitForDestroy(collision.gameObject));
        }
        if (gameObject.tag == "Player")
        {
            PlayerMovement.jumpAmount = 0;
        }
        if (collision.gameObject.CompareTag("PTBD2"))
        {
            StartCoroutine(WaitForDestroy2(collision.gameObject));
        }
        if (collision.gameObject.tag == "Portal")
        {
            GameHandler.SaveData(1000, GameHandler.b, 3);
            SceneManager.LoadScene("Level4");
        }
        if (collision.gameObject.tag == "Potal2")
        {
            GameHandler.SaveData(-100, GameHandler.b, 0);
            SceneManager.LoadScene("Level1");
        }

        if (collision.gameObject.name == "Crystal")
        {
            collision.gameObject.SetActive(false);
            hasCrystal = true;
        }
    }

    IEnumerator WaitForWin()
    {
        PlayerMovement.AnimateMovement = true;
        yield return new WaitForSeconds(4);
        PlayerMovement.IfWon = true;
    }

    IEnumerator WaitForDestroy(GameObject platform)
    {
        yield return new WaitForSeconds(2);
        Destroy(platform);
    }
    IEnumerator WaitForDestroy2(GameObject platform)
    {
        yield return new WaitForSeconds(0.25f);
        platform.SetActive(false);
        yield return new WaitForSeconds(1f);
        platform.SetActive(true);
    }
}
