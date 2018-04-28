using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    public int questNum;
    public QuestManager QM;
    public string startText;
    public string endText;

    public void StartQuest()
    {
        QM.ShowQuest(startText);
    }
    public void EndQuest()
    {
        QM.ShowQuest(endText);
        QM.completedQuest[questNum] = true;
        gameObject.SetActive(false);
    }
}
