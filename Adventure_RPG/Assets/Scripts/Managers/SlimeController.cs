using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{

    #region Varibles
    public float moveSpeed;
    public float moveTime = 1f;
    public float waitTime = 3f;
    public float reloadTime = 2f;

    private float moveCounter;
    private float waitCounter;
    private bool moving;
    private bool reloading;
    private Rigidbody2D rb;
    private Vector3 moveDirection;
    private GameObject player;
    #endregion

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        //waitCounter = waitTime;
        //moveCounter = moveTime;
        //player = GameObject.FindGameObjectWithTag("Player");
        waitCounter = Random.Range(waitTime * 0.75f, waitTime * 1.25f);
        moveCounter = Random.Range(moveTime * 0.75f, moveTime * 1.25f);
    }
	
	
	void Update ()
    {
        if (moving)
        {
            moveCounter -= Time.deltaTime;
            rb.velocity = moveDirection;
            if (moveCounter < 0f)
            {
                moving = false;
                //waitCounter = waitTime;
                waitCounter = Random.Range(waitTime * 0.75f, waitTime * 1.25f);
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            rb.velocity = Vector2.zero;
            if(waitCounter < 0f)
            {
                moving = true;
                //moveCounter = moveTime;
                moveCounter = Random.Range(moveTime * 0.75f, moveTime * 1.25f);
                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }
        if (reloading)
        {
            reloadTime -= Time.deltaTime;
            if (reloadTime < 0f)
            {
                GameManager.LoadGame(player.transform);
                player.SetActive(true);
                reloading = false;
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.tag == "Player")
        //{
        //    other.gameObject.SetActive(false);
        //    reloading = true;
        //    player = other.gameObject;
        //}
    }
}
