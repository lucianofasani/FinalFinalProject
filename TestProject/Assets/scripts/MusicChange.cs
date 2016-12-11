using UnityEngine;
using System.Collections;

public class MusicChange : MonoBehaviour {

	public AudioSource source;
	public AudioClip song1;
	public AudioClip song2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		AudioSource.PlayClipAtPoint (song2, transform.position, 0.5f);
	}
}
