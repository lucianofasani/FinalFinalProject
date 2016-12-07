using UnityEngine;
using System.Collections;

public class MegaJumpPowUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D player)
    {
        if(player.name == "Player")
        {
			player.GetComponent<AudioSource> ().clip = player.GetComponent<JumpSound> ().jump2;
            player.GetComponent<CharacterControllerScript>().jumpForce = 2090;
            Destroy(gameObject);
        }
    }
}
