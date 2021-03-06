using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    #region Varibles
    public float playerSpeed;
    public float diagonalMoveMod;
    public Camera minimapCamera;
    public static bool isPlayerMoving;
    public GameObject pausePanel;
    public GameObject sidePanel;
    public GameObject weapon;
    public Transform playerT;
    public float points;
    public GameObject area1;
    public GameObject area2;
    public GameObject area3;
    // public GameObject mapCanvas;

    float xAxis;
    float yAxis;
    float currentPlayerSpeed;
    Vector2 lastMove;
    Animator animate;
    Rigidbody2D player;
    // private Transform t;
    static bool playerExists;
    bool isPauseShowing;
    bool isMapShowing;
    // private GameManager GM;
    #endregion
    #region Start Stuff
    void Start()
    {
        animate = GetComponent<Animator>(); // Assigns the private animator to the animator attatched to the player
        player = GetComponent<Rigidbody2D>(); // Assigns the private rigidbody to the rigidbody attatched to the player
        playerT = GetComponent<Transform>();
        // GM = FindObjectOfType<GameManager>();
        GameManager.PauseGame(pausePanel, false); // Hides the pause panel
        pausePanel.SetActive(false); // Hides the pause panel
        isPauseShowing = false; // Sets the bool to false, becasue the pause panel isn't showing
                                // ShowMap(mapCanvas, false); // Hides the map
                                // t = transform;
        points = PlayerPrefs.GetInt("playerPoints");
        sidePanel.SetActive(false);
    }

    #endregion
    #region Update: Player Movement, Animation, Keyboard Actions
    void Update()
    {
        #region Player Movement
        isPlayerMoving = false; // Sets the bool to false becasue the player isn't moving
        xAxis = Input.GetAxisRaw("Horizontal"); // Sets the xAxis varible to the horizontal input value
        yAxis = Input.GetAxisRaw("Vertical"); // Sets the yAxis varible to the verticle input value

        if (xAxis != 0f) // checks to see if the user is pressing the left or right key
        {
            player.velocity = new Vector2(xAxis * currentPlayerSpeed * Time.deltaTime * 100, 0f); // moves the player in the x direction
            isPlayerMoving = true; // sets the bool to true, becasue the player is moving
            lastMove = new Vector2(xAxis, 0f); // sets the lastmove vector to the current direction
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                player.velocity = new Vector2(xAxis * 2 * currentPlayerSpeed * Time.deltaTime * 100, 0f); // moves the player in the x direction
                isPlayerMoving = true; // sets the bool to true, becasue the player is moving
                lastMove = new Vector2(xAxis, 0f); // sets the lastmove vector to the current direction
            }
        }

        if (yAxis != 0f)  // checks to see if the user is pressing the up or down key

        {
            player.velocity = new Vector2(0f, yAxis * currentPlayerSpeed * Time.deltaTime * 100); // moves the player in the y direction
            isPlayerMoving = true; // sets the bool to true, becasue the player is moving
            lastMove = new Vector2(0f, yAxis); // sets the lastmove vector to the current direction
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                player.velocity = new Vector2(0f, yAxis * 2 * currentPlayerSpeed * Time.deltaTime * 100); // moves the player in the y direction
                isPlayerMoving = true; // sets the bool to true, becasue the player is moving
                lastMove = new Vector2(xAxis, 0f); // sets the lastmove vector to the current direction
            }
        }

        if (xAxis == 0f) // checks to see if the player has stopped in the x direction
        {
            player.velocity = new Vector2(0f, player.velocity.y); // sets its velocity to 0 in the x direction
        }

        if (yAxis == 0f) // checks to see if the player has stopped in the y direction
        {
            player.velocity = new Vector2(player.velocity.x, 0f); // sets its velocity to 0 in the y direction
        }

        if (Mathf.Abs(xAxis) > 0.5f && Mathf.Abs(yAxis) > 0.5f) // Checks to see if the player is moving diagonally
        {
            currentPlayerSpeed = playerSpeed * diagonalMoveMod;
        }
        else
        {
            currentPlayerSpeed = playerSpeed;
        }

        #endregion
        #region Player Animation
        animate.SetFloat("MoveX", xAxis); // sets the float to the xAxis value to animate the player walking left or right
        animate.SetFloat("MoveY", yAxis); // sets the float to the yAxis value to animate the player walking up or down
        animate.SetBool("PlayerMoving", isPlayerMoving); // sets the bool value to start or stop the moving animation
        animate.SetFloat("LastMoveX", lastMove.x);
        animate.SetFloat("LastMoveY", lastMove.y);
        #endregion
        #region Key Inputs
        if (Input.GetKeyUp(KeyCode.Escape)) { GameManager.PauseGame(pausePanel, isPauseShowing); isPauseShowing = !isPauseShowing; } // If the ecaspe key is pressed, it will toggle the pause panel
        if (Input.GetKeyDown(KeyCode.KeypadMinus)) { transform.position = new Vector3(34.7f, -41.42f, transform.position.z); }
        if (Input.GetKeyDown(KeyCode.L)) { GameManager.LoadGame(playerT); }
        if (Input.GetKeyDown(KeyCode.K)) { GameManager.SaveGame(playerT); }
        if (Input.GetKeyDown(KeyCode.P)) { GameManager.AddPoints(1f); }
        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.RightControl)) { sidePanel.SetActive(!sidePanel.activeSelf); }
        if (Input.GetKeyUp(KeyCode.E)) { weapon.SetActive(!weapon.activeSelf); }
        if (Input.GetKeyUp(KeyCode.R)) { GetComponent<Health>().Revive(); }
        if (Input.GetKeyDown(KeyCode.Keypad1)) { transform.position = area1.transform.position; }
        if (Input.GetKeyDown(KeyCode.Keypad2)) { transform.position = area2.transform.position; }
        if (Input.GetKeyDown(KeyCode.Keypad3)) { transform.position = area3.transform.position; }
        // if (Input.GetKeyDown(KeyCode.KeypadPlus)) {minimapCameraSize += 0.05f;}; // Need to find a way to ajust the zoom on the minimap
        // if (Input.GetKeyDown (KeyCode.KeypadMinus)) {minimapCameraSize -= 0.05f;};
        // if (Input.GetKeyDown(KeyCode.M)) {ShowMap(mapCanvas, isMapShowing); isMapShowing = !isMapShowing;} // If the M key is pressed, it will call the ShowMap function
        #endregion
        #region Debug
        /*string area = GameManager.GetArea();
        Debug.Log(area);*/
        #endregion
    }

    #endregion
    #region Other
    void ShowMap(GameObject mapCanvas, bool isMapShowing)
    {
        // mapCanvas.isMapShowing); // Toggles the maps visibility
    }

    public Transform GetPlayerTransform() { return transform; }
    #endregion
}
