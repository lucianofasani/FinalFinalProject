using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	private SixteenBitController player;

	void Start(){
	
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<SixteenBitController>();

	}

	void OnTriggerEnter2D(Collider2D col){
	
		if (col.CompareTag ("Player")) {
			
			player.Damage (1);

			StartCoroutine (player.Knockback (.01f, 800, player.transform.position)); //Must start Coroutine for IEnumerator

		}

	}

}
