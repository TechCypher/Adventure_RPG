using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour 
{
	public float playerSpeed;
	public Camera minimapCamera;
	public static bool isPlayerMoving;
	public GameObject pausePanel;
	public GameObject mapCanvas;

	private float xAxis;
	private float yAxis;
	private Vector2 lastMove;
	private Animator animate;
	private Rigidbody2D player;
	private static bool playerExists;
	private bool isPauseShowing;
	private bool isMapShowing;

	void Start () 
	{
		animate = GetComponent<Animator>(); // Assigns the private animator to the animator attatched to the player
		player = GetComponent<Rigidbody2D> (); // Assigns the private rigidbody to the rigidbody attatched to the player
		GameManager.PauseGame (pausePanel, false); // Hides the pause panel
		pausePanel.SetActive (false); // Hides the pause panel
		isPauseShowing = false; // Sets the bool to false, becasue the pause panel isn't showing
		ShowMap(mapCanvas, false); // Hides the map
	}

	void Update () 
	{
		isPlayerMoving = false; // Sets the bool to false becasue the player isn't moving
		xAxis = Input.GetAxisRaw ("Horizontal"); // Sets the xAxis varible to the horizontal input value
		yAxis = Input.GetAxisRaw ("Vertical"); // Sets the yAxis varible to the verticle input value

		if (xAxis != 0f) // checks to see if the user is pressing the left or right key
		{
			player.velocity = new Vector2 (xAxis * playerSpeed * Time.deltaTime * 100, 0f); // moves the player in the x direction
			isPlayerMoving = true; // sets the bool to true, becasue the player is moving
			lastMove = new Vector2 (xAxis, 0f); // sets the lastmove vector to the current direction
		}
		if (yAxis != 0f)  // checks to see if the user is pressing the up or down key
		{
			player.velocity = new Vector2 (0f, yAxis * playerSpeed * Time.deltaTime * 100); // moves the player in the y direction
			isPlayerMoving = true; // sets the bool to true, becasue the player is moving
			lastMove = new Vector2 (0f, yAxis); // sets the lastmove vector to the current direction
		}

		if (xAxis == 0f) // checks to see if the player has stopped in the x direction
		{
			player.velocity = new Vector2 (0f, player.velocity.y); // sets its velocity to 0 in the x direction
		}

		if (yAxis == 0f) // checks to see if the player has stopped in the y direction
		{
			player.velocity = new Vector2 (player.velocity.x, 0f); // sets its velocity to 0 in the y direction
		}

		animate.SetFloat ("MoveX", xAxis); // sets the float to the xAxis value to animate the player walking left or right
		animate.SetFloat ("MoveY", yAxis); // sets the float to the yAxis value to animate the player walking up or down
		animate.SetBool ("PlayerMoving", isPlayerMoving); // sets the bool value to start or stop the moving animation
		animate.SetFloat ("LastMoveX", lastMove.x);
		animate.SetFloat ("LastMoveY", lastMove.y);

		if (Input.GetKeyDown(KeyCode.Escape)) {GameManager.PauseGame(pausePanel, isPauseShowing); isPauseShowing = !isPauseShowing;} // If the ecaspe key is pressed, it will toggle the pause panel
		//if (Input.GetKeyDown(KeyCode.KeypadPlus)) {minimapCameraSize += 0.05f;}; // Need to find a way to ajust the zoom on the minimap
		//if (Input.GetKeyDown (KeyCode.KeypadMinus)) {minimapCameraSize -= 0.05f;};
		if (Input.GetKeyDown(KeyCode.M)) {ShowMap(mapCanvas, isMapShowing); isMapShowing = !isMapShowing;} // If the M key is pressed, it will call the ShowMap function
	}

	void ShowMap(GameObject mapCanvas, bool isMapShowing)
	{
		mapCanvas.SetActive (isMapShowing); // Toggles the maps visibility
	}
}
