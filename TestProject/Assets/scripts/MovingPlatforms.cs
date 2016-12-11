using UnityEngine;
using System.Collections;

public class MovingPlatforms : MonoBehaviour {
    public float speed = 8;
    public float min;
    public float max;
    public GameObject elevator1;
    private bool dirUp = true;
    private bool dirRight = true;
    public bool upDown;
    public bool leftRight;
    public Transform childTransform;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (upDown)
        {
            if (dirUp)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Vector2.up * speed * Time.deltaTime);
            }

            if (transform.position.y >= max)
            {
                dirUp = false;
            }

            if (transform.position.y <= min)
            {
                dirUp = true;
            }
        }
        else if (leftRight)
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
                dirRight = false;
            }

            if (transform.position.x <= min)
            {
                dirRight = true;
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.SetParent(childTransform);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        other.transform.SetParent(null);
    }
}

