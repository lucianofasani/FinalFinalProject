using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinalBoss : MonoBehaviour {

	public BossState currentState;
	private int switchCount;
	private bool startBattle;
	public float speed;
	public GameObject player;
	public GameObject enemy;

	public enum BossState
	{
		IDLE,
		EVADING,
		ATTACKING,
		DEFEATED
	}

	// Use this for initialization
	void Start () {
		switchCount = 0;
		startBattle = false;
		currentState = BossState.EVADING;
		StartCoroutine ("BossFight");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator BossFight(){

		while (currentState != BossState.DEFEATED) {
			switch (currentState) {
			case BossState.IDLE:
				if (startBattle) {
					currentState = BossState.EVADING;
					enemy.GetComponent<SixteenBitEnemy> ().leftRight = true;
				}
				break;
			case BossState.EVADING:
				enemy.GetComponent<SixteenBitEnemy> ().speed = 8f;
				Evading ();
				switchCount++;
				if (switchCount == 5) {
					currentState = BossState.ATTACKING;
					switchCount = 0;
				}
				break;
			case BossState.ATTACKING:
				enemy.GetComponent<SixteenBitEnemy> ().speed = 12f;
				Attacking ();
				switchCount++;
				if (switchCount == 5) {
					currentState = BossState.EVADING;
					switchCount = 0;
				}
				break;
			}
			yield return new WaitForSeconds (3);
		}
	}
		

	void Evading()
	{
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, 1000f));
	}

	void Attacking()
	{
		//when player gets past enemy, the enemy will puruse the player
		if (player.transform.position.x > enemy.transform.position.x + 5)
		{
			transform.Translate(Vector2.right * speed * Time.deltaTime);
		}
		//otherwise, enemy keeps charging at player
		else
		{
			transform.Translate(-Vector2.right * speed * Time.deltaTime);
		}
	}
}
