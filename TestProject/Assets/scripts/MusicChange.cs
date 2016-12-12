using UnityEngine;
using System.Collections;

public class MusicChange : MonoBehaviour {

	public AudioSource source;
	public AudioClip songToSwitch;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
			source.clip = songToSwitch;
			Destroy (gameObject);
			source.Play ();
		
	}
}
