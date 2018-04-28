using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Varibles
    public int currentLevel;
    public int currentXP;
    public int currentHP;
    public int currentAttack;
    public int currentDefense;
    public int[] requiredXP;
    public int[] HPLevels;
    public int[] attackLevels;
    public int[] defenseLevels;

    private Health health;
    #endregion
    private void Start()
    {
        health = FindObjectOfType<Health>();
        if (currentXP > 0 && currentXP < requiredXP[currentLevel + 1]) { currentLevel = 1; }
        currentHP = HPLevels[1];
        currentAttack = attackLevels[1];
        currentDefense = defenseLevels[1];
    }

    private void Update()
    {
        if (currentXP >= requiredXP[currentLevel])
        {
            LevelUp();
        }
    }

    public void AddXP(int XP)
    {
        currentXP += XP;
    }

    public void LevelUp()
    {
        currentLevel++;
        currentHP = HPLevels[currentLevel];
        currentAttack = attackLevels[currentLevel];
        currentDefense = defenseLevels[currentLevel];
        health.maxHP = currentHP;
        health.currentHP += currentHP - HPLevels[currentLevel - 1];
    }
}
