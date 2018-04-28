using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject box;
    public Text text;
    public bool dialogue;
    public string[] dialogueArray;
    private int currentIndex;
    private void Start()
    {
        dialogue = box.activeSelf;
        if (dialogue) { box.SetActive(false); dialogue = false; }
    }

    private void Update()
    {
        if (dialogue && Input.GetKeyDown(KeyCode.Space))
        {
            //box.SetActive(false);
            //dialogue = false;
            currentIndex++;
        }
        if(currentIndex >= dialogueArray.Length)
        {
            box.SetActive(false);
            dialogue = false;
            currentIndex = 0;
        }
        text.text = dialogueArray[currentIndex];
    }

    public void ShowDialogue(string dtext)
    {
        dialogue = true;
        box.SetActive(true);
        text.text = dtext;
    }
}
