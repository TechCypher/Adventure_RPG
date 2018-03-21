using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsPage : MonoBehaviour
{
    #region Varibles
    public GameObject pausePanel;
    private GameObject player;
    //private PlayerControl PC;
    private GameObject[] check;
    //private GameManager GM;
    private Button[] button;
    #endregion
    #region Start
    void Start () 
	{
        player = GameObject.FindGameObjectWithTag("Player");
        //PC = player.GetComponent<PlayerControl>();

        check = GetComponents<GameObject>();
        foreach (var obj in check)
        {
            if (obj.tag == "Player")
            {
                player = obj;
                break;
            }
        }
	}
    #endregion
    #region Back Button
    public void Back() //Back button
    {
        //string _scene = SceneManager.GetActiveScene().ToString();
        DontDestroyOnLoad(player);
        LoadArea.Load("Main", player.transform);
    }
    #endregion
}
