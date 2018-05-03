using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Varibles
    public GameObject pausePanel;
    public static GameObject player;
    public static Text points;
    public static string _area;
    public static bool gameLoaded;
    public static PlayerControl PC;
    public GameObject sidePanel;
    public GameObject[] panels;

    Text[] text;
    static string area;
    static PlayerStats stats;
    #endregion
    #region Start Code
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PC = player.GetComponent<PlayerControl>();
        stats = FindObjectOfType<PlayerStats>();

        // pausePanel.SetActive (false);
        PauseGame(pausePanel, false);
        LoadGame(player.transform);
        // points.text = PlayerPrefs.GetInt("Points").ToString();
        text = FindObjectsOfType<Text>();
        for (int i = 0; i < text.Length; i++)
            if (text[i].name == "Points") points = text[i];
        

        foreach (GameObject item in panels)
            item.SetActive(false);
        
    }

    #endregion
    #region Game Management
    public static void PauseGame(GameObject pausePanel, bool isShowing)
    {
        pausePanel.SetActive(isShowing); // Sets the pause visiblity to the isShowiing bool value
        if (isShowing) // If the pause panel is showing
        {
            Time.timeScale = 0; // Pauses the game by stopping time
        }
        else if (!isShowing) // If the pause panel is not showing
        {
            Time.timeScale = 1; // Continues game by setting the game time to full
        }
    }

    void Update()
    {
        // points.text = "Points: " + PC.points.ToString();
        if (!sidePanel.activeSelf)
        {
            foreach (GameObject item in panels)
                item.SetActive(false);
            
        }
    }

    public static void SaveGame(Transform _player) // When this function is called, it will store the data into the playerPrefs database
    {
        Debug.Log("Game Saved: Player Coords " + _player.transform.position.ToString() + " " + "Points: " + PC.points.ToString() + " XP: " + stats.currentXP + " Level: " + stats.currentLevel + " Health: " + stats.currentHP);

        PlayerPrefs.SetFloat("playerCoordX", _player.transform.position.x);
        PlayerPrefs.SetFloat("playerCoordY", _player.transform.position.y);
        PlayerPrefs.SetFloat("playerCoordZ", _player.transform.position.z);
        PlayerPrefs.SetFloat("playerPoints", PC.points);
        PlayerPrefs.SetInt("playerXP", stats.currentXP);
        PlayerPrefs.SetInt("playerLevel", stats.currentLevel);
        PlayerPrefs.SetInt("playerHealth", stats.currentHP);
        gameLoaded = false;
    }

    public static void LoadGame(Transform _player) // When this function is called, it will retrive the various data and put it into temporary data slots
    {
        Debug.Log("Game Loaded");
        float pX = PlayerPrefs.GetFloat("playerCoordX");
        float pY = PlayerPrefs.GetFloat("playerCoordY");
        float pZ = PlayerPrefs.GetFloat("playerCoordZ");
        float _points = PlayerPrefs.GetFloat("playerPoints");
        int xp = PlayerPrefs.GetInt("playerXP");
        int level = PlayerPrefs.GetInt("playerLevel");
        int health = PlayerPrefs.GetInt("playerHealth");

        stats.currentHP = health;
        stats.currentLevel = level;
        stats.currentXP = xp;

        // points.text = _points.ToString();

        Vector3 pPos = new Vector3(pX, pY, pZ);

        if (_player.position != null) // Checks to make sure that the player exists
        {
            _player.position = pPos; // Teleports the player to the saved position
            Debug.Log("Game Loaded: Player Coords " + pPos.ToString() + " Points: " + _points.ToString() + " XP: " + xp + " Level: " + level + " Health: " + health);
        }

        gameLoaded = true;
    }

    public static void GetPoints(Text points)
    {
        points.text = PlayerPrefs.GetFloat("playerPoints").ToString();
    }

    public static void AddPoints(float _points)
    {
        PC.points += _points;
        Debug.Log(PC.points);
    }

    public static string GetArea()
    {
        if (PlayerPrefs.HasKey("area"))
        {
            area = PlayerPrefs.GetString("area");
            return area;
        }

        return null;
    }
    #endregion
}
