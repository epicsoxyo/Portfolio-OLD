using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusinessCard : MonoBehaviour
{

    [SerializeField] private Button linkedInButton;
    [SerializeField] private Button itchButton;
    [SerializeField] private Button githubButton;
    [SerializeField] private Button discordButton;
    [SerializeField] private Button twitterButton;



    private void Start()
    {
        
        linkedInButton.onClick.AddListener(() => Application.OpenURL("https://www.linkedin.com/in/megan-hamilton-mills/"));
        itchButton.onClick.AddListener(() => Application.OpenURL("https://soxyo.itch.io/"));
        githubButton.onClick.AddListener(() => Application.OpenURL("https://github.com/epicsoxyo"));
        discordButton.onClick.AddListener(() => Application.OpenURL("https://discordapp.com/users/294190647605460994"));
        twitterButton.onClick.AddListener(() => Application.OpenURL("https://twitter.com/soxxxyo"));

    }



    public void EnterScreen()
    {

    }



    public void ExitScreen()
    {

    }

}