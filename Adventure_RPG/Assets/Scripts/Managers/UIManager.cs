using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Varibles
    public Slider healthBar;
    public Slider XPBar;
    public Text HPText;
    public Text levelText;
    public Text XPText;
    public Health playerHealth;

    PlayerStats stats;
    int xp;
    int level;
    #endregion
    void Start() { stats = GetComponent<PlayerStats>(); }

    void Update()
    {
        // checkForValues();
        xp = stats.currentXP;
        level = stats.currentLevel;
        healthBar.maxValue = playerHealth.maxHP;
        healthBar.value = playerHealth.currentHP;
        XPBar.maxValue = stats.requiredXP[level];
        XPBar.value = xp;
        HPText.text = "HP: " + playerHealth.currentHP + "/" + playerHealth.maxHP;
        levelText.text = "Level: " + level;
        XPText.text = "XP: " + xp + "/" + stats.requiredXP[level];
    }

    void checkForValues()
    {
        if (GameManager.gameLoaded)
        {
            if (PlayerPrefs.HasKey("playerXP"))
            {
                xp = PlayerPrefs.GetInt("playerXP");
            }

            if (PlayerPrefs.HasKey("playerLevel"))
            {
                level = PlayerPrefs.GetInt("playerLevel");
            }
        }
        else
        {
            xp = stats.currentXP;
            level = stats.currentLevel;
        }
    }
}
