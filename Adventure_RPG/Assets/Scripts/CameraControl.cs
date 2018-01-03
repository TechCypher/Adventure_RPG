using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour 
{

	public GameObject target;
	public Camera camera;
	private Vector3 targetPos;
	public float cameraSpeed;
	private Vector3 lerped;
	private Vector3 camPos;
	private int x, y, z;
	private static bool cameraExists;
	// Use this for initialization
	void Start () 
	{
		/*cameraExists = false;

		if (!cameraExists) 
		{
			cameraExists = true;
			DontDestroyOnLoad (transform.gameObject);
			transform.position = new Vector3 (target.transform.position.x, target.transform.position.y, transform.position.z);
		}
		else { Destroy (gameObject);}*/
		camera.orthographicSize = 5f;
	}

	// Update is called once per frame
	void Update ()
	{
		targetPos = new Vector3 (target.transform.position.x, target.transform.position.y, transform.position.z);
		lerped = Vector3.Lerp (transform.position, targetPos, cameraSpeed * Time.deltaTime);
		//transform.position = new Vector3 (x, y, z);
		//camPos = new Vector3(x,y,-10f);
		transform.position =  Vector3.Lerp (transform.position, targetPos, cameraSpeed * Time.deltaTime);
	}
}