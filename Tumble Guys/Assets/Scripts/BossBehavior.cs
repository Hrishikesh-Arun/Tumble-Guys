using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public GameObject finish;
    public GameObject rocks;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RockLaunch());
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
                collision.gameObject.GetComponent<Rigidbody>().AddForce(0, 5, -4, ForceMode.Impulse);
            }
        }
    }

    IEnumerator RockLaunch()
    {
        while (true)
        {
            GameObject a = Instantiate(rocks, rocks.transform.position, Quaternion.identity);
            a.SetActive(true);
            float b = Random.Range(2f, 6);
            a.transform.localScale = new Vector3(b,b,b);
            yield return new WaitForSeconds(4f);
        }
    }
}
