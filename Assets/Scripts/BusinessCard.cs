using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class BusinessCard : MonoBehaviour
{

    [SerializeField] private Button linkedInButton;
    [SerializeField] private Button itchButton;
    [SerializeField] private Button githubButton;
    [SerializeField] private Button discordButton;
    [SerializeField] private Button twitterButton;

    [SerializeField] private Button emailButton;
    [SerializeField] private Button cvButton;



    private void Start()
    {
        
        linkedInButton.onClick.AddListener(() => Application.OpenURL("https://www.linkedin.com/in/megan-hamilton-mills/"));
        itchButton.onClick.AddListener(() => Application.OpenURL("https://soxyo.itch.io/"));
        githubButton.onClick.AddListener(() => Application.OpenURL("https://github.com/epicsoxyo"));
        discordButton.onClick.AddListener(() => Application.OpenURL("https://discordapp.com/users/294190647605460994"));
        twitterButton.onClick.AddListener(() => Application.OpenURL("https://twitter.com/soxxxyo"));
        emailButton.onClick.AddListener(() =>  Application.OpenURL("mailto:meganhamiltonmills@gmail.com"));
        cvButton.onClick.AddListener(() => Application.OpenURL("https://acrobat.adobe.com/id/urn:aaid:sc:EU:bba437b1-44c6-4ec7-b937-bf25d7f1e53c"));

    }



    public void EnterScreen()
    {

    }



    public void ExitScreen()
    {

    }

}