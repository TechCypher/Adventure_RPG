using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    GameObject player;
    // private PlayerControl PC;
    // private GameManager GM;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // PC = player.GetComponent<PlayerControl>();
        // GM = FindObjectOfType<GameManager>();
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            OpenShop();
        }*/

        OpenShop();
    }

    public void OpenShop()
    {
        player.transform.position -= new Vector3(2, 2, 0);
        GameManager.SaveGame(player.transform);
        SceneManager.LoadScene("Shop");
    }

    public void ExitShop()
    {
        GameManager.LoadGame(player.transform);
        SceneManager.LoadScene("Main");
    }
}

public class ItemManager : ShopManager
{
    void Start()
    {
    }

    void AddItem() // Shop panel can display 16 items at a time
    {
    }

    void RemoveItem()
    {
    }

    void BuyItem()
    {
    }

    void SellItem()
    {
    }

    static void UpdateShop()
    {
    }
}
