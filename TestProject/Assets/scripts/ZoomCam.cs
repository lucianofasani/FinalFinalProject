using UnityEngine;
using System.Collections;

public class ZoomCam : MonoBehaviour {
    public GameObject player;
    public GameObject enemy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.x > enemy.transform.position.x)
        {
            Debug.Log("Inside if");
            while (Camera.main.orthographicSize <= 12)
            {
                Camera.main.orthographicSize += Time.deltaTime* .1f;
            }
        }
    }
}
