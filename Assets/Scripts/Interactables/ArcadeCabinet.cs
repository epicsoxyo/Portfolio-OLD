using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArcadeCabinet : Interactable
{

    [SerializeField] private string gameURL;
    [SerializeField] private string githubURL;
    [SerializeField] private InfoTextAsset infoTextAsset;

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

        startButton.onClick.AddListener(() => Application.OpenURL(gameURL));
        githubButton.onClick.AddListener(() => Application.OpenURL(githubURL));
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

        infoText += "Name: " + infoTextAsset.projectTitle + "\n";
        infoText += "Languages used: " + infoTextAsset.languagesUsed + "\n";
        infoText += "Software used: " + infoTextAsset.softwareUsed + "\n";
        infoText += "Genre: " + infoTextAsset.genre + "\n";
        infoText += "Time taken: " + infoTextAsset.timeTaken + "\n";
        infoText += "Contribution: " + infoTextAsset.contribution;

        TextMeshProUGUI infoTextElement = infoPanel.GetComponentInChildren<TextMeshProUGUI>();
        infoTextElement.text = infoText;

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