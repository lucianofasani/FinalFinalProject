using UnityEngine;
using System.Collections;

public class EnemyDeathCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.name == "Player")
		{
			Destroy (transform.parent.gameObject);
			other.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 300));
		}
	}
}
