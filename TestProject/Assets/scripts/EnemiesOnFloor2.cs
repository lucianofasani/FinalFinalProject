using UnityEngine;
using System.Collections;

public class EnemiesOnFloor2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject.Find("enemy4").GetComponent<EnemyScript>().speed = 8;
            GameObject.Find("enemy5").GetComponent<EnemyScript>().speed = 7;
            GameObject.Find("enemy6").GetComponent<EnemyScript>().speed = 6;
        }
    }
}
