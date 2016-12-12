using UnityEngine;
using System.Collections;

public class LevelOneExitTrigger : MonoBehaviour {

	public GameObject exit;
	// Use this for initialization
	void Start () {
		exit.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator OnCollisionEnter2D(){
		
		yield return new WaitForSeconds(5f);
		exit.SetActive (true);
		Destroy (gameObject);



	}
}
