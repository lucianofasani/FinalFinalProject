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
    public string message = "Power Up: Jumping acquired. Physics!";
    public float displayTime;
    public bool displayMessage = false;
	public JumpSound jumpSound;

    // Use this for initialization
    void Start()
    {
	
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

}
