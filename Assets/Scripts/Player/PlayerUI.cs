using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerUI : MonoBehaviour
{

    [SerializeField] private GameObject controlsUI;
    private bool isVisible = true;

    [SerializeField] private GameObject businessCardUI;
    private Button businessCardButton;
    private GameObject businessCard;
    private Button businessCardCloseButton;

    private bool hasBusinessCard = false;
    public void GiveBusinessCard()
    {
        hasBusinessCard = true;
        if(isVisible) businessCardUI.SetActive(true);
    }



    private void Start()
    {

        businessCardButton = businessCardUI.transform.GetChild(0).GetComponent<Button>();
        businessCard = businessCardUI.transform.GetChild(1).gameObject;
        businessCardCloseButton = businessCard.transform.GetComponentInChildren<Button>();

        businessCardButton.onClick.AddListener(() => businessCard.SetActive(true));
        businessCardCloseButton.onClick.AddListener(() => businessCard.SetActive(false));

        businessCard.SetActive(false);
        businessCardUI.SetActive(false);

    }



    public void HideControls()
    {

        isVisible = false;

        controlsUI.SetActive(false);

        if(hasBusinessCard) businessCardUI.SetActive(false);

    }



    public void ShowControls()
    {

        isVisible = true;

        controlsUI.SetActive(true);

        if(hasBusinessCard) businessCardUI.SetActive(true);

    }

}