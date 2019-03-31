using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBlock : MonoBehaviour
{
    public string QuestName;
    public int killPoints;
    public int pointsNeeded;
    public string questCompleted;
    public void KillAdd()
    {
        killPoints++;
        if (killPoints>=pointsNeeded)
        {
            Fungus.Flowchart.BroadcastFungusMessage(questCompleted);
        }
    }

}
