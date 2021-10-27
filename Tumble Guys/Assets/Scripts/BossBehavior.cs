using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public GameObject finish;

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
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Player.hasCrystal)
            {
                finish.SetActive(true);
                Destroy(gameObject);
            }
            else
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(0, 10, -4, ForceMode.Impulse);
            }
        }
    }
}
