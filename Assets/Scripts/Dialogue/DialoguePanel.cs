using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;



public class DialoguePanel : MonoBehaviour
{

    public UnityEvent dialogueEnd = new UnityEvent();

    private GameObject background;
    private TextMeshProUGUI text;
    private GameObject downArrow;

    private string[] dialogue;
    private int dialogueIndex = 0;

    [SerializeField] private float charactersPerSecond;
    private bool isReading = false;



    private void Start()
    {
        
        background = transform.GetChild(0).gameObject;
        background.SetActive(false);

        text = GetComponentInChildren<TextMeshProUGUI>();
        text.enabled = false;

        downArrow = transform.GetChild(2).gameObject;
        downArrow.SetActive(false);

    }



    private void Update()
    {
        
        if(dialogue == null || !Input.GetButtonDown("Interact")) return;

        if(dialogueIndex == dialogue.Length)
        {
            CloseDialogue();
            dialogueEnd.Invoke();
            return;
        }

        if(isReading) SkipDialogue();
        else StartCoroutine("ReadDialogue");

    }



    public void OpenDialogue(DialogueAsset dialogueToRead)
    {

        background.SetActive(true);
        text.enabled = true;

        dialogue = dialogueToRead.dialogue;
        dialogueIndex = 0;

        StartCoroutine("ReadDialogue");

    }



    private IEnumerator ReadDialogue()
    {

        isReading = true;

        downArrow.SetActive(false);

        for(int i = 1; i <= dialogue[dialogueIndex].Length; i++)
        {
            string substring = dialogue[dialogueIndex].Substring(0, i);

            text.SetText(substring);

            yield return new WaitForSeconds(1 / charactersPerSecond);
        }

        downArrow.SetActive(true);

        isReading = false;

        dialogueIndex++;

    }



    private void SkipDialogue()
    {

        StopAllCoroutines();

        text.SetText(dialogue[dialogueIndex]);

        downArrow.SetActive(true);

        isReading = false;

        dialogueIndex++;

    }



    public void CloseDialogue()
    {

        StopAllCoroutines();

        background.SetActive(false);
        text.enabled = false;
        downArrow.SetActive(false);

        dialogue = null;

    }

}