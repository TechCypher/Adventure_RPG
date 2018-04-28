using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    #region Varibles
    public int maxHP = 100;
    public int currentHP;
    #endregion
    void Start ()
    {
        currentHP = maxHP;
	}
	
	void Update ()
    {
        if (currentHP <= 0)
        {
            //gameObject.SetActive(false);
            GameManager.LoadGame(transform);
            Revive();
        }
	}

    public void Damage(int damage)
    {
        currentHP -= damage;
    }

    public void Revive()
    {
        currentHP = maxHP;
    }
}
