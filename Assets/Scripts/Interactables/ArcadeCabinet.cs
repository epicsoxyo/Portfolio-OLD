using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArcadeCabinet : Interactable
{

    [SerializeField] private GameInfoAsset gameInfoAsset;

    private Button startButton;
    private Button githubButton;
    private Button infoButton;

    private GameObject infoPanel;
    private Button closePanelButton;



    protected override void Start()
    {
        
        base.Start();

        Transform buttonsCanvas = transform.GetComponentInChildren<Canvas>().transform;
        startButton = buttonsCanvas.GetChild(0).GetComponent<Button>();
        githubButton = buttonsCanvas.GetChild(1).GetComponent<Button>();
        infoButton = buttonsCanvas.GetChild(2).GetComponent<Button>();
        infoPanel = buttonsCanvas.GetChild(3).gameObject;
        closePanelButton = infoPanel.GetComponentInChildren<Button>();

        SetInfoText();

        startButton.onClick.AddListener(() => Application.OpenURL(gameInfoAsset.gameURL));
        githubButton.onClick.AddListener(() => Application.OpenURL(gameInfoAsset.githubURL));
        infoButton.onClick.AddListener(() => infoPanel.SetActive(true));
        closePanelButton.onClick.AddListener(() => infoPanel.SetActive(false));

        startButton.interactable = false;
        infoButton.interactable = false;
        infoPanel.SetActive(false);
        closePanelButton.interactable = false;

    }



    protected void SetInfoText()
    {

        string infoText = "";

        infoText += "Name: " + gameInfoAsset.projectTitle + "\n";
        infoText += "Languages used: " + gameInfoAsset.languagesUsed + "\n";
        infoText += "Software used: " + gameInfoAsset.softwareUsed + "\n";
        infoText += "Genre: " + gameInfoAsset.genre + "\n";
        infoText += "Time taken: " + gameInfoAsset.timeTaken + "\n";
        infoText += "Contribution: " + gameInfoAsset.contribution;

        TextMeshProUGUI infoTextElement = infoPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        infoTextElement.SetText(infoText);

    }



    protected override void Interaction()
    {

        startButton.interactable = true;
        infoButton.interactable = true;
        closePanelButton.interactable = true;

    }



    protected override void EndInteraction()
    {

        startButton.interactable = false;
        infoButton.interactable = false;
        closePanelButton.interactable = false;

    }

}