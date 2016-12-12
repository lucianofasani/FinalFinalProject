using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {

	public GameObject title;
	public Color newColor;
	Color oldColor;
	// Use this for initialization
	void Start () {
		oldColor = title.GetComponent<Text> ().color;
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator FlashText(){
		yield return new WaitForSeconds (0.3f);
		title.GetComponent<Text> ().color = newColor;
		yield return new WaitForSeconds (0.3f);
		title.GetComponent<Text> ().color = oldColor;
	}
}
