using UnityEngine;
using System.Collections;

public class RandomEnemyMove : MonoBehaviour {
    public float speed;
    public float min;
    public float max;
    private bool dirRight = true;
	public SpriteRenderer enemy;
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
			enemy.flipX = true;
        }

        if (transform.position.x <= min)
        {
            dirRight = true;
			enemy.flipX = false;
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
