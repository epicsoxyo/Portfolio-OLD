using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megan : Interactable
{

    private Animator anim;

    [SerializeField] private DialogueAsset[] dialogues;
    private DialoguePanel dialoguePanel;
    private int dialogueIndex = 0;



    private void Awake()
    {
        
        anim = GetComponent<Animator>();

    }



    protected override void Start()
    {

        base.Start();

        dialoguePanel = GameObject.FindFirstObjectByType<DialoguePanel>();

    }



    protected override void Interaction()
    {
        
        anim.SetTrigger("Interact");

        dialoguePanel.OpenDialogue(dialogues[dialogueIndex]);

        dialogueIndex++;
        if(dialogueIndex == dialogues.Length) dialogueIndex = 0;

    }



    protected override void EndInteraction()
    {

        anim.SetTrigger("Idle");

        dialoguePanel.CloseDialogue();

    }


}