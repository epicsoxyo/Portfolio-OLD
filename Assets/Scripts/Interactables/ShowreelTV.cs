using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;



public class ShowreelTV : Interactable
{

    [SerializeField] private string showreelFileName;
    [SerializeField] private string showreelYoutubeURL;
    private Button youtubeButton;



    protected override void Start()
    {

        base.Start();

        VideoPlayer videoPlayer = gameObject.GetComponent<VideoPlayer>();

        if(videoPlayer)
        {
            string showreelURL = Path.Combine(Application.streamingAssetsPath, showreelFileName);
            videoPlayer.url = showreelURL;
            videoPlayer.Play();
        }

        youtubeButton = GetComponentInChildren<Button>();
        youtubeButton.onClick.AddListener(() => Application.OpenURL(showreelYoutubeURL));
        youtubeButton.interactable = false;

    }



    protected override void Interaction()
    {
        youtubeButton.interactable = true;
    }

    protected override void EndInteraction()
    {
        youtubeButton.interactable = false;
    }

}