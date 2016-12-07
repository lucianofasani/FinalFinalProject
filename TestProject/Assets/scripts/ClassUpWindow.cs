using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClassUpWindow : MonoBehaviour {

	public GameObject myPanel;
	private bool showPanel;
	// Use this for initialization
	void Start () {
		showPanel = false;
		myPanel.SetActive (showPanel);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "Player")
		{
			showPanel = !showPanel;
			myPanel.SetActive (showPanel);
			Destroy(gameObject);
			Time.timeScale = 0;

		}

	}
}
