using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Dialogue : MonoBehaviour
{

    private DialogueUI panel;

    [TextArea] public string menuPrompt;

    public DialogueAsset[] dialogues;

    private int currentIndex = 0;
    public int CurrentIndex {get{return currentIndex;}}



    private void Start()
    {
        panel = GameObject.FindFirstObjectByType<DialogueUI>();
    }



    public void OpenDialogueWithMenu()
    {
        panel.OpenDialogueWithMenu(this);
    }



    // public void OpenDialogue()
    // {
    //     dialoguePanel.OpenDialogue(this);
    // }



    public string[] GetCurrentDialogue(bool incrementIndex)
    {
        return dialogues
        [(incrementIndex && currentIndex < dialogues.Length - 1) ?
            currentIndex++ :
            currentIndex
        ].dialogue ?? new string[0];
    }



    public void EndDialogue()
    {
        panel.CloseDialogue();
    }

}