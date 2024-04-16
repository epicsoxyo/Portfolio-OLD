using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent(typeof(Dialogue))]
public class Megan : Interactable
{

    private Animator anim;

    private Dialogue dialogue;

    private bool hasInteracted = false;



    private void Awake()
    {

        anim = GetComponent<Animator>();

    }



    protected override void Start()
    {

        base.Start();

        dialogue = GetComponent<Dialogue>();


    }



    protected override void Interaction()
    {
        
        anim.SetTrigger("Interact");

        dialogue.OpenDialogueWithMenu();

    }



    protected override void EndInteraction()
    {

        anim.SetTrigger("Idle");

        dialogue.EndDialogue();

        if(dialogue.CurrentIndex == 0) return;

        PlayerUI playerUI = GameObject.FindWithTag("PlayerUI").GetComponent<PlayerUI>();

        if(playerUI)
        {
            playerUI.GiveBusinessCard();
            return;
        }

        Debug.LogError("Could not find PlayerUI!");

    }

}