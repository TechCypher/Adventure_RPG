using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Varibles
    public GameObject pausePanel;
    public GameObject player;
    #endregion
    #region Start Code
    void Start () 
	{
		//pausePanel.SetActive (false);
		PauseGame (pausePanel, false);
	}
    #endregion
    #region Game Management
    public static void PauseGame(GameObject pausePanel, bool isShowing)
	{
		pausePanel.SetActive (isShowing); // Sets the pause visiblity to the isShowiing bool value
		if (isShowing) // If the pause panel is showing
		{
            Time.timeScale = 0; // Pauses the game by stopping time
		} 
		else if (!isShowing) // If the pause panel is not showing
		{
            Time.timeScale = 1; // Continues game by setting the game time to full
		}
	}

	public static void SaveGame()
	{
		Debug.Log ("Game Saved");
	}

	public static void LoadGame()
	{
		Debug.Log ("Game Loaded");
	}
    #endregion
}
