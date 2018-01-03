using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour 
{
	//#region Varibles
	public float playerSpeed;
	//public Camera playerCamera;
	public Camera minimapCamera;
	public static bool playerMoving;
	//public GameObject pausePanel;

	private float xAxis;
	private float yAxis;
	private Vector2 lastMove;
	private Animator animate;
	private Rigidbody2D player;
	private static bool playerExists;
	private bool isPauseShowing;
	//#endregion
	// Use this for initialization
	void Start () 
	{
		animate = GetComponent<Animator>();
		player = GetComponent<Rigidbody2D> ();
		/*playerExists = false;
		if (!playerExists) 
		{
			DontDestroyOnLoad (transform.gameObject);
			playerExists = true;
		}
		else { Destroy (gameObject);}*/
		//playerCamera.orthographicSize = 5f;
		//GameManager.PauseGame (pausePanel, false);
	//	pausePanel.SetActive (false);
		isPauseShowing = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerMoving = false;
		xAxis = Input.GetAxisRaw ("Horizontal");
		yAxis = Input.GetAxisRaw ("Vertical");

		if (xAxis != 0f) 
		{
			player.velocity = new Vector2 (xAxis * playerSpeed * Time.deltaTime, 0f);
			playerMoving = true;
			lastMove = new Vector2 (xAxis, 0f);
		}
		if (yAxis != 0f) 
		{
			player.velocity = new Vector2 (0f, yAxis * playerSpeed*Time.deltaTime);
			playerMoving = true;
			lastMove = new Vector2 (0f, yAxis);
		}

		if (xAxis == 0f) 
		{
			player.velocity = new Vector2 (0f, player.velocity.y);
		}

		if (yAxis == 0f)
		{
			player.velocity = new Vector2 (player.velocity.x, 0f);
		}

		animate.SetFloat ("MoveX", xAxis);
		animate.SetFloat ("MoveY", yAxis);
		animate.SetBool ("PlayerMoving", playerMoving);
		animate.SetFloat ("LastMoveX", lastMove.x);
		animate.SetFloat ("LastMoveY", lastMove.y);

		/*if (Input.GetKeyDown(KeyCode.Escape)) {GameManager.PauseGame(pausePanel, isPauseShowing); isPauseShowing = !isPauseShowing;}
		if (Input.GetKeyDown(KeyCode.KeypadPlus)) {minimapCameraSize += 0.05f;};
		if (Input.GetKeyDown (KeyCode.KeypadMinus)) {minimapCameraSize -= 0.05f;};*/
	}
}
