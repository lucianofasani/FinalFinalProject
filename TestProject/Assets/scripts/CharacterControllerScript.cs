using UnityEngine;
using System.Collections;

public class CharacterControllerScript : MonoBehaviour {


    public float maxSpeed = 10f;
    public float jumpForce = 700f;
    bool facingRight = true;
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public bool jump = false;
    public Font myFont;
    public string message;
    public float displayTime;
    public bool displayMessage = false;
	public JumpSound jumpSound;
    public bool displayMessage2 = false;
	public bool displayMessage3 = false;
	public bool displayMessage4 = false;

	private Animator anim;

    // Use this for initialization
    void Start()
    {
		anim = gameObject.GetComponent<Animator> ();
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
			displayMessage3 = false;
			displayMessage4 = false;
        }

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
        if(other.name == "Arrow3_0")
        {
            displayMessage2 = true;
            displayTime = 3;
        }
		if (other.tag == "PhysicsUpgrade") {
			displayMessage3 = true;
			displayTime = 5;
		}
		if (other.tag == "ExitTrigger") {
			displayMessage4 = true;
			displayTime = 5;
		}

    }

    //display the powerup message to the user
    void OnGUI()
    {
        if (displayMessage)
        {
            GUI.skin.font = myFont;
            GUI.skin.label.fontSize = 12;
            GUI.Label(new Rect((Screen.width / 2)-75, (Screen.height / 2)-100, 400f, 400f), message);
        }
        if (displayMessage2)
        {
            GUI.skin.font = myFont;
            GUI.skin.label.fontSize = 12;
            GUI.Label(new Rect((Screen.width / 2) - 75, (Screen.height / 2)-100, 200f, 200f), "MegaJump Acquired!");
        }
		if (displayMessage3) {
			GUI.skin.font = myFont;
			GUI.skin.label.fontSize = 12;
			GUI.Label(new Rect((Screen.width / 2) - 75, (Screen.height / 2)-100, 200f, 200f), "You got physics! Newton would be proud.");
		}
		if (displayMessage4) {
			GUI.skin.font = myFont;
			GUI.skin.label.fontSize = 14;
			GUI.Label (new Rect ((Screen.width / 2) - 75, (Screen.height / 2) - 100, 200f, 200f), "Hey, you're pretty good at this! Let's put those skills to the test.");
		}
    }

    void Flip()//Trick for switching left and right
    {

        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

}
