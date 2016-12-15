using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Testing : MonoBehaviour {
    private EightBitCharControl theController;
    private bool dirUp = true;
    private float speed = 3;
    public Transform childTransform;
    private float min;
    private float max;
    private GameObject elevator;


    // Use this for initialization
    void Start () {
        theController = FindObjectOfType<EightBitCharControl>();
        elevator = GameObject.Find("Elevator");
	}
	
	// Update is called once per frame
	void Update () {
        //testing for platforms
        if (dirUp)
        {
            elevator.transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            elevator.transform.Translate(-Vector2.up * speed * Time.deltaTime);
        }

        if (elevator.transform.position.y >= -.92)
        {
            dirUp = false;
        }

        if (elevator.transform.position.y <= -2.07)
        {
            dirUp = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //tetsting for scene reload on enemy collision
        if (other.gameObject.tag == "enemy")
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
            Debug.Log("Test 3: Colliding With Enemy Restarts Game: SUCCESS");
        }

        //testing moving platforms when player jumps ON
        if (other.gameObject.name == "Elevator")
        {
            transform.SetParent(childTransform);
            Debug.Log("Test 2: Player Becomes Child of Moving Platforms: SUCCESS");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //testing for powerup jumping
        if (other.name == "Player")
        {
            theController.jump = true;
            Destroy(gameObject);
            Debug.Log("Test 1: Player Acquires Jump, Power Up Destroyed: SUCCESS");
        }
    }

    //testing moving platforms when player jumps OFF
    void OnCollisionExit2D(Collision2D other)
    {
        transform.SetParent(null);
    }
}
