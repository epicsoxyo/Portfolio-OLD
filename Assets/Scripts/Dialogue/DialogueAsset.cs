using UnityEngine;



[CreateAssetMenu(fileName = "DialogueAsset", menuName = "DialogueAsset", order = 0)]
public class DialogueAsset : ScriptableObject
{

    public string dialogueName;

    [TextArea]
    public string[] dialogue;

}