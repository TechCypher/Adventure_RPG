using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapStartup : MonoBehaviour
{

	public GameObject[] gameObjects; // Array of GameObjects to be set active
	public bool[] gameObjectActive; // Array of bools that link with the respective GameObject

	void Start () 
	{
		for (int i = 0; i < gameObjects.Length; i++) // Runs the loop until all of the GameObjects have been toggled
		{
			gameObjects [i].SetActive (gameObjectActive [i]); // Sets each GameObject active or inactive
		}

		Time.timeScale = 1;

	}
}
