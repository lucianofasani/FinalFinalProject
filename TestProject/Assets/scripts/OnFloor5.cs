using UnityEngine;
using System.Collections;

public class OnFloor5 : MonoBehaviour {

    public float displayTime;
    public float cameraSwitch;
    public bool displayMessage = false;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //decrement the time the message stays on the screen
        displayTime -= Time.deltaTime;
        cameraSwitch -= Time.deltaTime;
        if (displayTime <= 0.0)
        {
            displayMessage = false;
        }
        if(cameraSwitch <= 0.0)
        {
            GameObject.Find("Main Camera").GetComponent<CameraControl>().target = GameObject.Find("Player").transform;//transfer camera back to player after blocky dies
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            displayMessage = true;
            displayTime = 3;
            cameraSwitch = 5;

        }
    }

    void OnGUI()
    {
        if (displayMessage)
        {
            GUI.Label(new Rect((Screen.width / 2) - 75, (Screen.height / 2) - 30, 200f, 200f), "Defeat the BOSS!!!");
        }
    }
}
