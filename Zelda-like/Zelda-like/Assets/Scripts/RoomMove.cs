using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraMin;
    public Vector2 cameraMax;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    private bool titleCardActive;
    public string placeName;
    public GameObject text;
    public Text placeText;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPosition = cameraMin;
            cam.maxPosition = cameraMax;
            other.transform.position += playerChange;

            if (needText)
            {
                if (titleCardActive)
                {
                    StopAllCoroutines();
                    text.SetActive(false);
                    text.SetActive(true);
                }
                StartCoroutine(nameof(placeNameCo));
            }
        }
    }

    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        titleCardActive = true;
        yield return new WaitForSeconds(4.0f);
        titleCardActive = false;
        text.SetActive(false);
    }
}
