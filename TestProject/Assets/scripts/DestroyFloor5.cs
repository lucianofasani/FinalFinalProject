using UnityEngine;
using System.Collections;

public class DestroyFloor5 : MonoBehaviour {
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "Player")
        {
            GameObject.Find("Main Camera").GetComponent<CameraControl>().target = GameObject.Find("BlockyBoss_0").transform;//camera follows blockyboss when he dies
            GameObject.Find("BlockyBoss_0").GetComponent<BlockyBoss>().speed = 0;
            Destroy(GameObject.Find("floor4"));
            Destroy(gameObject);
            Destroy(GameObject.Find("brick (4)"));
            Destroy(GameObject.Find("8bitTile5"));
        }
    }
}
