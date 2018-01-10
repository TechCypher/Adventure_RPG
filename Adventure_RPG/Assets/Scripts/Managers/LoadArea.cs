using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadArea : MonoBehaviour
{
    #region Varibles
    public string scene;
    #endregion

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") // If  the collider is the player, load the scene
        {
			SceneManager.LoadScene (scene); // Load the scene
		}
	}
}
