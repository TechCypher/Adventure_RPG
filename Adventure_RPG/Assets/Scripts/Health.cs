using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    #region Varibles
    public int maxHP = 100;
    public int currentHP;
    #endregion
    void Start() { currentHP = maxHP; } // Set the players current HP to the max XP

    void Update()
    {
        if (currentHP <= 0)
        {
            GameManager.LoadGame(transform); // When the player dies, it will load the last saved game
            Revive(); //When the players health level is 0, it will call the revive function to give the player full health
        }
    }

    public void Damage(int damage)
    {
        currentHP -= damage; // Decreases the players damage by a set amount
    }

    public void Revive() { currentHP = maxHP; } // When this function is called, it will give the player full health
}
