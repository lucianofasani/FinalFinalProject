using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerRestart : MonoBehaviour {


		private void OnCollisionEnter2D(Collision2D other)
		{
		if (other.transform.gameObject.name == "Hitbox"){
				SceneManager.LoadScene (SceneManager.GetSceneAt (0).name);
			} else if (other.transform.gameObject.name == "Killbox") {
			}
		}
}
