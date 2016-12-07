using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour {

	Text text;
	int deathCount = 0;
	public string message;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		message = deathCount.ToString ();
		text.text = "DC • " + message;
	}

	public void updateCount()
	{
		deathCount++;
	}
}
