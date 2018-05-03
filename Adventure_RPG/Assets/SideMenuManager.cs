using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideMenuManager : MonoBehaviour
{
    public GameObject[] panels;

    public void OpenPanel(GameObject panel)
    {
        foreach (GameObject item in panels)
            item.SetActive(false);
        

        panel.SetActive(!panel.activeSelf);
    }
}
