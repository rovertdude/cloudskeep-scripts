using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypeWriterEffect : MonoBehaviour
{
	public float delay = 0.1f; // this is the delay between checks
	public float startDelay = 0f; // this is the start delay before it begins
	private bool started; // hidden variable, stops it from running multiple times over
	public string fullText; // the full message for it to type out
	private string currentText = ""; // the current message on screen
	public TextMesh tm; // this can be either Text or TextMesh based on using default text or textmeshpro

	// Use this for initialization
	void LateUpdate()
	{
		if (!started)
			StartCoroutine(ShowText());
	}

	IEnumerator ShowText()
	{
		started = true;
		yield return new WaitForSeconds(startDelay); // added in as a basic start delay - rusty

		for (int i = 0; i <= fullText.Length; i++)
		{ // the original thing uses < which cuts out the last letter, edited to <= - rusty
			currentText = fullText.Substring(0, i);// I now know what this part of the script does hooray
			tm.text = currentText;
			yield return new WaitForSeconds(delay); 
		}
	}
}
