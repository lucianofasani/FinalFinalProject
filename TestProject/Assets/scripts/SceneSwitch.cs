using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

	public enum Stages
	{
		STAGE1, SCENEDENAE, STAGEL1, STAGEL2, INTROSCENE
	}

	public Stages myStage;

	private CharacterControllerScript theController;
	// Use this for initialization
	void Start () {
		theController = FindObjectOfType<CharacterControllerScript>();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "Player") {
			//string currentScene = SceneManager.GetActiveScene.name;
			if (myStage == Stages.INTROSCENE) {
				SceneManager.LoadScene ("Stage1");
				SceneManager.UnloadScene ("IntroScene");
				Destroy (gameObject);
			} else if (myStage == Stages.STAGE1) {
				SceneManager.LoadScene ("SceneDenae");
				SceneManager.UnloadScene ("Stage1");
				Destroy (gameObject);
			} else if (myStage == Stages.SCENEDENAE) {
				SceneManager.LoadScene ("StageL1");
				SceneManager.UnloadScene ("SceneDenae");
				Destroy (gameObject);
			} else if (myStage == Stages.STAGEL1) {
				SceneManager.LoadScene ("StageL2");
				SceneManager.UnloadScene ("StageL1");
				Destroy (gameObject);
			} 
		}
	}

}