using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	public GameObject title;
	public Color newColor;
	Color oldColor;
	// Use this for initialization
	void Start () {
		oldColor = title.GetComponent<Text> ().color;
		StartCoroutine ("FlashText");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return))
		{
			SceneManager.LoadScene ("IntroScene");
			SceneManager.UnloadScene ("Title Screen");
		}
	}

	IEnumerator FlashText(){

		while (true) {
			yield return new WaitForSeconds (0.3f);
			title.GetComponent<Text> ().color = newColor;
			yield return new WaitForSeconds (0.3f);
			title.GetComponent<Text> ().color = oldColor;
		}
	}
}
