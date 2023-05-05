using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragAndDrop : MonoBehaviour
{
    Vector3 offset;

    Animator m_Animator;

    [SerializeField]
    private float speed = 10;
    ObjectReset objectReset;
    private bool isInZone;

    [SerializeField]
    private CardDisplay cardDisplay;

    [Space]
    [Header("To make the ingredients come  to center")]
    public GameObject targetObject;
    private bool isIngredientResetting;
    public float lerpSpeed = 0.5f;

    [Space]
    [Header("Ingredients Tab")]
    public GameObject tab;
    public GameObject downArrowTab;

    [Space]
    [Header("For Particle")]
    public new ParticleSystem particleSystem;
    public float delay = 3f;
    private bool hasPlayed = false;

    private void OnEnable()
    {
        objectReset = GetComponent<ObjectReset>();
    }

    private void Awake()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if (hasPlayed)
            return;

        Debug.Log("OnMouseDown");
        // taking the pivit point or the mouse position of the zero.
        offset = transform.position - MouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        if (hasPlayed)
            return;

        if (objectReset.isResetting)
            return;
        Debug.Log("OnMouseDrag");
        transform.position = Vector3.MoveTowards(
            transform.position,
            MouseWorldPosition() + offset,
            speed * Time.deltaTime
        );
    }

    private void OnMouseUp()
    {
        Debug.Log("OnMouseUp");
        if (isInZone && !hasPlayed)
        {
            StartCoroutine("RecenterObject");
            Debug.Log("Stay here");
            // m_Animator.SetBool("OnPourBool",true);

            cardDisplay.SendData();
            // To Play Particle
            particleSystem.Play();
            hasPlayed = true;
        }
        else if (!isInZone)
        {
            if (!objectReset.isResetting)
                objectReset.ReturntToBase();
        }
    }

    IEnumerator RecenterObject()
    {
        float startTime = 0;
        Vector3 targetPosition = targetObject.transform.position;
        Debug.Log("going to target");
        isIngredientResetting = true;
        while (startTime < lerpSpeed)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                targetPosition,
                startTime / lerpSpeed
            );
            startTime += Time.deltaTime;
            yield return null;
        }
        m_Animator.SetTrigger("OnPour");
        isIngredientResetting = false;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("dropAreaTag") && !hasPlayed)
        {
            isInZone = true;
            tab.SetActive(true);
            downArrowTab.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInZone = false;
        // hasPlayed = false;
        // tab.SetActive(false);
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}

    // private IEnumerator PlayParticle()
    // {
    //     yield return new WaitForSeconds(delay);
    //     particleSystem.Play();
    //     // ingredientBehaviour.SendData();
    // }