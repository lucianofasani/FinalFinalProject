using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	public GameObject creditRoll;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		creditRoll.transform.Translate (new Vector3 (0f, 0.015f, 0f));
	}
		
}
