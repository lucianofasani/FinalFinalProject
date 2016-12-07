using UnityEngine;
using System.Collections;

public class BlockyBoss : MonoBehaviour {
    public float speed;
    private bool dirRight = true;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (dirRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }

        if (transform.position.x >= 118)
        {
            dirRight = false;
        }

        if (transform.position.x <= 98)
        {
            dirRight = true;
        }
    }
}
