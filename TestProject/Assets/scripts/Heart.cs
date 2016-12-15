using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour {

	private SixteenBitController player;

	void Start(){

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<SixteenBitController>();

	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.CompareTag ("Player")) {

			player.AddHealth (1);
			Debug.Log ("TEST: Pick up heart, SUCCESS");
			Destroy (gameObject);


		}

	}

}
