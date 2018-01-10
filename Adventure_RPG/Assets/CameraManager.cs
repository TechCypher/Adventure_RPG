using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	public Transform target;
	public float cameraSpeed = 5f;

	void Start () 
	{
		
	}

	void Update () 
	{
		Vector2 newPos = new Vector3 (target.position.x, target.position.y, transform.position.z);
		//transform.position = Vector3.Lerp (transform.position, newPos, cameraSpeed);
		transform.position = newPos;
	}
}
