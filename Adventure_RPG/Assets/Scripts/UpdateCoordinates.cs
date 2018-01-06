using System;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCoordinates : MonoBehaviour
{
	public GameObject player;
	public Text text;

	private float x, y;
	private bool isPlayerMoving;

	void Start () 
	{
		isPlayerMoving = PlayerControl.isPlayerMoving; // gets the bool value from the playerControl scipt
	}
		
	void Update () 
	{

		x = player.transform.position.x; // sets the x value to the players current x position
		y = player.transform.position.y; // sets the y value to the players current y position

		x = (float)Math.Round (x, 2); // rounds the x value to 2 decimal places
		y = (float)Math.Round (y, 2); // rounds the y value to 2 decimal places
		text.text = ("[ " + x + "," + y + " ]"); // updates the text to the current position of the player
	}
}
