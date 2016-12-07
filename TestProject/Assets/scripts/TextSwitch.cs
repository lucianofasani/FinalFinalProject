using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextSwitch : MonoBehaviour {

	Text text;
	public string message;
	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds (15);
		text = GetComponent<Text> ();
		text.text = message;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
