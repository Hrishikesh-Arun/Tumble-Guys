using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
