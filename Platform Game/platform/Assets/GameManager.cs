using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // objects, triggers
    [Header("Various Objects")]
    public GameObject spawnPoint;
    public GameObject player;
    public GameObject contactPoint;
    public GameObject theTemp;
    public GameObject textObject;
    public Rigidbody rb;
    public Text TopScore;
    public GameObject pauseMenu;
    public GameObject currentPause;
    public GameObject disabledLastSpot;

    [Header("Settings")]
    public bool lastSpotAllowed = true;
    public float timePenalty = 0;
    public float penaltyIncrements = 1;
    public string highScore = "0";
    public bool debugEnabled = false;
    public static int levelsCompleted;
    public static bool adminEnabled;
    public static bool gamePaused;
    public static int difficulty = 2;
    public int lastSpotDifficulty = 4;

    public static bool forceRestart;

    void Awake()
    {
        if (difficulty >= lastSpotDifficulty)
        {
            lastSpotAllowed = false;
            Instantiate(Resources.Load("disabledText"), GameObject.Find("Canvas").transform);
        }
    }

    void Start()
    {
        textObject = GameObject.Find("toptext");
        TopScore = textObject.GetComponent<Text>();

        switch(SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                highScore = PlayerPrefs.GetString("levelOneScore");
                break;
            case 2:
                highScore = PlayerPrefs.GetString("levelTwoScore");
                break;
            case 3:
                highScore = PlayerPrefs.GetString("levelThreeScore");
                break;
            case 4:
                highScore = PlayerPrefs.GetString("levelFourScore");
                break;
            case 5:
                highScore = PlayerPrefs.GetString("levelFiveScore");
                break;
            case 6:
                highScore = PlayerPrefs.GetString("levelSixScore");
                break;
            case 7:
                highScore = PlayerPrefs.GetString("levelSevenScore");
                break;
            case 8:
                highScore = PlayerPrefs.GetString("levelEightScore");
                break;
            case 9:
                highScore = PlayerPrefs.GetString("levelNineScore");
                break;
            case 10:
                highScore = PlayerPrefs.GetString("levelTenScore");
                break;
            case 11:
                highScore = PlayerPrefs.GetString("levelElevenScore");
                break;
            case 12:
                highScore = PlayerPrefs.GetString("levelTwelveScore");
                break;
            case 13:
                highScore = PlayerPrefs.GetString("levelThirteenScore");
                break;
            case 14:
                highScore = PlayerPrefs.GetString("levelFourteenScore");
                break;
            case 15:
                highScore = PlayerPrefs.GetString("levelFifteenScore");
                break;
        }

        TopScore.text = highScore.ToString();

        spawnPoint = GameObject.Find("SpawnPoint");
        contactPoint = GameObject.Find("ContactPoint");
        player = GameObject.Find("RigidBodyFPSController");
        rb = player.GetComponent<Rigidbody>();
        theTemp = GameObject.Find("platform temp");
        if (theTemp)
        {
            print("destroying temporary object");
            Destroy(theTemp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        print("Difficulty: " + difficulty);
        penaltyIncrements = difficulty - 1;
        if (penaltyIncrements == 0)
        {
            penaltyIncrements = 0.5f;
        }
        print("Increment: " + penaltyIncrements);

        // restart when you press R
        if (Input.GetKeyDown(KeyCode.R) || forceRestart)
        {
            StartCoroutine(nameof(Restart));
        }
        else if (lastSpotAllowed && Input.GetKeyDown(KeyCode.E)) //last spot, disabled if last spot isnt allowed
        {
            StartCoroutine(nameof(LastSpot));
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gamePaused)
            {
                currentPause = Instantiate(pauseMenu, GameObject.Find("Canvas").transform);
                player.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                gamePaused = true;
            }
            else
            {
                Destroy(currentPause);
                player.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                gamePaused = false;
            }
        }

        if (player.transform.position.y <= -8)
        {
            StartCoroutine(nameof(Restart));
        }
    }

    public void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Cursor.visible = true;
            TimerScript.counting = false;
            Cursor.lockState = CursorLockMode.None;
            TimerScript.score = 0;
            TimerScript.fullScore = 0;
            levelsCompleted = 0;
            SceneManager.LoadScene("ManagementScene");
        }
    }

    IEnumerator Restart()
    {
        if (levelsCompleted == 0)
            TimerScript.fullScore = 0;

        forceRestart = false;
        player.transform.position = spawnPoint.transform.position;
        TimerScript.counting = false;
        TimerScript.score = TimerScript.originalScore;
        timePenalty = 0;
        contactPoint.transform.position = spawnPoint.transform.position;
        rb.isKinematic = true;
        yield return new WaitForSeconds(0.2f);
        rb.isKinematic = false;
    }

    IEnumerator LastSpot()
    {
        player.transform.position = contactPoint.transform.position;
        TimerScript.score += timePenalty;
        TimerScript.fullScore += timePenalty;
        timePenalty += penaltyIncrements;
        print(TimerScript.score);
        TimerScript.score = Mathf.Floor(TimerScript.score);
        TimerScript.fullScore = Mathf.Floor(TimerScript.fullScore);
        rb.isKinematic = true;
        yield return new WaitForSeconds(0.2f);
        rb.isKinematic = false;
    }
}
