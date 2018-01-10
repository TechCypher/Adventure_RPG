using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsPage : MonoBehaviour
{
    #region Varibles
    private Button[] button;
    #endregion

    void Start () 
	{
		
	}

	void Update () 
	{
		foreach (var btn in button) 
		{
			if (btn.name == "BackButton") 
			{
				SceneManager.UnloadSceneAsync ("Settings");
			}
		}
	}
}
