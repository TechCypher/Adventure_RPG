using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationText : MonoBehaviour
{
    #region Varibles

    public Text coords;
    public Text area;
    public Transform player;

    float x, y;

    #endregion

    void Start()
    {
    }

    void Update()
    {
        area.text = GameManager.GetArea();
        x = player.position.x;
        y = player.position.y;

        x = (float)Math.Round(x, 2);
        y = (float)Math.Round(y, 2);

        coords.text = "[" + x + "," + y + "]";
    }
}
