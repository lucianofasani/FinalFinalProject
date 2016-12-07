using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TextElement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject addText (GameObject myObject, string name, string message) {
		
		myObject.transform.SetParent (this.transform);
		myObject.GetComponent<Text> ().text = message;
		return myObject;
	
	}
		
}
