using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damage = 5;

    PlayerStats stats;
    int currentDamage;

    void Start() { stats = FindObjectOfType<PlayerStats>(); }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            currentDamage = damage - stats.currentDefense;
            if (currentDamage < 0) currentDamage = 1;
            other.gameObject.GetComponent<Health>().Damage(currentDamage);
        }
    }
}
