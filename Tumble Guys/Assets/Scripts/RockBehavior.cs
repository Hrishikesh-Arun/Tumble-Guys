using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -100)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlatformToBeDestroyed"))
        {
            StartCoroutine(WaitForDestroy(collision.gameObject));
        }
    }
    IEnumerator WaitForDestroy(GameObject platform)
    {
        yield return new WaitForSeconds(1);
        Destroy(platform);
    }
}
