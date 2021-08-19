using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPhysics : MonoBehaviour
{
    public bool platformRotPart,platformYRot, platformYRot2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (platformRotPart)
        {
            transform.Rotate(-0.25f,0,0);
        }
        if (platformYRot)
        {
            transform.Rotate(0, -1, 0);
        }
        if (platformYRot2)
        {
            transform.Rotate(0, -4, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (platformYRot)
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(0, 15, 0, ForceMode.Impulse);
            }
        }
    }
}
