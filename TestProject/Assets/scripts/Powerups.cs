using UnityEngine;
using System.Collections;


public class Powerups : MonoBehaviour {

    private CharacterControllerScript theController;

    // Use this for initialization
    void Start () {
        theController = FindObjectOfType<CharacterControllerScript>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
				theController.jump = true;
				Destroy (gameObject);
        }

    }

}
