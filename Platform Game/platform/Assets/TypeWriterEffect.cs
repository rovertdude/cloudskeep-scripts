using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypeWriterEffect : MonoBehaviour {

	public float delay = 0.1f;
	public float startDelay = 0f;
	public string fullText;
	public bool showGameHS;
	public bool showTotalScore;
	public string totalGameScore;
	private string currentText = "";

	// Use this for initialization
	void Start () {
		totalGameScore = PlayerPrefs.GetString("totalGameScore");
		if (showTotalScore)
        {
			fullText = TimerScript.fullScore.ToString() + ".";
        }
		else if (showGameHS)
		{
			fullText = totalGameScore + ".";
		}
		StartCoroutine(ShowText());
	}
	
	IEnumerator ShowText(){
		yield return new WaitForSeconds(startDelay);

		for (int i = 0; i < fullText.Length; i++){
			currentText = fullText.Substring(0,i);
			this.GetComponent<Text>().text = currentText;
			yield return new WaitForSeconds(delay);
		}
	}

	public void BackToStart()
    {
		SceneManager.LoadScene(0);
	}		
}
