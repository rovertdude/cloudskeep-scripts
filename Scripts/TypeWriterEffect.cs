using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypeWriterEffect : MonoBehaviour
{

	public float delay = 0.1f;
	public float startDelay = 0f;
	public bool started;
	public string fullText;
	private string currentText = "";
	public TextMesh tm;

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
			currentText = fullText.Substring(0, i);// I do not know how this part of the script works at all but it does - rusty
			tm.text = currentText;
			yield return new WaitForSeconds(delay);
		}
	}
}
