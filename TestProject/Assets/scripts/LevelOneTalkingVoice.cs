using UnityEngine;
using System.Collections;

public class LevelOneTalkingVoice : MonoBehaviour {

	public AudioSource source;
	public AudioClip beep;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		source.Play ();
	}

	// Update is called once per frame
	void Update () {
	}
}
