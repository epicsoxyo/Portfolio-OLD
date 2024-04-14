using UnityEngine;



[CreateAssetMenu(fileName = "GameInfoAsset", menuName = "GameInfoAsset", order = 0)]
public class GameInfoAsset : ScriptableObject
{

    [Header("Links")]
    public string gameURL;
    public string githubURL;

    [Header("Info Text")]
    public string projectTitle;
    public string languagesUsed;
    public string softwareUsed;
    public string genre;

    public string timeTaken;

    [TextArea(15, 50)] [Tooltip("Remember to stick to the three paragraphs rule:\n- what is this and why did I do it\n- what was my contribution and how did I achieve it\n- how do I feel about it and what did I learn")]
    public string contribution;

    /*
        Remember to stick to the three paragraphs rule:
        - what is this and why did I do it
        - what was my contribution and how did I achieve it
        - how do I feel about it and what did I learn
    */

}