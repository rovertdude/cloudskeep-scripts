using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryObject : MonoBehaviour
{
    public float destroyTime = 5f;
    public bool destroyOnStart = true;

    void Start()
    {
        StartCoroutine("Countdown");
    }

    IEnumerator Countdown()
    {
        if (destroyOnStart)
        {
            yield return new WaitForSeconds(destroyTime);
            gameObject.SetActive(false);
        }
    }
}
