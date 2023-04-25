using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    Vector3 offset;

    // private bool isInTriggerZone = false;
    Animator m_Animator;

    // private Vector3 originalPosition;
    [SerializeField]
    private float speed = 10;
    ObjectReset objectReset;
    private bool isInZone;

    // [SerializeField] private IngredientBehaviour ingredientBehaviour;
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

    // private bool inZoneDragTag;

    private void OnEnable()
    {
        objectReset = GetComponent<ObjectReset>();
    }

    private void Awake()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // private void Update()
    // {
    //     Vector3 targetPosition = targetObject.transform.position;
    // }
    // private void Start()
    // {
    //     // originalPosition = transform.position;
    // }
    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        // taking the pivit point or the mouse position of the zero.
        offset = transform.position - MouseWorldPosition();
    }

    private void OnMouseDrag()
    {
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
        if (isInZone)
        {
            StartCoroutine("RecenterObject");
            Debug.Log("Stay here");
            // m_Animator.SetBool("OnPourBool",true);

            cardDisplay.SendData();
            // To Play Particle
            // StartCoroutine(PlayParticle());
            particleSystem.Play();
            hasPlayed = true;
        }
        else if (!isInZone)
        {
            // isInZone = false;
            // transform.position = originalPosition;
            if (!objectReset.isResetting)
                objectReset.ReturntToBase();
            // originalPosition = new Vector3(0,0,0);
        }
    }

    IEnumerator RecenterObject()
    {
        //float time
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


    // private IEnumerator PlayParticle()
    // {
    //     yield return new WaitForSeconds(delay);
    //     particleSystem.Play();
    //     // ingredientBehaviour.SendData();
    // }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("dropAreaTag") && !hasPlayed)
        {
            isInZone = true;
            tab.SetActive(true);
            downArrowTab.SetActive(false);

            // if (!isInTriggerZone)
            // {
            // do something
            // Debug.Log("In Zone");
            // reset position
            // originalPosition = transform.position;

            // Invoke("MakeObjectStay", 0.1f); // delay the action for 0.1 seconds
            // }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInZone = false;
        // tab.SetActive(false);
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}





// public class DragAndDrop : MonoBehaviour
// {
//     private void OnMouseDrag()
//     {
//         transform.position=GetMousePos();
//     }
//     Vector3 GetMousePos()
//     {
//         var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//         // mousePos.z=0;
//         return mousePos;
//     }
// }

// public class DragAndDrop : MonoBehaviour
// {
//      private Vector3 originalPosition;
//     private Vector3 offset;

//     private void Start()
//     {
//         originalPosition = transform.position;
//     }

//     private void OnMouseDown()
//     {
//         offset = gameObject.transform.position - GetMouseWorldPos();
//     }

//     private void OnMouseDrag()
//     {
//         transform.position = GetMouseWorldPos() + offset;
//     }

//     private void OnMouseUp()
//     {
//         transform.position = originalPosition;
//     }

//     private Vector3 GetMouseWorldPos()
//     {
//         Vector3 mousePos = Input.mousePosition;
//         mousePos.z = Camera.main.transform.position.z - transform.position.z;
//         return Camera.main.ScreenToWorldPoint(mousePos);
//     }
// }
