﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DialogeTrigger : MonoBehaviour
{
    public Flowchart flowChart;
    public GameObject EtoTalk;
    public bool automaticTrigger;
    public Dialogue[] dialogue;
    public string message;
    public bool dialogueGiven;
    public bool canTalk = true;
    public void TriggerDialogue()
    { FindObjectOfType<DialogeManager>().StartDialogue(dialogue[0]); }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (canTalk)
            {
                if (!dialogueGiven)
                {
                    if (!automaticTrigger)
                    {
                        EtoTalk.SetActive(true);

                    }
                    if (automaticTrigger)
                    {
                        Fungus.Flowchart.BroadcastFungusMessage(message);
                        other.GetComponent<Player_Control>().inDialogue = true;
                        Debug.Log("Lets Talk");//TriggerDialogue();
                    }
                }
            }
        }
        

    }
    private void OnTriggerStay(Collider other)
    {
        if (canTalk)
        {
            if (!dialogueGiven)
            {
                if (other.tag == "Player")
                {
                    if (!automaticTrigger)
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            EtoTalk.SetActive(false);
                            Fungus.Flowchart.BroadcastFungusMessage(message);
                            other.GetComponent<Player_Control>().inDialogue = true;
                            Debug.Log("Lets Talk");//TriggerDialogue();
                        }
                    }

                }
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            EtoTalk.SetActive(false);
        }
    }
    public void EndConversation()
    {
        dialogueGiven = true;
      //  flowChart.gameObject.SetActive(false);
    }
    public void DisableBlock()
    {
        this.gameObject.SetActive(false);
    }
    public void CanTalk()
    {
        canTalk = true;
    }
    public void CantTalk()
    {
        canTalk = false;
    }
}
