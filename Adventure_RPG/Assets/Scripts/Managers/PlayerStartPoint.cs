using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStartPoint : MonoBehaviour
{
    #region Varibles
    private PlayerControl player;
    #endregion

    void Start ()
    {
        player = FindObjectOfType<PlayerControl>(); //Finds the player attatched to the PlayerControl script
        player.transform.position = transform.position; // Moves the player to the place where the start point is
    }
}
