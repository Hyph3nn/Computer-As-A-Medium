using TMPro;
using UnityEngine;
using System.Collections;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    private readonly WaitForSeconds waitForCompleteDialogue = new(3f); //caching the wfs to prevent loop errors
    private bool isTriggered = false; //prevents dialogue from overlapping, see note in function
    public string[] dialogues = 
    {
        "Hello, Player!",
        "Welcome to my village!",
        "Be careful! There are enemies ahead!"
    };

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(isTriggered == true) //prevents dialogue from overlapping feed, stops repetitive phrasing. e.g. w/out you can trigger the dialoge repetedly causing some phrases to double up and get repetitive, w/this the full dialogue will complete before being triggerred agian
                {
                    return;
                }
            else
                {
                StartCoroutine(ShowDialogue());
                }
                
        }
    }
    IEnumerator ShowDialogue()
    {
        isTriggered = true;

        for (int i = 0; i < dialogues.Length; i++) //arrayName.Length is an exitsting ability of the array to provide it's length
        {
            //exception handling
            if (string.IsNullOrEmpty(dialogues[i]))
            {
                yield break;
            }

            dialogueText.text = dialogues[i]; //accessing dialogue at each index, then applying delay before next text sequence
            //dialogueText.text = dialogues[0];
            //dialogueText.text = "Hello, Player!";

            //second time
            //dialogueText.text = dialogues[1];
            //dialogueText.text = "Welcome to my village!";

            //third time
            //dialogueText.text = dialogues[2];
            //dialogueText.text = "Be careful! There are enemies ahead!";

            yield return waitForCompleteDialogue;
        }
        isTriggered = false;
        dialogueText.text = "";
    }
}
