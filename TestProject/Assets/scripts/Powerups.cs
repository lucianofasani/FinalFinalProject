using UnityEngine;
using System.Collections;


public class Powerups : MonoBehaviour {

    private CharacterControllerScript theController;
    private EightBitCharControl eightController;
    // Use this for initialization
    void Start () {
        eightController = FindObjectOfType<EightBitCharControl>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
                eightController.jump = true;
				Destroy (gameObject);
        }

    }

}
