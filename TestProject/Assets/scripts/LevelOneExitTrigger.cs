using UnityEngine;
using System.Collections;

public class LevelOneExitTrigger : MonoBehaviour {

	public Font myFont;
	public GameObject exit;
	public GameObject player;
	// Use this for initialization
	void Start () {
		exit.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(){

		exit.SetActive (true);
		Destroy (gameObject);
	}
}
