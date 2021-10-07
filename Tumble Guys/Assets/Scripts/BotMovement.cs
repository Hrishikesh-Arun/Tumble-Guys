using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotMovement : MonoBehaviour
{
    [SerializeField]
    private Transform player,player2;
    private Rigidbody rbody;
    public float Timer = 120;
    private static Vector3 InitPos;

    // Start is called before the first frame update
    void Start()
    {
        InitPos = transform.position;
        rbody = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Level2" || SceneManager.GetActiveScene().name == "Level3")
        {
            BotMovements();
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                Timer -= Time.deltaTime;
                if (Timer <= 0 && player.transform.position.y > -50)
                {
                    print("Bot Wins");
                }
                else if (player.transform.position.y < -53)
                {
                    print("Bot Loses");
                    Destroy(gameObject);
                }
            }
            if (player.transform.position.y < -75)
            {
                transform.position = InitPos;
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
                player.transform.localPosition = new Vector3(0, 5, -2);
            }
        }        
    }
    void BotMovements()
    {
        Vector3 a = Vector3.Slerp(transform.position, player2.position, 0.1f * Time.deltaTime);
        transform.position = a;
        if (Random.Range(-25,1.2f) > 1)
        {
            rbody.AddForce(0,10,0,ForceMode.Impulse);
        }
    }
}
