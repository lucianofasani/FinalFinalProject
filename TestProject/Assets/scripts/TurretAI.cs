using UnityEngine;
using System.Collections;

public class TurretAI : MonoBehaviour {

	//Ints
	public int curHealth;
	public int maxHealth;

	//Floats
	public float distance; //Distance between player and turret
	public float wakeRange; //If the distance is smaller than wakeRange, turret wakes up
	public float shootInterval;
	public float bulletSpeed = 100;
	public float bulletTimer; //Turret shooting cooldown

	//Bools
	public bool awake = false;
	public bool lookingRight = false;

	//References
	public GameObject bullet;
	public Transform target;
	public Animator anim;
	public Transform shootPointLeft;
	public Transform shootPointRight;

	void Awake(){
	
		anim = gameObject.GetComponent<Animator> ();
	
	}


	void Start(){
	
		curHealth = maxHealth;

	}

	void Update(){
	
		anim.SetBool ("Awake", awake);
		anim.SetBool ("LookingRight", lookingRight);

		RangeCheck ();

		if (target.transform.position.x > transform.position.x) {
			lookingRight = true;
		} else {
			lookingRight = false;
		}

		if(curHealth <= 0){
			Destroy (gameObject);
		}



	}

	void RangeCheck(){
	
		distance = Vector3.Distance (transform.position, target.transform.position);

		if (distance < wakeRange) {
			awake = true;
		} else {
			awake = false;
		}

	}

	public void Attack(bool attackingRight){

		bulletTimer += Time.deltaTime;

		if (bulletTimer >= shootInterval) {
		
			Vector2 direction = target.transform.position - transform.position;
			direction.Normalize ();

			if (!attackingRight) {
			
				GameObject bulletClone;
				bulletClone = Instantiate (bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;
				Debug.Log ("TEST: Shoot left when in range, SUCCESS");

				bulletTimer = 0;
			} else {

				GameObject bulletClone;
				bulletClone = Instantiate (bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;
				Debug.Log ("TEST: Shoot right when in range, SUCCESS");

				bulletTimer = 0;
			
			}
				
		
		}

	}

	public void Damage(int damage){

		curHealth -= damage;
		Debug.Log ("TEST: Remove health from turret, SUCCESS");
		//gameObject.GetComponent<Animation> ().Play ("Player_RedFlash");
	}


}
