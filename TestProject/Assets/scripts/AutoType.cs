// AUTHOR: unitycoder (Github user)
// SOURCE: https://gist.github.com/unitycoder/19625fed364a39cb278f#file-uitexttypewriter-cs
// BRIEF: This script was written by unitycoder and hosted on GitHub. Variable names and minor functionality were
//		  modifed by us, but the core idea is credited to unitycoder.
//
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AutoType : MonoBehaviour {

	public Text text;
	public string message;
	public AudioSource source;
	public AudioClip bleep;
	bool textRolling = true;

	void Start()
	{
		source = GetComponent<AudioSource> ();
		text = GetComponent<Text> ();
		message = text.text;
		text.text = "";
		StartCoroutine ("AutoText");
		StartCoroutine ("TextSound");
	}

	IEnumerator AutoText()
	{
		foreach (char c in message)
		{
			text.text += c;
			yield return new WaitForSeconds (0.06f);
		}
		textRolling = false;
	}

	IEnumerator TextSound()
	{
		while (textRolling) {
			yield return new WaitForSeconds (0.09f);
			source.Play ();
		}
	}
}