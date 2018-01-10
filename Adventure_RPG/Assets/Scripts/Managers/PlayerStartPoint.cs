using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStartPoint : MonoBehaviour {

	private PlayerControl player;

	void Start ()
    { 
		player = FindObjectOfType<PlayerControl> ();
		player.transform.position = transform.position;
	}
}
