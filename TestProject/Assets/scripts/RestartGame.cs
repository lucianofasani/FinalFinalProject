using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }
}

