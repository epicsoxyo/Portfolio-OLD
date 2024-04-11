using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



[RequireComponent(typeof(Collider))]
public abstract class Interactable : MonoBehaviour
{

    private GameObject promptText;

    private bool isInteractable = false;
    public bool IsInteractable
    {
        get
        {
            return isInteractable;
        }
        set
        {
            promptText.SetActive(value);
            isInteractable = value;
        }
    }

    protected Transform cameraPointTransform;
    public Transform CameraPointTransform
    {
        get{return cameraPointTransform;}
    }



    /////////////override these ////////////////
    protected abstract void Interaction();
    protected virtual void EndInteraction() {}
    ////////////////////////////////////////////



    protected virtual void Start()
    {

        promptText = GetComponentInChildren<TMP_Text>().gameObject;
        promptText.SetActive(false);

        foreach(Transform child in GetComponentsInChildren<Transform>())
        {
            if(child.CompareTag("CameraPoint"))
            {
                cameraPointTransform = child;
                break;
            }
        }

    }



    public void TriggerInteraction()
    {

        if(!isInteractable) return;

        promptText.SetActive(false);

        Interaction();

    }


    
    public void TriggerEndInteraction()
    {

        promptText.SetActive(isInteractable);

        EndInteraction();

    }



}