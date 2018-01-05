using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public Button button;
	public string scene;
	public GameObject pausePanel;
	public bool pauseScreen;

	private Button btn;
	// Use this for initialization
	void Start () 
	{
		btn = button.GetComponent<Button> ();
		btn.onClick.AddListener (SwitchScene);
	}
	
	void SwitchScene()
	{
		if (btn.name != "ExitButton") {
			//GameManager.PauseGame (pausePanel, false);
			SceneManager.LoadScene (scene);
		} 
		if (btn.name == "ExitButton") 
		{
			Application.Quit ();
		} 
		if (pauseScreen)
		{
			switch (btn.name) 
			{
			case("ButtonContinue"):
				GameManager.PauseGame (pausePanel, false);
				break;
			case("ButtonSave"):
				GameManager.SaveGame ();
				//GameManager.PauseGame (pausePanel, false);
				break;
			case("ButtonLoad"):
				GameManager.LoadGame ();
				//GameManager.PauseGame (pausePanel, false);
				break;
			case("ButtonSettings"):
				//GameManager.PauseGame (pausePanel, false);
				break;
			case("ButtonExit"):
				SceneManager.LoadScene (scene);
				GameManager.PauseGame (pausePanel, false);
				break;
			default:
				break;
			}
		}



	}
}
