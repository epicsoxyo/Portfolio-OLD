using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;



public class DialogueUI : MonoBehaviour
{

    public UnityEvent dialogueEnd = new UnityEvent();

    private GameObject dialoguePanel;
    private TextMeshProUGUI dialogueTextBox;
    private GameObject downArrow;

    private GameObject menuPanel;
    [SerializeField] private GameObject menuButtonPrefab;

    private string[] currentDialogue;
    private int currentDialogueIndex = 0;

    [SerializeField] private float charactersPerSecond;
    private bool isReading = false;

    private Controller playerController;



    private void Start()
    {
        
        dialoguePanel = transform.GetChild(0).gameObject;
        dialogueTextBox = dialoguePanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        downArrow = dialoguePanel.transform.GetChild(1).gameObject;
        downArrow.SetActive(false);
        dialoguePanel.SetActive(false);

        menuPanel = transform.GetChild(1).gameObject;
        menuPanel.SetActive(false);

        playerController = GameObject.FindWithTag("Player").GetComponent<Controller>();

    }



    private void Update()
    {
        
        if(currentDialogue == null || !Input.GetButtonDown("Interact")) return;

        if(currentDialogueIndex == currentDialogue.Length)
        {
            CloseDialogue();
            dialogueEnd.Invoke();
            return;
        }

        if(isReading) SkipDialogue();
        else StartCoroutine("ReadDialogue");

    }



    public void OpenDialogue(Dialogue dialogue)
    {

        dialoguePanel.SetActive(true);
        menuPanel.SetActive(false);

        currentDialogue = dialogue.GetCurrentDialogue(true);
        currentDialogueIndex = 0;

        playerController.enabled = false;

        StopAllCoroutines();
        StartCoroutine("ReadDialogue");

    }



    public void OpenDialogueWithMenu(Dialogue dialogue)
    {

        playerController.enabled = true;

        dialoguePanel.SetActive(true);
        StartCoroutine(ReadMenuText(dialogue.menuPrompt));

        while (menuPanel.transform.childCount > 0)
        {
            DestroyImmediate(menuPanel.transform.GetChild(0).gameObject);
        }

        // LayoutRebuilder.ForceRebuildLayoutImmediate(menuPanel.GetComponent<RectTransform>());

        for(int i = 0; i <= dialogue.CurrentIndex; i++)
        {

            Button menuButton = GameObject.Instantiate(menuButtonPrefab).GetComponent<Button>();

            menuButton.GetComponentInChildren<TextMeshProUGUI>().SetText(dialogue.dialogues[i].dialogueName);
            menuButton.transform.SetParent(menuPanel.transform);

            menuButton.onClick.AddListener(() => OpenDialogue(dialogue));

        }

        menuPanel.SetActive(true);

    }



    private IEnumerator ReadDialogue()
    {

        isReading = true;

        downArrow.SetActive(false);

        for(int i = 1; i <= currentDialogue[currentDialogueIndex].Length; i++)
        {
            string substring = currentDialogue[currentDialogueIndex].Substring(0, i);

            dialogueTextBox.SetText(substring);

            yield return new WaitForSeconds(1 / charactersPerSecond);
        }

        downArrow.SetActive(true);

        isReading = false;

        currentDialogueIndex++;

    }



    private IEnumerator ReadMenuText(string menuText)
    {

        isReading = true;

        for(int i = 1; i <= menuText.Length; i++)
        {
            string substring = menuText.Substring(0, i);

            dialogueTextBox.SetText(substring);

            yield return new WaitForSeconds(1 / charactersPerSecond);
        }

        isReading = false;

    }



    private void SkipDialogue()
    {

        StopAllCoroutines();

        dialogueTextBox.SetText(currentDialogue[currentDialogueIndex]);

        downArrow.SetActive(true);

        isReading = false;

        currentDialogueIndex++;

    }



    public void CloseDialogue()
    {

        StopAllCoroutines();

        downArrow.SetActive(false);
        dialoguePanel.SetActive(false);

        menuPanel.SetActive(false);

        currentDialogue = null;

        playerController.enabled = true;

    }

}