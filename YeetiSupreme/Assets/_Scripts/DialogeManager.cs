using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogeManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueUI;
    Queue<string> sentences;
    public int choice;
    // Start is called before the first frame update
    void Start()
    {
        sentences= new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {

        nameText.text = dialogue.name;
        sentences.Clear();
        FindObjectOfType<Player_Control>().inDialogue = true;
        foreach (string sentence in dialogue.sentences)
        {
            dialogueUI.SetActive(true);
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
        
                
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string setence = sentences.Dequeue();
        dialogueText.text = setence;
        return;
            }
    public void ChooseDialogue(int dialogueSet)
    {
        choice = dialogueSet;
        
    }
    public void OpenDialogue(Dialogue dialogue)
    {
        dialogue.dialogueSet.SetActive(true);
    }
    
    public void EndDialogue()
    {
        dialogueUI.SetActive(false);
        FindObjectOfType<Player_Control>().inDialogue = false;
        Debug.Log("Dialogue Ended");
    }

    public void GiveQuest()
    {
        Debug.Log("Give Quest to Player");
    }

}
