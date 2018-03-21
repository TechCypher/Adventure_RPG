using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadArea : MonoBehaviour
{
    #region Varibles
    public string scene;
    private Scene main;
    PlayerStartPoint spawnPoint;
    GameObject player;
    PlayerControl PC;
    #endregion
    #region Start stuff
    private void Start()
    {
        spawnPoint = GetComponent<PlayerStartPoint>();
        player = GameObject.FindGameObjectWithTag("player");
        PC = player.GetComponent<PlayerControl>();
    }
    #endregion
    #region Trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") // If  the collider is the player, load the scene
        {
            string currentScene = SceneManager.GetActiveScene().ToString(); 
            if (currentScene == "Main")
            {
                GameManager.SaveGame(PC.playerT);
                SceneManager.MoveGameObjectToScene(GameManager.player, SceneManager.GetSceneByName(scene));
                SceneManager.LoadSceneAsync(scene);
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            }
            else if (currentScene.Contains("House"))
            {
                SceneManager.MoveGameObjectToScene(GameManager.player, SceneManager.GetSceneByName(scene));
                SceneManager.LoadSceneAsync(scene);
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
                PC.playerT.position = spawnPoint.transform.position;
            }
            else
            {
                SceneManager.MoveGameObjectToScene(GameManager.player, SceneManager.GetSceneByName(scene));
                SceneManager.LoadSceneAsync(scene);
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            }
             
        }
    }
    #endregion
    #region Store Position of Player
    void StoreColliderPosition(Collider2D other)
    {
        Vector3 pos = other.transform.position;
        PlayerPrefs.SetFloat("playerXScene", pos.x);
        PlayerPrefs.SetFloat("playerYScene", pos.y);
        PlayerPrefs.SetFloat("playerZScene", pos.z);
    }

    static void StorePlayerPosition(Transform player)
    { 
        Vector3 pos = player.position;
        PlayerPrefs.SetFloat("playerXScene", pos.x);
        PlayerPrefs.SetFloat("playerYScene", pos.y);
        PlayerPrefs.SetFloat("playerZScene", pos.z);
    }
    #endregion
    #region Load player and scene
    public static void Load(string scene, Transform player)
    {
        Debug.Log(scene.ToString());
        StorePlayerPosition(player);
        SceneManager.LoadSceneAsync(scene);
    }
    #endregion
}