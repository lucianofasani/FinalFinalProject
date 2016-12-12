using UnityEngine;
using System.Collections;

public class TextOnCol : MonoBehaviour {
    public GameObject collidingWith;
    public string message;
    public float displayTime;
    public bool displayMessage = false;
    public Font myFont;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        displayTime -= Time.deltaTime;
        if(displayTime <= 0)
        {
            displayMessage = false;
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            displayMessage = true;
            displayTime = 3;
        }
    }

    void OnGUI()
    {
        if (displayMessage)
        {
            GUI.skin.font = myFont;
            GUI.skin.label.fontSize = 10;
            GUI.Label(new Rect((Screen.width / 2) - 75, (Screen.height / 2) - 30, 200f, 200f), message);

        }
    }
}
