using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

	public GameObject enemy;
	public int startDirection;
	public Vector3 position;
	public Quaternion rotation;
	public int spawnTime;

	void Start () {
		InvokeRepeating ("Spawn", 1, spawnTime);
	}

	// Update is called once per frame
	void Update () {

	}

	void Spawn()
	{
		enemy.GetComponent<EnemyScript> ().direction = startDirection;
		Instantiate (enemy, position, rotation);
	}
}
