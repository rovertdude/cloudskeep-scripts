using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public static float score = 0f;
    public static bool counting;
    public static bool onFinalLevel = false;
    public Text timer;
    public GameObject player;
    public static float fullScore = 0;
    public static float originalScore = 0;
    public float startPoint = 34.5f;
    public float endPoint = 333;
    public static string highScore;
    public static int scoreInt;
    public GameObject textObject;
    public Text bottomText;

    public void Start()
    {
        textObject = GameObject.Find("bottomtext");
        bottomText = textObject.GetComponent<Text>();
        StartCoroutine(Time());
        player = GameObject.Find("RigidBodyFPSController");
        timer = GameObject.Find("Text").GetComponent<Text>();
    }

    void Update()
    {
        timer.text = score.ToString();
        bottomText.text = fullScore.ToString();

        if (!counting && player.transform.position.x > startPoint)
        {
            counting = true;
        }
        else if (player.transform.position.x >= endPoint)
        {
            counting = false;
            originalScore = score;

            if (GameManager.difficulty >= 2)
                SetHighScore(score);

            score = 0;
            originalScore = 0;
            GameManager.levelsCompleted += 1;
            print(GameManager.levelsCompleted);
            if (GameManager.levelsCompleted == 14)
                onFinalLevel = true;

            PlayerPrefs.Save();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            counting = false;
            originalScore = score;
            score = 0;
            originalScore = 0;
            GameManager.levelsCompleted += 1;
            print(GameManager.levelsCompleted);
            PlayerPrefs.Save();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator Time()
    {
        while (true)
        {
            if (counting && !GameManager.gamePaused)
                TimeCount();
            yield return new WaitForSeconds(1f);
        }
    }
    void TimeCount()
    {
        score += 1;
        fullScore += 1;
    }

    void SetHighScore(float currentScore)
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                highScore = PlayerPrefs.GetString("levelOneScore");
                scoreInt = System.Convert.ToInt32(highScore);
                if (currentScore < scoreInt || scoreInt == 0)
                {
                    PlayerPrefs.SetString("levelOneScore", currentScore.ToString());
                }
                break;
            case 2:
                highScore = PlayerPrefs.GetString("levelTwoScore");
                scoreInt = System.Convert.ToInt32(highScore);
                if (currentScore < scoreInt || scoreInt == 0)
                {
                    PlayerPrefs.SetString("levelTwoScore", currentScore.ToString());
                }
                break;
            case 3:
                highScore = PlayerPrefs.GetString("levelThreeScore");
                scoreInt = System.Convert.ToInt32(highScore);
                if (currentScore < scoreInt || scoreInt == 0)
                {
                    PlayerPrefs.SetString("levelThreeScore", currentScore.ToString());
                }
                break; 
            case 4:
                highScore = PlayerPrefs.GetString("levelFourScore");
                scoreInt = System.Convert.ToInt32(highScore);
                if (currentScore < scoreInt || scoreInt == 0)
                {
                    PlayerPrefs.SetString("levelFourScore", currentScore.ToString());
                }
                break;
            case 5:
                highScore = PlayerPrefs.GetString("levelFiveScore");
                scoreInt = System.Convert.ToInt32(highScore);
                if (currentScore < scoreInt || scoreInt == 0)
                {
                    PlayerPrefs.SetString("levelFiveScore", currentScore.ToString());
                }
                break;
            case 6:
                highScore = PlayerPrefs.GetString("levelSixScore");
                scoreInt = System.Convert.ToInt32(highScore);
                if (currentScore < scoreInt || scoreInt == 0)
                {
                    PlayerPrefs.SetString("levelSixScore", currentScore.ToString());
                }
                break;
            case 7:
                highScore = PlayerPrefs.GetString("levelSevenScore");
                scoreInt = System.Convert.ToInt32(highScore);
                if (currentScore < scoreInt || scoreInt == 0)
                {
                    PlayerPrefs.SetString("levelSevenScore", currentScore.ToString());
                }
                break;
            case 8:
                highScore = PlayerPrefs.GetString("levelEightScore");
                scoreInt = System.Convert.ToInt32(highScore);
                if (currentScore < scoreInt || scoreInt == 0)
                {
                    PlayerPrefs.SetString("levelEightScore", currentScore.ToString());
                }
                break;
            case 9:
                highScore = PlayerPrefs.GetString("levelNineScore");
                scoreInt = System.Convert.ToInt32(highScore);
                if (currentScore < scoreInt || scoreInt == 0)
                {
                    PlayerPrefs.SetString("levelNineScore", currentScore.ToString());
                }
                break;
            case 10:
                highScore = PlayerPrefs.GetString("levelTenScore");
                scoreInt = System.Convert.ToInt32(highScore);
                if (currentScore < scoreInt || scoreInt == 0)
                {
                    PlayerPrefs.SetString("levelTenScore", currentScore.ToString());
                }
                break;
            case 11:
                highScore = PlayerPrefs.GetString("levelElevenScore");
                scoreInt = System.Convert.ToInt32(highScore);
                if (currentScore < scoreInt || scoreInt == 0)
                {
                    PlayerPrefs.SetString("levelElevenScore", currentScore.ToString());
                }
                break;
            case 12:
                highScore = PlayerPrefs.GetString("levelTwelveScore");
                scoreInt = System.Convert.ToInt32(highScore);
                if (currentScore < scoreInt || scoreInt == 0)
                {
                    PlayerPrefs.SetString("levelTwelveScore", currentScore.ToString());
                }
                break;
            case 13:
                highScore = PlayerPrefs.GetString("levelThirteenScore");
                scoreInt = System.Convert.ToInt32(highScore);
                if (currentScore < scoreInt || scoreInt == 0)
                {
                    PlayerPrefs.SetString("levelThirteenScore", currentScore.ToString());
                }
                break;
            case 14:
                highScore = PlayerPrefs.GetString("levelFourteenScore");
                scoreInt = System.Convert.ToInt32(highScore);
                if (currentScore < scoreInt || scoreInt == 0)
                {
                    PlayerPrefs.SetString("levelFourteenScore", currentScore.ToString());
                }
                break;
            case 15:
                highScore = PlayerPrefs.GetString("levelFifteenScore");
                scoreInt = System.Convert.ToInt32(highScore);
                if (currentScore < scoreInt || scoreInt == 0)
                {
                    PlayerPrefs.SetString("levelFifteenScore", currentScore.ToString());
                }

                if (onFinalLevel)
                {
                    highScore = PlayerPrefs.GetString("totalGameScore");
                    scoreInt = System.Convert.ToInt32(highScore);
                    if (fullScore < scoreInt || scoreInt == 0)
                    {
                        PlayerPrefs.SetString("totalGameScore", fullScore.ToString());
                    }
                }
                break;
        }
    }
}
