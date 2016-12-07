using UnityEngine;
using System.Collections;

public class JumpSound : MonoBehaviour {

	public AudioSource source;
	public AudioClip jump1;
	public AudioClip jump2;
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
		
	// Update is called once per frame
	void Update () {
		
	}

	public void Jump(){
		source.Play ();
	}
}
