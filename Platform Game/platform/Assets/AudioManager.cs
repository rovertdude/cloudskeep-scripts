using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static float volume = 0.75f;
    public GameObject rainPrefab;
    public static bool rainEnabled = true;
    public AudioSource gameOST;

    void Start()
    {
        rainPrefab = GameObject.Find("RainPrefab");

        gameOST = gameObject.GetComponent<AudioSource>();
        volume = PlayerPrefs.GetFloat("audioLevel");
        if (volume == 0)
        {
            volume = 0.75f;
        }
    }

    private void Update()
    {
        gameOST.volume = volume;
        if (!rainEnabled && rainPrefab)
        {
            gameObject.transform.SetParent(null);
            rainPrefab.SetActive(false);
        }
    }
}
