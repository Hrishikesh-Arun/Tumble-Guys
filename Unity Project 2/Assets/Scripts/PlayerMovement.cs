using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Transform followMe,player;
    [SerializeField]
    private GameObject qe,nextLevel,eb,jumper,st;
    [SerializeField]
    private Text TimeLeft;
    private Rigidbody rbody;
    public static bool IfWon = false;
    public static bool IfLose = false;
    public static bool AnimateMovement = false;
    public static bool NextLevelHasBegun = false;
    public float Timer = 120;
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR && UNITY_STANDALONE_WIN
        if (jumper != null)
        {
            joystick.gameObject.SetActive(false);
            jumper.SetActive(false);
            st.SetActive(false);
        }
#elif UNITY_ANDROID
        if (jumper != null)
        {
            joystick.gameObject.SetActive(true);
            jumper.SetActive(true);
            st.SetActive(true);
        }
#endif
        rbody = player.GetComponent<Rigidbody>();
        if (SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Level2" || SceneManager.GetActiveScene().name == "Level3")
        {
            qe.SetActive(false);
            eb.SetActive(false);
            nextLevel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Level2" || SceneManager.GetActiveScene().name == "Level3")
        {
            if (IfWon != true)
            {
                PlayerMovements();
                if (AnimateMovement)
                {
                    followMe.Rotate(0, 2f, 0);
                    qe.SetActive(true);
                }
            }
            else
            {
                qe.SetActive(false);
                RotatePlayerCam();
                nextLevel.SetActive(true);
                GameHandler.SaveData(10,GameHandler.b,GameHandler.a + 1);
            }
            if (NextLevelHasBegun)
            {
                nextLevel.SetActive(false);
                NextLevelHasBegun = false;
            }
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                Timer -= Time.deltaTime;
                TimeLeft.text = "Time Left:\n" + (int)(Timer/60) + ":" + (int)(Timer%60);
                if (Timer <= 0 && player.transform.position.y > -50)
                {
                    StartCoroutine(WaitForWin());
                    TimeLeft.text = "";
                }
                else if (player.transform.position.y < -53 && IfWon!= true)
                {
                    eb.SetActive(true);
                    StartCoroutine(WaitForLose());
                }
            }
            if (IfLose == true)
            {
                eb.SetActive(false);
            }
            if (player.transform.position.y < -75)
            {
                transform.position = Vector3.zero;
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
                player.transform.localPosition = new Vector3(0, 5, -2);
            }
        }
    }
    void PlayerMovements()
    {
        float x = 0;
        float z = 0;
#if UNITY_EDITOR && UNITY_STANDALONE_WIN
        x = Input.GetAxis("Horizontal") / 10;
        z = Input.GetAxis("Vertical") / 10;
#elif UNITY_ANDROID
        x = joystick.Horizontal / 6;
        z = joystick.Vertical / 6;
#endif
        RotatePlayerCam();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            z *= 2f;
            x *= 2f;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StandUp();
        }
        transform.Translate(x, 0, z);
    }
    IEnumerator WaitForWin()
    {
        AnimateMovement = true;
        yield return new WaitForSeconds(4);
        IfWon = true;
    }
    IEnumerator WaitForLose()
    {
        yield return new WaitForSeconds(4);
        GameHandler.SwitchScene("Level3Lose");
    }

    public void Jump()
    {
        rbody.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
    }
    public void StandUp()
    {
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void RotatePlayerCam()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            followMe.Rotate(0, 0.5f, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            followMe.Rotate(0, -0.5f, 0);
        }
    }
}
