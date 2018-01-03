using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject pasuePanel;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public static void PauseGame(GameObject pausePanel, bool isShowing)
	{
		pausePanel.SetActive (isShowing);
		if (isShowing) 
		{
			Time.timeScale = 0;
		} 
		else if (!isShowing) 
		{
			Time.timeScale = 1;
		}
	}

	public static void SaveGame()
	{
	
	}

	public static void LoadGame()
	{
		
	}
}
