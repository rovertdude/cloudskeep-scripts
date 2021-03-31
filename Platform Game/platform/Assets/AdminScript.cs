using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdminScript : MonoBehaviour
{
    public Dropdown drop;
    public InputField setScore;
    public GameObject manager;
    public GameObject levelSelector;
    public GameObject controlsMenu;
    public GameObject optionsMenu;
    public Slider audioLevel;
    public Dropdown difficulty;
    public GameObject easyText;
    public GameObject normalText;
    public GameObject hardText;
    public GameObject superText;

    void Start()
    {
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("levelOneScore")) || String.IsNullOrEmpty(PlayerPrefs.GetString("levelFifteenScore")) || String.IsNullOrEmpty(PlayerPrefs.GetString("totalGameScore")))
        {
            WipeHS();
        }

        if (GameManager.adminEnabled)
        {
            print(PlayerPrefs.GetString("levelOneScore"));
            print(PlayerPrefs.GetString("levelTwoScore"));
            print(PlayerPrefs.GetString("levelThreeScore"));
            print(PlayerPrefs.GetString("levelFourScore"));
            print(PlayerPrefs.GetString("levelFiveScore"));
            print(PlayerPrefs.GetString("levelSixScore"));
            print(PlayerPrefs.GetString("levelSevenScore"));
            print(PlayerPrefs.GetString("levelEightScore"));
            print(PlayerPrefs.GetString("levelNineScore"));
            print(PlayerPrefs.GetString("levelTenScore"));
            print(PlayerPrefs.GetString("levelElevenScore"));
            print(PlayerPrefs.GetString("levelTwelveScore"));
            print(PlayerPrefs.GetString("levelThirteenScore"));
            print(PlayerPrefs.GetString("levelFourteenScore"));
            print(PlayerPrefs.GetString("levelFifteenScore"));
        }

        if (!GameManager.adminEnabled)
        {
            manager.SetActive(false);
            levelSelector.SetActive(true);
            controlsMenu.SetActive(false);
            optionsMenu.SetActive(false);
        }
        else
        {
            levelSelector.SetActive(false);
            controlsMenu.SetActive(false);
            optionsMenu.SetActive(false);
        }
    }

    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!manager.activeInHierarchy && GameManager.adminEnabled)
            {
                manager.SetActive(true);
                levelSelector.SetActive(false);
            }
            else
            {
                manager.SetActive(false);
                levelSelector.SetActive(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.P) && GameManager.adminEnabled)
        {
            SaveBackup();
        }
        else if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            if (!GameManager.adminEnabled)
                GameManager.adminEnabled = true;
            else
                GameManager.adminEnabled = false;
        }
    }

    public void WipeHS()
    {
        print("wiped hs");
        setScore.text = "0";
        PlayerPrefs.SetString("levelOneScore", setScore.text);
        PlayerPrefs.SetString("levelTwoScore", setScore.text);
        PlayerPrefs.SetString("levelThreeScore", setScore.text);
        PlayerPrefs.SetString("levelFourScore", setScore.text);
        PlayerPrefs.SetString("levelFiveScore", setScore.text);
        PlayerPrefs.SetString("levelSixScore", setScore.text);
        PlayerPrefs.SetString("levelSevenScore", setScore.text);
        PlayerPrefs.SetString("levelEightScore", setScore.text);
        PlayerPrefs.SetString("levelNineScore", setScore.text);
        PlayerPrefs.SetString("levelTenScore", setScore.text);
        PlayerPrefs.SetString("levelElevenScore", setScore.text);
        PlayerPrefs.SetString("levelTwelveScore", setScore.text);
        PlayerPrefs.SetString("levelThirteenScore", setScore.text);
        PlayerPrefs.SetString("levelFourteenScore", setScore.text);
        PlayerPrefs.SetString("levelFifteenScore", setScore.text);
        PlayerPrefs.SetString("totalGameScore", setScore.text);

        print(PlayerPrefs.GetString("levelOneScore"));
        print(PlayerPrefs.GetString("levelTwoScore"));
        print(PlayerPrefs.GetString("levelThreeScore"));
        print(PlayerPrefs.GetString("levelFourScore"));
        print(PlayerPrefs.GetString("levelFiveScore"));
        print(PlayerPrefs.GetString("levelSixScore"));
        print(PlayerPrefs.GetString("levelSevenScore"));
        print(PlayerPrefs.GetString("levelEightScore"));
        print(PlayerPrefs.GetString("levelNineScore"));
        print(PlayerPrefs.GetString("levelTenScore"));
        print(PlayerPrefs.GetString("levelElevenScore"));
        print(PlayerPrefs.GetString("levelTwelveScore"));
        print(PlayerPrefs.GetString("levelThirteenScore"));
        print(PlayerPrefs.GetString("levelFourteenScore"));
        print(PlayerPrefs.GetString("levelFifteenScore"));
        print(PlayerPrefs.GetString("totalGameScore"));
        PlayerPrefs.Save();
    }

    public void SetHS()
    {
        switch (drop.value)
        {
            case 0:
                PlayerPrefs.SetString("levelOneScore", setScore.text);
                print(PlayerPrefs.GetString("levelOneScore"));
                break;
            case 1:
                PlayerPrefs.SetString("levelTwoScore", setScore.text);
                print(PlayerPrefs.GetString("levelTwoScore"));
                break;
            case 2:
                PlayerPrefs.SetString("levelThreeScore", setScore.text);
                print(PlayerPrefs.GetString("levelThreeScore"));
                break;
            case 3:
                PlayerPrefs.SetString("levelFourScore", setScore.text);
                print(PlayerPrefs.GetString("levelFourScore"));
                break;
            case 4:
                PlayerPrefs.SetString("levelFiveScore", setScore.text);
                print(PlayerPrefs.GetString("levelFiveScore"));
                break;
            case 5:
                PlayerPrefs.SetString("levelSixScore", setScore.text);
                print(PlayerPrefs.GetString("levelSixScore"));
                break;
            case 6:
                PlayerPrefs.SetString("levelSevenScore", setScore.text);
                print(PlayerPrefs.GetString("levelSevenScore"));
                break;
            case 7:
                PlayerPrefs.SetString("levelEightScore", setScore.text);
                print(PlayerPrefs.GetString("levelEightScore"));
                break;
            case 8:
                PlayerPrefs.SetString("levelNineScore", setScore.text);
                print(PlayerPrefs.GetString("levelNineScore"));
                break;
            case 9:
                PlayerPrefs.SetString("levelTenScore", setScore.text);
                print(PlayerPrefs.GetString("levelTenScore"));
                break;
            case 10:
                PlayerPrefs.SetString("levelElevenScore", setScore.text);
                print(PlayerPrefs.GetString("levelElevenScore"));
                break;
            case 11:
                PlayerPrefs.SetString("levelTwelveScore", setScore.text);
                print(PlayerPrefs.GetString("levelTwelveScore"));
                break;
            case 12:
                PlayerPrefs.SetString("levelThirteenScore", setScore.text);
                print(PlayerPrefs.GetString("levelThirteenScore"));
                break;
            case 13:
                PlayerPrefs.SetString("levelFourteenScore", setScore.text);
                print(PlayerPrefs.GetString("levelFourteenScore"));
                break;
            case 14:
                PlayerPrefs.SetString("levelFifteenScore", setScore.text);
                print(PlayerPrefs.GetString("levelFifteenScore"));
                break;
            case 15:
                PlayerPrefs.SetString("levelOneScore", setScore.text);
                PlayerPrefs.SetString("levelTwoScore", setScore.text);
                PlayerPrefs.SetString("levelThreeScore", setScore.text);
                PlayerPrefs.SetString("levelFourScore", setScore.text);
                PlayerPrefs.SetString("levelFiveScore", setScore.text);
                PlayerPrefs.SetString("levelSixScore", setScore.text);
                PlayerPrefs.SetString("levelSevenScore", setScore.text);
                PlayerPrefs.SetString("levelEightScore", setScore.text);
                PlayerPrefs.SetString("levelNineScore", setScore.text);
                PlayerPrefs.SetString("levelTenScore", setScore.text);
                PlayerPrefs.SetString("levelElevenScore", setScore.text);
                PlayerPrefs.SetString("levelTwelveScore", setScore.text);
                PlayerPrefs.SetString("levelThirteenScore", setScore.text);
                PlayerPrefs.SetString("levelFourteenScore", setScore.text);
                PlayerPrefs.SetString("levelFifteenScore", setScore.text);
                break;
            case 16:
                PlayerPrefs.SetString("totalGameScore", setScore.text);
                print(PlayerPrefs.GetString("totalGameScore"));
                break;
        }
        print("set hs");
        PlayerPrefs.Save();
    }

    void SaveBackup()
    {
        PlayerPrefs.SetString("levelOneScoreB", PlayerPrefs.GetString("levelOneScore"));
        PlayerPrefs.SetString("levelTwoScoreB", PlayerPrefs.GetString("levelTwoScore"));
        PlayerPrefs.SetString("levelThreeScoreB", PlayerPrefs.GetString("levelThreeScore"));
        PlayerPrefs.SetString("levelFourScoreB", PlayerPrefs.GetString("levelFourScore"));
        PlayerPrefs.SetString("levelFiveScoreB", PlayerPrefs.GetString("levelFiveScore"));
        PlayerPrefs.SetString("levelSixScoreB", PlayerPrefs.GetString("levelSixScore"));
        PlayerPrefs.SetString("levelSevenScoreB", PlayerPrefs.GetString("levelSevenScore"));
        PlayerPrefs.SetString("levelEightScoreB", PlayerPrefs.GetString("levelEightScore"));
        PlayerPrefs.SetString("levelNineScoreB", PlayerPrefs.GetString("levelNineScore"));
        PlayerPrefs.SetString("levelTenScoreB", PlayerPrefs.GetString("levelTenScore"));
        PlayerPrefs.SetString("levelElevenScoreB", PlayerPrefs.GetString("levelElevenScore"));
        PlayerPrefs.SetString("levelTwelveScoreB", PlayerPrefs.GetString("levelTwelveScore"));
        PlayerPrefs.SetString("levelThirteenScoreB", PlayerPrefs.GetString("levelThirteenScore"));
        PlayerPrefs.SetString("levelFourteenScoreB", PlayerPrefs.GetString("levelFourteenScore"));
        PlayerPrefs.SetString("levelFifteenScoreB", PlayerPrefs.GetString("levelFifteenScore"));
        print("saved backup");
        PlayerPrefs.Save();
    }

    public void LoadBackup()
    {
        PlayerPrefs.SetString("levelOneScore", PlayerPrefs.GetString("levelOneScoreB"));
        PlayerPrefs.SetString("levelTwoScore", PlayerPrefs.GetString("levelTwoScoreB"));
        PlayerPrefs.SetString("levelThreeScore", PlayerPrefs.GetString("levelThreeScoreB"));
        PlayerPrefs.SetString("levelFourScore", PlayerPrefs.GetString("levelFourScoreB"));
        PlayerPrefs.SetString("levelFiveScore", PlayerPrefs.GetString("levelFiveScoreB"));
        PlayerPrefs.SetString("levelSixScore", PlayerPrefs.GetString("levelSixScoreB"));
        PlayerPrefs.SetString("levelSevenScore", PlayerPrefs.GetString("levelSevenScoreB"));
        PlayerPrefs.SetString("levelEightScore", PlayerPrefs.GetString("levelEightScoreB"));
        PlayerPrefs.SetString("levelNineScore", PlayerPrefs.GetString("levelNineScoreB"));
        PlayerPrefs.SetString("levelTenScore", PlayerPrefs.GetString("levelTenScoreB"));
        PlayerPrefs.SetString("levelElevenScore", PlayerPrefs.GetString("levelElevenScoreB"));
        PlayerPrefs.SetString("levelTwelveScore", PlayerPrefs.GetString("levelTwelveScoreB"));
        PlayerPrefs.SetString("levelThirteenScore", PlayerPrefs.GetString("levelThirteenScoreB"));
        PlayerPrefs.SetString("levelFourteenScore", PlayerPrefs.GetString("levelFourteenScoreB"));
        PlayerPrefs.SetString("levelFifteenScore", PlayerPrefs.GetString("levelFifteenScoreB"));
        print("loaded backup");
        PlayerPrefs.Save();

        print(PlayerPrefs.GetString("levelOneScore"));
        print(PlayerPrefs.GetString("levelTwoScore"));
        print(PlayerPrefs.GetString("levelThreeScore"));
        print(PlayerPrefs.GetString("levelFourScore"));
        print(PlayerPrefs.GetString("levelFiveScore"));
        print(PlayerPrefs.GetString("levelSixScore"));
        print(PlayerPrefs.GetString("levelSevenScore"));
        print(PlayerPrefs.GetString("levelEightScore"));
        print(PlayerPrefs.GetString("levelNineScore"));
        print(PlayerPrefs.GetString("levelTenScore"));
        print(PlayerPrefs.GetString("levelElevenScore"));
        print(PlayerPrefs.GetString("levelTwelveScore"));
        print(PlayerPrefs.GetString("levelThirteenScore"));
        print(PlayerPrefs.GetString("levelFourteenScore"));
        print(PlayerPrefs.GetString("levelFifteenScore"));
    }

    public void LoadLevel(int levelNumber)
    {
        print(levelNumber);

        SceneManager.LoadScene(levelNumber);
    }

    public void EnableOptions()
    {
        levelSelector.SetActive(false);
        optionsMenu.SetActive(true);
        ChangeDifficulty();
    }

    public void DisableOptions()
    {
        levelSelector.SetActive(true);
        optionsMenu.SetActive(false);
    }
    
    public void EnableControls()
    {
        levelSelector.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void DisableControls()
    {
        levelSelector.SetActive(true);
        controlsMenu.SetActive(false);
    }

    public void ChangeAudioLevel()
    {
        AudioManager.volume = audioLevel.value;
        PlayerPrefs.SetFloat("audioLevel", audioLevel.value);
    }

    public void ChangeDifficulty()
    {
        GameManager.difficulty = difficulty.value + 1;
        print(GameManager.difficulty);
        print(difficulty.value);

        switch (difficulty.value)
        {
            case 0:
                {
                    easyText.SetActive(true);
                    normalText.SetActive(false);
                    hardText.SetActive(false);
                    superText.SetActive(false);
                    break;
                }
            case 1:
                {
                    easyText.SetActive(false);
                    normalText.SetActive(true);
                    hardText.SetActive(false);
                    superText.SetActive(false);
                    break;
                }
            case 2:
                {
                    easyText.SetActive(false);
                    normalText.SetActive(false);
                    hardText.SetActive(true);
                    superText.SetActive(false);
                    break;
                }
            case 3:
                {
                    easyText.SetActive(false);
                    normalText.SetActive(false);
                    hardText.SetActive(false);
                    superText.SetActive(true);
                    break;
                }
        }
    }
}
