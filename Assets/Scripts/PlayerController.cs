using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;



[RequireComponent(typeof(NavMeshAgent), typeof(Collider))]
public class Controller : MonoBehaviour
{

    private Animator anim;

    private NavMeshAgent agent;
    [SerializeField] private float destinationRadius = 0.5f;

    private Interactable currentInteractable;
    private bool isInteracting = false;

    private SpriteRenderer playerSprite;

    private Transform playerCameraTransform;
    private Transform playerCameraDefaultTransform;
    [SerializeField] private float cameraZoomInLerpTime;
    [SerializeField] private float cameraZoomOutLerpTime;



    // get character controller and animator
    private void Start()
    {

        DialoguePanel dialoguePanel = FindFirstObjectByType<DialoguePanel>();
        dialoguePanel.dialogueEnd.AddListener(() => StartCoroutine("EndInteraction"));

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;

        anim = GetComponentInChildren<Animator>();

        playerSprite = GetComponentInChildren<SpriteRenderer>();

        playerCameraTransform = GetComponentInChildren<Camera>().transform;

        foreach(Transform child in GetComponentsInChildren<Transform>())
        {
            if(child.CompareTag("CameraPoint"))
            {
                playerCameraDefaultTransform = child;
                break;
            }
        }

    }



    // each frame: check for movement then move player
    private void Update()
    {

        Vector2 input = GetMovementInput();

        Move(input);

        if(isInteracting && (input != Vector2.zero || Input.GetButtonDown("Cancel")))
        {
            StartCoroutine("EndInteraction");
        }

        if(!isInteracting && Input.GetButtonDown("Interact"))
        {
            StartCoroutine("Interact");
        }

    }



    // gets movement input using currently active input method
    private Vector2 GetMovementInput()
    {

        Vector2 input = new Vector2
        (
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        input.Normalize();

        if(input.magnitude >= 0.01f) return input;

        return Vector2.zero;

    }



    // moves the player in the specified direction if they are not currently dodging
    private void Move(Vector2 input)
    {

        Vector3 movementDirection = new Vector3
        (
            input.x,
            0f,
            input.y
        );

        agent.SetDestination(transform.position + movementDirection * destinationRadius);

        anim.SetFloat("HorizontalVelocity", input.x);
        anim.SetFloat("VerticalVelocity", Mathf.Abs(input.y));

    }



    // enables interaction
    private void OnTriggerEnter(Collider other)
    {

        Interactable interactable = other.GetComponent<Interactable>();

        if(interactable == null) return;

        if((currentInteractable != null) && (interactable != currentInteractable))
            currentInteractable.IsInteractable = false;

        currentInteractable = interactable;
        currentInteractable.IsInteractable = true;

    }



    // disables interaction
    private void OnTriggerExit(Collider other)
    {

        Interactable interactable = other.GetComponent<Interactable>();

        if(interactable != currentInteractable) return;

        currentInteractable.IsInteractable = false;
        currentInteractable = null;

    }



    private IEnumerator Interact()
    {

        StopCoroutine("EndInteraction");
        isInteracting = true;

        if(currentInteractable == null) yield break;
        currentInteractable.TriggerInteraction();

        float timeElapsed = 0f;
        Transform newTransform = currentInteractable.CameraPointTransform;

        if(newTransform == null) yield break;

        Vector3 endPos = newTransform.position;
        Quaternion endRot = newTransform.rotation;

        while(timeElapsed < cameraZoomInLerpTime)
        {

            timeElapsed += Time.deltaTime;

            playerCameraTransform.position = Vector3.Lerp
            (
                playerCameraDefaultTransform.position,
                endPos,
                timeElapsed / cameraZoomInLerpTime
            );

            playerCameraTransform.rotation = Quaternion.Lerp
            (
                playerCameraDefaultTransform.rotation,
                endRot,
                timeElapsed / cameraZoomInLerpTime
            );

            playerSprite.color = new Color
            (
                playerSprite.color.r,
                playerSprite.color.g,
                playerSprite.color.b,
                Mathf.Lerp(1f, 0f, timeElapsed / cameraZoomInLerpTime)
            );

            yield return null;

        }

    }



    private IEnumerator EndInteraction()
    {

        StopCoroutine("Interact");
        isInteracting = false;

        if(currentInteractable == null) yield break;
        currentInteractable.TriggerEndInteraction();


        float timeElapsed = 0f;

        Vector3 startPos = playerCameraTransform.position;
        Quaternion startRot = playerCameraTransform.rotation;

        while(timeElapsed < cameraZoomOutLerpTime)
        {

            timeElapsed += Time.deltaTime;

            playerCameraTransform.position = Vector3.Lerp
            (
                startPos,
                playerCameraDefaultTransform.position,
                timeElapsed / cameraZoomOutLerpTime
            );

            playerCameraTransform.rotation = Quaternion.Lerp
            (
                startRot,
                playerCameraDefaultTransform.rotation,
                timeElapsed / cameraZoomOutLerpTime
            );

            playerSprite.color = new Color
            (
                playerSprite.color.r,
                playerSprite.color.g,
                playerSprite.color.b,
                Mathf.Lerp(0f, 1f, timeElapsed / cameraZoomOutLerpTime)
            );

            yield return null;

        }

    }

}