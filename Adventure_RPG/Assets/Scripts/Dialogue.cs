using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string dialogue;
    public DialogueManager dm;

    private void Start()
    {
        //dm = FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                dm.ShowDialogue(dialogue);
                if (transform.parent.GetComponent<NPCManager>() != null)
                {
                    transform.parent.GetComponent<NPCManager>().canMove = false;
                }
            }
        }
    }
}
