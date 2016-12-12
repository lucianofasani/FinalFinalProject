using UnityEngine;
using System.Collections;

public class SixteenBitController : MonoBehaviour {


	public float maxSpeed = 10f;
	public float jumpForce = 700f;
	bool facingRight = true;
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public bool jump = false;
	public string message = "Power Up: Jumping acquired. Physics!";
	public float displayTime;
	public bool displayMessage = false;
	public Rigidbody2D rb2d;
	public JumpSound jumpSound;

	public int curHealth;
	public int maxHealth = 100;

	private Animator anim;

	// Use this for initialization
	void Start()
	{
		curHealth = maxHealth;
		anim = gameObject.GetComponent<Animator> ();
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate()
	{

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);


		float move = Input.GetAxis("Horizontal");

		GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		if(move > 0 && !facingRight)
		{
			Flip();
		} else if(move < 0 && facingRight)
		{
			Flip();
		}

	}

	void Update()
	{
		if (jump && grounded && Input.GetKeyDown(KeyCode.Space))
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
			jumpSound.Jump ();
		}

		//decrement the time the message stays on the screen
		displayTime -= Time.deltaTime;
		if (displayTime <= 0.0)
		{
			displayMessage = false;
		}

		if (curHealth > maxHealth) {
			curHealth = maxHealth;
		}

		if (curHealth <= 0) {
			Die ();
		}

		anim.SetBool ("Grounded", grounded);
		anim.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));


	}

	//if the player meets with a power up, flip the displayMessage to true
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Arrow2_0")
		{
			displayMessage = true;
			displayTime = 3;
		}

	}

	//display the powerup message to the user
	void OnGUI()
	{
		if (displayMessage)
		{
			GUI.Label(new Rect((Screen.width / 2)-75, (Screen.height / 2)-50, 200f, 200f), message);
		}
	}

	void Flip()//Trick for switching left and right
	{

		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}

	void Die(){

		Application.LoadLevel(Application.loadedLevel);

	}

	public void Damage(int dmg){
		curHealth -= dmg;
	}

	public void AddHealth(int health){
		curHealth += health;
	}

	public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir){

		float timer = 0;

		while (knockDur > timer) {
			timer += Time.deltaTime; //deltaTime counts in seconds

			if (Input.GetAxis ("Horizontal") < -.1f) {
				rb2d.AddForce (new Vector3 (knockbackDir.x * 50, knockbackDir.y + knockbackPwr - 200, transform.position.z));
			} else if (Input.GetAxis ("Horizontal") > .1f) {
				rb2d.AddForce (new Vector3 (knockbackDir.x * -50, knockbackDir.y + knockbackPwr - 200, transform.position.z));
			} else {
				rb2d.AddForce (new Vector3 (0, knockbackDir.y + knockbackPwr * 2, transform.position.z));
			}
	
		}
		
		yield return 0; //You must yield return "something" in IEnumerators.

	}

	public IEnumerator Bounce(float bounceDur, float bouncePwr, Vector3 bounceDir){

		float timer = 0;

		while (bounceDur > timer) {
			timer += Time.deltaTime; //deltaTime counts in seconds

			rb2d.AddForce (new Vector3 (0, bouncePwr, transform.position.z));
		}

		yield return 0;
	}

	public IEnumerator EnemyKnockback(float knockDur, float knockbackPwr, Vector3 knockbackDir){

		float timer = 0;

		while (knockDur > timer) {
			timer += Time.deltaTime; //deltaTime counts in seconds

			rb2d.AddForce (new Vector3 (knockbackPwr, 500, transform.position.z));
		}

		yield return 0;
	}

}
