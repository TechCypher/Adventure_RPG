using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestObject[] quests;
    public bool[] completedQuest;
    public DialogueManager DM;

    void Start() { completedQuest = new bool[quests.Length]; }

    public void ShowQuest(string quest)
    {
    }
}
