using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    #region Varibles
    public int maxHP = 100;
    public int currentHP;
    #endregion
    void Start() { currentHP = maxHP; }

    void Update()
    {
        if (currentHP <= 0)
        {
            // gameObject.SetActive(false);
            GameManager.LoadGame(transform);
            Revive(); //When the players health level is 0, it will call the revive function to give the player full health
        }
    }

    public void Damage(int damage)
    {
        currentHP -= damage; // Decreases the players damage by a set amount
    }

    public void Revive() { currentHP = maxHP; }
}
