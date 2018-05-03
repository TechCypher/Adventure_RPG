using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    #region Varibles
    public int maxHP = 50;
    public int currentHP;
    public int XP;

    PlayerStats stats;
    #endregion
    void Start()
    {
        currentHP = maxHP;
        stats = FindObjectOfType<PlayerStats>();
    }

    void Update()
    {
        if (currentHP <= 0)
        {
            Destroy(gameObject);
            stats.AddXP(XP);
        }
    }

    public void Damage(int damage) { currentHP -= damage; }

    public void Revive() { currentHP = maxHP; }
}
