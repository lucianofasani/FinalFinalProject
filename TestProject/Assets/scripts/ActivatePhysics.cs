using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActivatePhysics : MonoBehaviour {

	public GameObject textObject;

	private TextElement textGenerator;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator OnCollisionEnter2D(Collision2D other)
	{
		other.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 1;
		Destroy (gameObject);

		textObject.GetComponent<Text> ().text = "You got physics! Newton would be proud.";
		yield return new WaitForSeconds (5);
		textObject.SetActive (false);
	
	}
}
