using UnityEngine;
using System.Collections;

public class RandomEnemyMove : MonoBehaviour {
    public float speed;
    public float min;
    public float max;
    private bool dirRight = true;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            Physics2D.IgnoreCollision(col.collider, gameObject.GetComponent<Collider2D>());
        }
    }
}
