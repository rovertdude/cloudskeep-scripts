using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAudioLevel : MonoBehaviour
{
    public GameObject button;
    public Text buttonText;

    private void Awake()
    {
        Slider audioLevel = gameObject.GetComponent<Slider>();
        audioLevel.value = AudioManager.volume;
        PlayerPrefs.SetFloat("audioLevel", AudioManager.volume);
        button = GameObject.Find("RainButton");
        buttonText = GameObject.Find("RainText").GetComponent<Text>();
    }
    public void AudioLevel()
    {
        Slider audioLevel = gameObject.GetComponent<Slider>();
        AudioManager.volume = audioLevel.value;
        PlayerPrefs.SetFloat("audioLevel", audioLevel.value);
    }

    public void ToggleRain()
    {
        if (AudioManager.rainEnabled)
        {
            buttonText.text = "Disabled!";
            AudioManager.rainEnabled = false;
        }
    }
}
