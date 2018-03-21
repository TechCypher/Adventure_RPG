using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCManager : MonoBehaviour
{
    #region Varibles
    public float speed = 2f;
    public float walkTime = 1f;
    public float waitTime = 3f;
    public bool isWalking;

    private float walkCounter;
    private float waitCounter;
    private int walkDirection;
    private Rigidbody2D rb;
    #endregion
    #region Start
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
        walkCounter = walkTime;
        ChooseDirection();
    }
    #endregion
    #region Update
    void Update()
    {
        #region NPC Movement
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;
            
            switch (walkDirection)
            {
                case 0:
                    rb.velocity = new Vector2(0, speed);
                    break;
                case 1:
                    rb.velocity = new Vector2(speed, 0);
                    break;
                case 2:
                    rb.velocity = new Vector2(0, -speed);
                    break;
                case 3:
                    rb.velocity = new Vector2(-speed, 0);
                    break;
                default:
                    break;
            }
            if (walkCounter < 0) { isWalking = false; waitCounter = waitTime; }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            rb.velocity = Vector2.zero;
            if(waitCounter < 0) { ChooseDirection(); }
        }
        #endregion
    }
    #endregion
    #region Direction
    void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
    #endregion
}
