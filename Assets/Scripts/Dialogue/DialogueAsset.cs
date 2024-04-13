using UnityEngine;



[CreateAssetMenu(fileName = "DialogueAsset", menuName = "DialogueAsset", order = 0)]
public class DialogueAsset : ScriptableObject
{

    [TextArea]
    public string[] dialogue;

}