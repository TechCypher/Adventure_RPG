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
		isPlayerMoving = PlayerControl.isPlayerMoving;
	}

	// Update is called once per frame
	void Update () 
	{

		x = player.transform.position.x;
		y = player.transform.position.y;

		x = (float)Math.Round (x, 2);
		y = (float)Math.Round (y, 2);
		//transform.gameObject.GetComponent<Text>().text = ("[ " + x + "," + y + " ]");
		text.text = ("[ " + x + "," + y + " ]");
	}
}
