using UnityEngine;
using System.Collections;

public class Trampoline : MonoBehaviour {

	private SixteenBitController player;
	private Animator anim;

	void Start(){

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<SixteenBitController>();
		anim = gameObject.GetComponent<Animator> ();

	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.CompareTag ("Player")) {

			StartCoroutine (player.Bounce (.005f, 1600, player.transform.position)); //Must start Coroutine for IEnumerator

		}

		anim.SetTrigger ("Trip");

	}
}
