using UnityEngine;
using System.Collections;

public class SixteenBitEnemy : MonoBehaviour {

	//Health
	public int curHealth;
	public int maxHealth;

	public float speed = 8;
	public float min;
	public float max;
	public GameObject enemy;
	private bool dirRight = true;
	public bool leftRight;
	public Transform childTransform;

	private SixteenBitController player;
	public Animator anim;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<SixteenBitController>();
		curHealth = maxHealth;
		anim = gameObject.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (leftRight)
		{
			if (dirRight)
			{
				transform.Translate(Vector2.right * speed * Time.deltaTime);
			}
			else
			{
				transform.Translate(-Vector2.right * speed * Time.deltaTime);
			}

			if (transform.position.x >= max)
			{
				anim.SetBool ("RunningRight", false);
				dirRight = false;

			}

			if (transform.position.x <= min)
			{
				anim.SetBool ("RunningRight", true);
				dirRight = true;

			}
		}

		if(curHealth <= 0){
			Destroy (gameObject);
		}

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {

			player.Damage (1);

			if(dirRight == true){
				StartCoroutine (player.EnemyKnockback (.01f, 1200, player.transform.position)); //Must start Coroutine for IEnumerator
			} else {
				StartCoroutine (player.EnemyKnockback (.01f, -1200, player.transform.position)); //Must start Coroutine for IEnumerator
			}


		}
	}

	public void Damage(int damage){

		curHealth -= damage;
		//gameObject.GetComponent<Animation> ().Play ("Player_RedFlash");
	}
		
}

