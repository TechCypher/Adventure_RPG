using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    #region Varibles
    public Button button;
	public string scene;
	public GameObject pausePanel;
	public bool pauseScreen;
    
    private Button btn;
    #endregion
    #region Start Code
    void Start () 
	{
		btn = button.GetComponent<Button> (); // assigns the btn button to the button attatched to this script
		btn.onClick.AddListener (SwitchScene); // when the button is pressed it will call the switch scene function
	}
    #endregion

    void SwitchScene()
	{
        #region Main Menu Buttons
        if (btn.name != "ExitButton") // When on the main menu, if the button pressed is not the exit button, it will load the next scene
		{
			//GameManager.PauseGame (pausePanel, false);
			SceneManager.LoadScene (scene); // Loads the scence predefined by the user
		} 
		if (btn.name == "ExitButton")  // When on the main menu, if the button pressed is the exit button, the game will exit
		{
			Application.Quit (); // Quits the application
		}
        #endregion
        #region Pause Screen Buttons
        if (pauseScreen) // If the button is part of the pause screen
		{
			switch (btn.name) // Switch the button name
			{
				case("ButtonContinue"): // If the continue button is pressed
					GameManager.PauseGame (pausePanel, false); // Hide the pausePanel
					break;
				case("ButtonSave"): // If the save button has been pressed
					GameManager.SaveGame (); // Save the game
					//GameManager.PauseGame (pausePanel, false);
					break;
				case("ButtonLoad"): // If the load button has been pressed
					GameManager.LoadGame (); // Load the game
					//GameManager.PauseGame (pausePanel, false);
					break;
				case("ButtonSettings"): // If the settings button has been pressed
					//GameManager.PauseGame (pausePanel, false);
					SceneManager.SetActiveScene("Settings");
					break;
				case("ButtonExit"): // If the exit button has been pressed
					SceneManager.LoadScene (scene); // load the main menu
					GameManager.PauseGame (pausePanel, false); // Hide the pause panel
					break;
				default:
					break;
			}
		}
        #endregion
    }
}
