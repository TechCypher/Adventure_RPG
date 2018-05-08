using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damage = 5;

    PlayerStats stats;
    int currentDamage;

    void Start() { stats = FindObjectOfType<PlayerStats>(); } // Finds the player stats class on load

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player") // IF the slime is attacking the player
        {
            currentDamage = damage - stats.currentDefense; // Damage player bu a set amount
            if (currentDamage < 0) currentDamage = 1;
            other.gameObject.GetComponent<Health>().Damage(currentDamage);
        }
    }
}
