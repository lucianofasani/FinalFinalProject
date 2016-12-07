using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	DeathCounter deathCounter;
	public GameObject player;
	public GameObject checkpoint;

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "enemy")
		{
			player.transform.position = checkpoint.transform.position;
			deathCounter.updateCount ();
		}
	}
}
