﻿using UnityEngine;
using System.Collections;

public class EnemiesOnFloor3 : MonoBehaviour {

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
            GameObject.Find("enemy7").GetComponent<EnemyScript>().speed = 7;
        }
    }
}
