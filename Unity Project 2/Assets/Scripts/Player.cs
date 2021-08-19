using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
