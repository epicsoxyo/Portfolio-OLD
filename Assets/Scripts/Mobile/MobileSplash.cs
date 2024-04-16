using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileSplash : MonoBehaviour
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
        
        if(!Platform.IsMobileBrowser()) Destroy(gameObject);

        linkedInButton.onClick.AddListener(() => Application.OpenURL("https://www.linkedin.com/in/megan-hamilton-mills/"));
        itchButton.onClick.AddListener(() => Application.OpenURL("https://soxyo.itch.io/"));
        githubButton.onClick.AddListener(() => Application.OpenURL("https://github.com/epicsoxyo"));
        discordButton.onClick.AddListener(() => Application.OpenURL("https://discordapp.com/users/294190647605460994"));
        twitterButton.onClick.AddListener(() => Application.OpenURL("https://twitter.com/soxxxyo"));
        emailButton.onClick.AddListener(() =>  Application.OpenURL("mailto:meganhamiltonmills@gmail.com"));
        cvButton.onClick.AddListener(() => Application.OpenURL("https://acrobat.adobe.com/id/urn:aaid:sc:EU:f157b9b3-c2b9-495e-b070-3157c50cfc91"));

    }

}