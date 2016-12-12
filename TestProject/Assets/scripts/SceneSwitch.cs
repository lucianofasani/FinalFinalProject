using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

	public enum Stages
	{
		STAGE1, SCENEDENAE, STAGEL1, STAGEL2, INTROSCENE, FIRSTSTAGE, SCENE2DENAE, MODERNSCENE
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
            if (myStage == Stages.INTROSCENE)
            {
                SceneManager.LoadScene("FirstStage");
                SceneManager.UnloadScene("IntroScene");
                Destroy(gameObject);
            }
            else if (myStage == Stages.FIRSTSTAGE)
            {
                SceneManager.LoadScene("SceneDenae");
                SceneManager.UnloadScene("FirstStage");
            }
            else if (myStage == Stages.SCENEDENAE)
            {
                SceneManager.LoadScene("Scene2Denae");
                SceneManager.UnloadScene("SceneDenae");
                Destroy(gameObject);
            }
            else if (myStage == Stages.SCENE2DENAE) {
                SceneManager.LoadScene("StageL1");
                SceneManager.UnloadScene("Scene2Denae");
                Destroy(gameObject);
            }
            else if (myStage == Stages.STAGEL1)
            {
                SceneManager.LoadScene("ModernScene");
                SceneManager.UnloadScene("StageL1");
                Destroy(gameObject);
            }
		}
	}

}