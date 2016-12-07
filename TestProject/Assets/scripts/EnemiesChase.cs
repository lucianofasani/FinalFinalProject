using UnityEngine;
using System.Collections;

public class EnemiesChase : MonoBehaviour {

    public float speed;
    public GameObject player;
    public GameObject enemy;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //when player gets past enemy, the enemy will puruse the player
        if (player.transform.position.x > enemy.transform.position.x + 5)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        //otherwise, enemy keeps charging at player
        else
        {
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "BackWall")
        {
            Destroy(gameObject);
        }
    }
}
